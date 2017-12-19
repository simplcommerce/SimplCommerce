using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Stripe;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Orders.Services;
using SimplCommerce.Module.ShoppingCart.Models;
using SimplCommerce.Infrastructure;
using SimplCommerce.Module.Payments.Models;
using System.Globalization;

namespace SimplCommerce.Module.PaymentStripe.Controllers
{
    public class StripeController : Controller
    {
        private readonly IRepository<Cart> _cartRepository;
        private readonly IOrderService _orderService;
        private readonly IWorkContext _workContext;
        private readonly IConfiguration _configuration;
        private readonly IRepository<Payment> _paymentRepository;
        private readonly string _secretKey;

        public StripeController(
            IRepository<Cart> cartRepository,
            IOrderService orderService,
            IWorkContext workContext,
            IConfiguration configuration,
            IRepository<Payment> paymentRepository)
        {
            _cartRepository = cartRepository;
            _orderService = orderService;
            _workContext = workContext;
            _configuration = configuration;
            _paymentRepository = paymentRepository;
            _secretKey = _configuration["Stripe:SecretKey"];
        }

        public async Task<IActionResult> Charge(string stripeEmail, string stripeToken)
        {
            var customers = new StripeCustomerService(_secretKey);
            var charges = new StripeChargeService(_secretKey);
            var currentUser = await _workContext.GetCurrentUser();
            var order = await _orderService.CreateOrder(currentUser, "Stripe");

            var customer = customers.Create(new StripeCustomerCreateOptions
            {
                Email = stripeEmail,
                SourceToken = stripeToken
            });

            var zeroDecimalOrderAmount = order.OrderTotal;
            if(!CurrencyHelper.IsZeroDecimalCurrencies())
            {
                zeroDecimalOrderAmount = zeroDecimalOrderAmount * 100;
            }

            var regionInfo = new RegionInfo(CultureInfo.CurrentCulture.LCID);

            var charge = charges.Create(new StripeChargeCreateOptions
            {
                Amount = (int)zeroDecimalOrderAmount,
                Description = "Sample Charge",
                Currency =  regionInfo.ISOCurrencySymbol,
                CustomerId = customer.Id
            });

            var payment = new Payment()
            {
                OrderId = order.Id,
                Amount = order.OrderTotal,
                PaymentMethod = "Stripe",
                CreatedOn = DateTimeOffset.UtcNow,
                GatewayTransactionId = charge.Id
            };

            order.OrderStatus = Orders.Models.OrderStatus.Processing;
            _paymentRepository.Add(payment);
            await _paymentRepository.SaveChangesAsync();

            return Redirect("~/checkout/congratulation");
        }
    }
}
