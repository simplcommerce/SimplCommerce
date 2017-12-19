using System;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Stripe;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Orders.Services;
using SimplCommerce.Module.ShoppingCart.Models;
using SimplCommerce.Infrastructure;
using SimplCommerce.Module.Payments.Models;
using SimplCommerce.Module.PaymentStripe.ViewModels;
using SimplCommerce.Module.PaymentStripe.Models;

namespace SimplCommerce.Module.PaymentStripe.Controllers
{
    public class StripeController : Controller
    {
        private readonly IRepository<Cart> _cartRepository;
        private readonly IOrderService _orderService;
        private readonly IWorkContext _workContext;
        private readonly IRepository<PaymentProvider> _paymentProviderRepository;
        private readonly IRepository<Payment> _paymentRepository;

        public StripeController(
            IRepository<Cart> cartRepository,
            IOrderService orderService,
            IWorkContext workContext,
            IRepository<PaymentProvider> paymentProviderRepository,
            IRepository<Payment> paymentRepository)
        {
            _cartRepository = cartRepository;
            _orderService = orderService;
            _workContext = workContext;
            _paymentProviderRepository = paymentProviderRepository;
            _paymentRepository = paymentRepository;
        }

        public async Task<IActionResult> Charge(string stripeEmail, string stripeToken)
        {
            var stripeProvider = await _paymentProviderRepository.Query().FirstOrDefaultAsync(x => x.Id == PaymentProviderHelper.StripeProviderId);
            var stripeSetting = JsonConvert.DeserializeObject<StripeConfigForm>(stripeProvider.AdditionalSettings);

            var customers = new StripeCustomerService(stripeSetting.PrivateKey);
            var charges = new StripeChargeService(stripeSetting.PrivateKey);
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

            // TODO handle exception
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
