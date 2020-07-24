using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using SimplCommerce.Infrastructure;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Infrastructure.Helpers;
using SimplCommerce.Infrastructure.Web;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Core.Models;
using SimplCommerce.Module.Core.Services;
using SimplCommerce.Module.Payments.Models;
using SimplCommerce.Module.PaymentStripeV2.Extensions;
using SimplCommerce.Module.PaymentStripeV2.Models;
using SimplCommerce.Module.PaymentStripeV2.Services;
using SimplCommerce.Module.ShoppingCart.Areas.ShoppingCart.ViewModels;
using SimplCommerce.Module.ShoppingCart.Services;
using Stripe;
using Stripe.Checkout;
using Order = SimplCommerce.Module.Orders.Models.Order;

namespace SimplCommerce.Module.PaymentStripeV2.Areas.PaymentStripeV2.Controllers
{
    [Area("PaymentStripeV2")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class StripeV2Controller : Controller
    {
        private const string SessionId = "sessionId";
        private const string PaymentAttemptId = "paymentAttemptId";

        private readonly IPaymentStripeV2Service _paymentStripeV2Service;
        private readonly IWorkContext _workContext;
        private readonly ICartService _cartService;
        private readonly ICurrencyService _currencyService;
        private readonly IStringLocalizer _localizer;
        private readonly ILogger _logger;

        private Guid NewGuid { get => Guid.NewGuid(); } 

        public StripeV2Controller(
            IPaymentStripeV2Service paymentStripeV2Service,
            IWorkContext workContext,
            ICartService cartService,
            IRepositoryWithTypedId<PaymentProvider, string> paymentProviderRepository,
            ICurrencyService currencyService,
            IStringLocalizerFactory stringLocalizerFactory,
            ILoggerFactory loggerFactory)
        {
            _paymentStripeV2Service = paymentStripeV2Service;
            _workContext = workContext;
            _cartService = cartService;
            _currencyService = currencyService;
            _localizer = stringLocalizerFactory.Create(null);
            _logger = loggerFactory.CreateLogger<StripeV2Controller>();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCheckoutSession()
        {
            await _paymentStripeV2Service.InitializeStripe();

            // Get customer's active cart
            var currentUser = await _workContext.GetCurrentUser();
            var cartVm = await _cartService.GetActiveCartDetails(currentUser.Id);
            if (cartVm == null)
            {
                return NotFound();
            }

            var paymentAttempt = await _paymentStripeV2Service.CreatePaymentAttempt(cartVm.Id, cartVm.OrderTotal, $"Creating payment attempt for UserId={currentUser.Id} ...");
            var metadata = GetSessionMetadata(currentUser, cartVm, StripeConfiguration.ApiKey);
            var rootUrl = Request.GetFullHostingUrlRoot();

            var options = new SessionCreateOptions
            {
                ClientReferenceId = $"{cartVm.Id}",
                Metadata = metadata,
                CustomerEmail = currentUser.Email,
                PaymentMethodTypes = new List<string> {
                    "card",
                },
                LineItems = GetSessionLineItemOptions(cartVm).ToList(),
                Mode = "payment",
                SuccessUrl = $"{rootUrl}/PaymentStripeV2/StripeV2/CallbackStripePaymentSuccess?{SessionId}={{CHECKOUT_SESSION_ID}}&{PaymentAttemptId}={paymentAttempt.Id}",
                CancelUrl = $"{rootUrl}/PaymentStripeV2/StripeV2/CallbackStripePaymentFailure?{SessionId}={{CHECKOUT_SESSION_ID}}&{PaymentAttemptId}={paymentAttempt.Id}",
            };

            try
            {
                var service = new SessionService();
                Session session = service.Create(options, new RequestOptions
                {
                    IdempotencyKey = metadata[PaymentStripeV2Service.IdempotencyKey],
                });

                // update PaymentAttempt with Session Id
                paymentAttempt.PaymentAttemptId = session.Id;
                paymentAttempt.UpdatedNow();
                await _paymentStripeV2Service.UpdatePaymentAttempt();

                _paymentStripeV2Service.LogSession(session);

                var sessionData = new Dictionary<string, string> { { SessionId, session.Id } };
                var result = Json(sessionData);

                return result;
            }
            catch (StripeException ex)
            {
                var message = $"CreateCheckoutSession failed for userId={currentUser.Id} and cartId={cartVm.Id} ({PaymentAttemptId}={paymentAttempt?.Id}).";
                TempData["Error"] = _localizer[ex?.Message].Value;
                _logger.LogError(ex, message);

                if (paymentAttempt != null)
                {
                    paymentAttempt.AddInfo($"{message}\n{ex?.Message}");
                    paymentAttempt.IsProcessed = true;
                    paymentAttempt.UpdatedNow();
                    await _paymentStripeV2Service.UpdatePaymentAttempt();
                }

                return Redirect("~/checkout/payment");
            }
        }

        public async Task<IActionResult> CallbackStripePaymentSuccess([FromQuery(Name = SessionId)] string sessionId, [FromQuery(Name = PaymentAttemptId)] long paymentAttemptId)
        {
            var guid = NewGuid;
            var paymentAttempt = await _paymentStripeV2Service.GetPaymentAttempt(paymentAttemptId);
            paymentAttempt.UpdatedNow();
            paymentAttempt.AddInfo($"Received CallbackStripePaymentSuccess for {SessionId}={sessionId} ({PaymentAttemptId}={paymentAttemptId}) ...");
            await _paymentStripeV2Service.UpdatePaymentAttempt();

            if (paymentAttempt.PaymentAttemptId != sessionId)
            {
                _logger.LogError($"Error during payment. {SessionId}={sessionId} doesn't match {PaymentAttemptId}={paymentAttemptId}. Aborting ... ({guid})");
                TempData["Error"] = _localizer["Error during payment. Aborting ... ({0})", guid].Value;
                return Redirect($"~/checkout/error");
            }

            var session = await _paymentStripeV2Service.GetSession(paymentAttempt.PaymentAttemptId);
            var paymentIntent = await _paymentStripeV2Service.GetPaymentIntent(session);

            if (session == null || paymentIntent == null || paymentIntent.Status != StripeIntentStatus.Succeeded.GetEnumMember())
            {
                _logger.LogError($"{nameof(PaymentIntent)} with {nameof(sessionId)}='{sessionId}' had an invalid status ({paymentIntent?.Status}). Aborting ... ({guid})");
                TempData["Error"] = _localizer["Invalid status ({0}). Aborting ... ({1})", paymentIntent?.Status, guid].Value;
                return Redirect("~/checkout/payment");
            }

            var currentUser = await _workContext.GetCurrentUser();

            if (currentUser.Id != paymentAttempt.Cart.CustomerId)
            {
                _logger.LogError($"User {currentUser.Id} tried to impersonate {paymentAttempt.Cart.CustomerId}. Skipping because of security breach ... ({guid})");
                TempData["Error"] = _localizer["Mismatching user. Aborting ..."].Value;
                return Redirect("~/checkout/payment");
            }

            var orderCreationResult = await _paymentStripeV2Service.CreateOrderForUser(session, paymentIntent, paymentAttempt);
            return HandleOrderCreationResult(orderCreationResult);
        }

        private IActionResult HandleOrderCreationResult(object orderCreationResult)
        {
            var guid = NewGuid;

            if (orderCreationResult == null)
            {
                return NotFound();
            }
            else if (orderCreationResult is Result<Order>)
            {
                var result = orderCreationResult as Result<Order>;
                _logger.LogError(result?.Error);
                if (!string.IsNullOrWhiteSpace(result?.Error)) { TempData["Error"] = _localizer[result?.Error + " ({0})", guid].Value; }
                return Redirect("~/checkout/payment");
            }
            else if (orderCreationResult is Order)
            {
                var order = orderCreationResult as Order;
                return Redirect($"~/checkout/success?orderId={order.Id}");
            }

            _logger.LogError(orderCreationResult.ToString());
            TempData["Error"] = _localizer[orderCreationResult.ToString() + " ({0})", guid].Value;
            return Redirect($"~/checkout/error");
        }

        public async Task<IActionResult> CallbackStripePaymentFailure([FromQuery(Name = SessionId)] string sessionId, [FromQuery(Name = PaymentAttemptId)] long paymentAttemptId)
        {
            await _paymentStripeV2Service.InitializeStripe();

            var service = new SessionService();
            var session = service.Get(sessionId);

            _logger.LogError($"Received CallbackStripePaymentFailure for {SessionId}={sessionId} ({PaymentAttemptId}={paymentAttemptId}) ...");
            _paymentStripeV2Service.LogSession(session, LogLevel.Error);

            var paymentAttempt = await _paymentStripeV2Service.GetPaymentAttempt(paymentAttemptId);

            if (paymentAttempt != null)
            {
                paymentAttempt.IsProcessed = true;
                paymentAttempt.UpdatedNow();
                paymentAttempt.AddInfo($"Received CallbackStripePaymentFailure. Finalizing PaymentAttempt.");
                await _paymentStripeV2Service.UpdatePaymentAttempt();
            }

            TempData["Error"] = _localizer["Your Stripe payment has failed. Please try again!"].Value;
            return Redirect("~/checkout/payment");
        }

        private IEnumerable<SessionLineItemOptions> GetSessionLineItemOptions(CartVm cartVm)
        {
            // Define some helpers
            int getZeroDecimalAmount(decimal itemPrice) => !CurrencyHelper.IsZeroDecimalCurrencies(_currencyService.CurrencyCulture) ? (int)(itemPrice *= 100) : (int)itemPrice;
            var regionInfo = new RegionInfo(_currencyService.CurrencyCulture.LCID);

            //var imageUrls = cartVm.Items.Select(i => i.ProductImage)
            //                .Where(url => Uri.TryCreate(url, UriKind.Absolute, out var uriResult)
            //                                && (uriResult.Scheme == Uri.UriSchemeHttps || uriResult.Scheme == Uri.UriSchemeHttp));

            var sessionLineItem = new SessionLineItemOptions
            {
                PriceData = new SessionLineItemPriceDataOptions
                {
                    ProductData = new SessionLineItemPriceDataProductDataOptions
                    {
                        Name = _localizer["Your purchase at simplcommerce.com"],
                        //Images = imageUrls.Any() ? imageUrls.ToList() : null,
                    },
                    UnitAmount = getZeroDecimalAmount(cartVm.OrderTotal),
                    Currency = regionInfo.ISOCurrencySymbol,
                },
                Quantity = 1,
            };

            return new List<SessionLineItemOptions> { sessionLineItem };
        }

        private Dictionary<string, string> GetSessionMetadata(User user, CartVm cartVm, string stripeApiKey)
        {

            var dictionary = new Dictionary<string, string>
            {
                { PaymentStripeV2Service.EnvironmentId, Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") },
                { PaymentStripeV2Service.CustomerId, $"{user.Id}" },
                { PaymentStripeV2Service.CustomerEmail, $"{user.Email}" },
                { PaymentStripeV2Service.CartId, $"{cartVm.Id}" },
                { PaymentStripeV2Service.AmountTotal, $"{cartVm.OrderTotal}" },
                { PaymentStripeV2Service.IdempotencyKey, $"{Guid.NewGuid()}" },
                { PaymentStripeV2Service.ApiKey, stripeApiKey },
            };

            return dictionary;
        }
    }
}
