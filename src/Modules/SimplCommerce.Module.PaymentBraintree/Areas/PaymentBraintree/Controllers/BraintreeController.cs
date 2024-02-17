using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Braintree;
using Microsoft.AspNetCore.Mvc;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Infrastructure.Helpers;
using SimplCommerce.Module.Checkouts.Services;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Core.Services;
using SimplCommerce.Module.Orders.Models;
using SimplCommerce.Module.Orders.Services;
using SimplCommerce.Module.PaymentBraintree.Models;
using SimplCommerce.Module.PaymentBraintree.Services;
using SimplCommerce.Module.Payments.Models;
using SimplCommerce.Module.ShoppingCart.Services;

namespace SimplCommerce.Module.PaymentBraintree.Areas.PaymentBraintree.Controllers
{
    [Area("PaymentBraintree")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class BraintreeController : Controller
    {
        private readonly ICheckoutService _checkoutService;
        private readonly IOrderService _orderService;
        private readonly IWorkContext _workContext;
        private readonly IRepositoryWithTypedId<PaymentProvider, string> _paymentProviderRepository;
        private readonly IRepository<Payment> _paymentRepository;
        private readonly IBraintreeConfiguration _braintreeConfiguration;
        private readonly ICurrencyService _currencyService;

        public BraintreeController(
            ICheckoutService checkoutService,
            IOrderService orderService,
            IWorkContext workContext,
            IRepositoryWithTypedId<PaymentProvider, string> paymentProviderRepository,
            IRepository<Payment> paymentRepository,
            IBraintreeConfiguration braintreeConfiguration,
            ICurrencyService currencyService)
        {
            _checkoutService = checkoutService;
            _orderService = orderService;
            _workContext = workContext;
            _paymentProviderRepository = paymentProviderRepository;
            _paymentRepository = paymentRepository;
            _braintreeConfiguration = braintreeConfiguration;
            _currencyService = currencyService;
        }

        [HttpPost]
        public async Task<IActionResult> Charge(string nonce, Guid checkoutId)
        {
            var gateway = await _braintreeConfiguration.BraintreeGateway();

            var curentUser = await _workContext.GetCurrentUser();

            var cart = await _checkoutService.GetCheckoutDetails(checkoutId);
            if(cart == null)
            {
                return NotFound();
            }
            var orderCreateResult = await _orderService.CreateOrder(checkoutId, PaymentProviderHelper.BraintreeProviderId, 0, OrderStatus.PendingPayment);

            if (!orderCreateResult.Success)
            {
                return BadRequest(orderCreateResult.Error);
            }

            var order = orderCreateResult.Value;
            var zeroDecimalOrderAmount = order.OrderTotal;
            if (!CurrencyHelper.IsZeroDecimalCurrencies(_currencyService.CurrencyCulture))
            {
                zeroDecimalOrderAmount = zeroDecimalOrderAmount * 100;
            }

            var regionInfo = new RegionInfo(_currencyService.CurrencyCulture.LCID);
            var payment = new Payment()
            {
                OrderId = order.Id,
                Amount = order.OrderTotal,
                PaymentMethod = PaymentProviderHelper.BraintreeProviderId,
                CreatedOn = DateTimeOffset.UtcNow
            };

            var lineItemsRequest = new List<TransactionLineItemRequest>();

            //TODO: Need validation
            //foreach(var item in order.OrderItems)
            //{
            //    lineItemsRequest.Add(new TransactionLineItemRequest
            //    {
            //        Description = item.Product.Description.Substring(0, 255),
            //        Name = item.Product.Name,
            //        Quantity = item.Quantity,
            //        UnitAmount = item.ProductPrice,
            //        ProductCode = item.ProductId.ToString(),
            //        TotalAmount = item.ProductPrice * item.Quantity
                    
            //    });
            //}

            //TODO: See how customer id works
            var request = new TransactionRequest
            {
                Amount = order.OrderTotal,
                PaymentMethodNonce = nonce,
                OrderId = order.Id.ToString(),
                //LineItems = lineItemsRequest.ToArray(),
                //CustomerId = order.CustomerId.ToString(),
                Options = new TransactionOptionsRequest
                {
                    SubmitForSettlement = true,
                    SkipAdvancedFraudChecking = false,
                    SkipCvv = false,
                    SkipAvs = false,
                }
            };

            var result = gateway.Transaction.Sale(request);
            if (result.IsSuccess())
            {
                var transaction = result.Target;

                payment.GatewayTransactionId = transaction.Id;
                payment.Status = PaymentStatus.Succeeded;
                order.OrderStatus = OrderStatus.PaymentReceived;
                _paymentRepository.Add(payment);
                await _paymentRepository.SaveChangesAsync();

                return Ok(new { Status = "success", OrderId = order.Id, TransactionId = transaction.Id });
            }
            else
            {
                string errorMessages = "";
                foreach (var error in result.Errors.DeepAll())
                {
                    errorMessages += "Error: " + (int)error.Code + " - " + error.Message + "\n";
                }

                return BadRequest(errorMessages);
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetClientToken()
        {
            return Ok(await _braintreeConfiguration.GetClientToken());
        }
    }
}
