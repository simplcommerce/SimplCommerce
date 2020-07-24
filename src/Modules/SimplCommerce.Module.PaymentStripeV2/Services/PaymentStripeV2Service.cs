using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Infrastructure.Helpers;
using SimplCommerce.Module.Orders.Models;
using SimplCommerce.Module.Orders.Services;
using SimplCommerce.Module.Payments.Models;
using SimplCommerce.Module.PaymentStripeV2.Areas.PaymentStripeV2.ViewModels;
using SimplCommerce.Module.PaymentStripeV2.Extensions;
using SimplCommerce.Module.PaymentStripeV2.Models;
using SimplCommerce.Module.ShoppingCart.Models;
using Stripe;
using Stripe.Checkout;
using Order = SimplCommerce.Module.Orders.Models.Order;

namespace SimplCommerce.Module.PaymentStripeV2.Services
{
    public class PaymentStripeV2Service : IPaymentStripeV2Service
    {
        private readonly IRepositoryWithTypedId<PaymentProvider, string> _paymentProviderRepository;
        private readonly IRepository<Cart> _cartRepository;
        private readonly IOrderService _orderService;
        private readonly IRepository<PaymentAttempt> _paymentAttemptRepository;
        private readonly IRepository<Payment> _paymentRepository;
        private readonly IOrderEmailService _orderEmailService;
        private readonly ILogger _logger;

        public const string EnvironmentId = "EnvironmentName";
        public const string CustomerId = "CustomerId";
        public const string CustomerEmail = "CustomerEmail";
        public const string CartId = "CartId";
        public const string AmountTotal = "AmountTotal";
        public const string IdempotencyKey = "IdempotencyKey";
        public const string ApiKey = "ApiKey";
        public static readonly string EnvironmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        public PaymentStripeV2Service(
            IRepositoryWithTypedId<PaymentProvider, string> paymentProviderRepository,
            IRepository<Cart> cartRepository,
            IOrderService orderService,
            IRepository<PaymentAttempt> paymentAttemptRepository,
            IRepository<Payment> paymentRepository,
            IOrderEmailService orderEmailService,
            ILoggerFactory loggerFactory)
        {
            _paymentProviderRepository = paymentProviderRepository;
            _cartRepository = cartRepository;
            _orderService = orderService;
            _paymentAttemptRepository = paymentAttemptRepository;
            _paymentRepository = paymentRepository;
            _orderEmailService = orderEmailService;
            _logger = loggerFactory.CreateLogger<PaymentStripeV2Service>();
        }

        public async Task InitializeStripe()
        {
            if (string.IsNullOrWhiteSpace(StripeConfiguration.ApiKey))
            {
                // Initialize Stripe
                var stripeProvider = await _paymentProviderRepository.Query().FirstOrDefaultAsync(x => x.Id == PaymentProviderHelper.StripeProviderId);
                var stripeSetting = JsonConvert.DeserializeObject<StripeV2ConfigForm>(stripeProvider.AdditionalSettings);
                StripeConfiguration.ApiKey = stripeSetting.PrivateKey;
            }

            return;
        }

        /// <summary>
        /// Signature for scoped service with attempt to set culture only on one thread
        /// </summary>
        /// <param name="paymentAttemptId"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public async Task<object> CreateOrderForUser(long paymentAttemptId, string culture)
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(culture);
            return await CreateOrderForUser(paymentAttemptId);
        }

        /// <summary>
        /// This method is supposed to be called either from StripeApiController or from StripeBackgroundProcess
        /// </summary>
        /// <param name="sessionId"></param>
        /// <returns></returns>
        public async Task<object> CreateOrderForUser(long paymentAttemptId)
        {
            var paymentAttempt = await GetPaymentAttempt(paymentAttemptId);
            var session = await GetSession(paymentAttempt.PaymentAttemptId);
            var paymentIntent = await GetPaymentIntent(session);
            var orderCreationResult = await CreateOrderForUser(session, paymentIntent, paymentAttempt);

            return orderCreationResult;
        }

        public async Task<object> CreateOrderForUser(Session session, PaymentIntent paymentIntent, PaymentAttempt paymentAttempt)
        {
            var environment = EnvironmentName;
            var sessionEnv = session?.Metadata["EnvironmentName"];
            var userId = long.Parse(session?.Metadata[CustomerId]);
            var cart = paymentAttempt?.Cart;

            LogSession(session);

            // Check environment
            var environmentChecks = new List<(bool Condition, string Message)>
            {
                (cart == null, string.Empty),
                (environment != sessionEnv, $"Stripe payment processing attempted in {environment}, which was for {sessionEnv} (UserId='{session?.Metadata[CustomerId]}', CartId='{session?.Metadata[CartId]}')."),
                (StripeConfiguration.ApiKey != session?.Metadata[ApiKey], $"Stripe payment processing attempted in environment with {ApiKey} '{StripeConfiguration.ApiKey}', which was for '{session?.Metadata[ApiKey]}' (Environment='{sessionEnv}', UserId='{session?.Metadata[CustomerId]}', {CartId}='{session?.Metadata[CartId]}')."),
            };

            var environmentBreakingConditions = environmentChecks.Where(x => x.Condition).ToList();

            if (environmentBreakingConditions.Any())
            {
                environmentBreakingConditions.ForEach(c =>
                {
                    if (!string.IsNullOrWhiteSpace(c.Message))
                    {
                        _logger.LogInformation(c.Message);
                    }
                });

                return null;
            }

            // Check user & cart
            var safetyChecks = new List<(bool Condition, string Message)>
            {
                (cart.CustomerId != userId, $"Mismatch of the cart's {nameof(cart.CustomerId)}={cart.CustomerId} and the {paymentAttempt.GetType().Name}'s {nameof(userId)}={userId}. Aborting ..."),
                (cart.CreatedById != userId, $"Mismatch of the cart's {nameof(cart.CreatedById)}={cart.CreatedById} and the {paymentAttempt.GetType().Name}'s {nameof(userId)}={userId}. Aborting ..."),
                (!cart.IsActive, $"The cart with {nameof(cart.Id)}={cart.Id} is not active any more. Aborting ..."),
            };

            var paymentAttemptBreakingConditions = safetyChecks.Where(x => x.Condition).ToList();

            if (paymentAttemptBreakingConditions.Any())
            {
                var additionalInfos = paymentAttempt.GetAdditionalInfos();

                paymentAttemptBreakingConditions.ForEach((check) =>
                {
                    _logger.LogError(check.Message);
                    additionalInfos.AddInfo(check.Message);
                });

                paymentAttempt.AdditionalInformation = additionalInfos.ConvertToJson();
                paymentAttempt.IsProcessed = true;
                paymentAttempt.UpdatedNow();
                await UpdatePaymentAttempt();
                return null;
            }

            var orderCreationResult = await _orderService.CreateOrder(cart.Id, "Stripe", 0, OrderStatus.PendingPayment);

            if (orderCreationResult.Success && orderCreationResult?.Value != null)
            {
                var order = orderCreationResult.Value;

                var payment = new Payment()
                {
                    OrderId = order.Id,
                    Amount = order.OrderTotal,
                    PaymentMethod = "Stripe",
                    CreatedOn = DateTimeOffset.UtcNow,
                };

                payment.GatewayTransactionId = session.Id;

                if (paymentIntent.Status == StripeIntentStatus.Succeeded.GetEnumMember())
                {
                    if (paymentAttempt.RequestedAmount < order.OrderTotal)
                    {
                        payment.Status = PaymentStatus.PartiallySucceeded;
                        order.OrderStatus = OrderStatus.PaymentPartiallyReceived;
                    }
                    else
                    {
                        // Only set succeeded and PaymentReceived if that is the status in the PaymentIntent
                        payment.Status = PaymentStatus.Succeeded;
                        order.OrderStatus = OrderStatus.PaymentReceived;
                    }
                }
                else
                {
                    order.OrderStatus = OrderStatus.PendingPayment;
                }

                _paymentRepository.Add(payment);
                await _paymentRepository.SaveChangesAsync();

                var message = $"Successfully created {order.GetType().Name} with {nameof(order.Id)}={order.Id}.";
                _logger.LogInformation(message);
                paymentAttempt.AddInfo(message);
                paymentAttempt.IsProcessed = true;
                paymentAttempt.UpdatedNow();
                await UpdatePaymentAttempt();
                //await _orderEmailService.SendEmailToUser(order.Customer, order);
                return order;
            }
            else
            {
                var message = $"Error during creation of {typeof(Order).Name} for {typeof(Cart).Name} with {nameof(cart.Id)}={cart.Id}. Aborting ...\n({orderCreationResult?.Error})";
                _logger.LogError(message);
                paymentAttempt.AddInfo(message);
                paymentAttempt.IsProcessed = true;
                paymentAttempt.UpdatedNow();
                await UpdatePaymentAttempt();
                return orderCreationResult;
            }
        }

        public async Task<Session> GetSession(string sessionId)
        {
            await InitializeStripe();

            var sessionService = new SessionService();
            var session = sessionService.Get(sessionId);
            return session;
        }

        public async Task<PaymentIntent> GetPaymentIntent(string sessionId)
        {
            var session = await GetSession(sessionId);
            return await GetPaymentIntent(session);
        }

        public async Task<PaymentIntent> GetPaymentIntent(Session session)
        {
            if (string.IsNullOrWhiteSpace(session.PaymentIntentId))
            {
                return null;
            }

            await InitializeStripe();
            var paymentIntentService = new PaymentIntentService();
            var paymentIntent = paymentIntentService.Get(session.PaymentIntentId);

            return paymentIntent;
        }

        public async Task<PaymentAttempt> CreatePaymentAttempt(long cartId, decimal totalAmount, string message, [CallerMemberName] string callerMemberName = null)
        {
            var paymentAttempt = new PaymentAttempt
            {
                CartId = cartId,
                PaymentProviderId = PaymentProviderHelper.StripeProviderId,
                //PaymentAttemptId = sessionId,
                RequestedAmount = totalAmount,
                IsProcessed = false
            };
            paymentAttempt.AddInfo(message, callerMemberName);

            _paymentAttemptRepository.Add(paymentAttempt);
            await _paymentAttemptRepository.SaveChangesAsync();

            return paymentAttempt;
        }

        public async Task UpdatePaymentAttempt() => await _paymentAttemptRepository.SaveChangesAsync();

        public async Task<PaymentAttempt> GetPaymentAttempt(long paymentAttemptId)
        {
            var paymentAttempt = await _paymentAttemptRepository.Query()
                .Include(x => x.Cart).ThenInclude(x => x.Items)
                .Include(x => x.PaymentProvider)
                .Where(x => !x.IsProcessed && x.Id == paymentAttemptId).FirstOrDefaultAsync();
            return paymentAttempt;
        }

        public void LogSession(Session session, LogLevel logLevel = LogLevel.Debug)
        {
            try
            {
                _logger.Log(logLevel, session.ToJson());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception during logging of session object.");
            }
        }
    }
}
