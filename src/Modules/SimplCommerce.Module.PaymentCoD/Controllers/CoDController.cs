using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using System.Linq;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Orders.Services;
using SimplCommerce.Module.ShoppingCart.Services;
using SimplCommerce.Module.Payments.Models;
using SimplCommerce.Module.PaymentCoD.Models;

namespace SimplCommerce.Module.PaymentCoD.Controllers
{
    [Authorize]
    public class CoDController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IWorkContext _workContext;
        private readonly ICartService _cartService;
        private readonly IRepository<PaymentProvider> _paymentProviderRepository;
        private Lazy<CODfee> _setting;
        public CoDController(
            ICartService cartService,
            IOrderService orderService,
            IRepository<PaymentProvider> paymentProviderRepository,
            IWorkContext workContext)
        {
            _paymentProviderRepository = paymentProviderRepository;
            _cartService = cartService;
            _orderService = orderService;
            _workContext = workContext;
            _setting = new Lazy<CODfee>(GetSetting());
        }

        [HttpPost]
        public async Task<IActionResult> CoDCheckout()
        {
            if (!await ValidateCod())
            {
                TempData["Error"] = "Payment Method is not eligible for this order.";
                return Redirect("~/checkout/payment");
            }
            var currentUser = await _workContext.GetCurrentUser();
            var calculatedFee = await CalculateFee();
            var orderCreateResult = await _orderService.CreateOrder(currentUser, "CashOnDelivery", calculatedFee);

            if (!orderCreateResult.Success)
            {
                TempData["Error"] = orderCreateResult.Error;
                return Redirect("~/checkout/payment");
            }

            return Redirect("~/checkout/congratulation");
        }

        private CODfee GetSetting()
        {
            var CodProvider = _paymentProviderRepository.Query().FirstOrDefault(x => x.Id == PaymentProviderHelper.CODProviderId);
            var paypalExpressSetting = JsonConvert.DeserializeObject<CODfee>(CodProvider.AdditionalSettings);

            return paypalExpressSetting;
        }

        private async Task<bool> ValidateCod()
        {
            var currentUser = await _workContext.GetCurrentUser();
            var cart = await _cartService.GetCart(currentUser.Id);

            return cart.OrderTotal >= _setting.Value.MinValue && cart.OrderTotal <= _setting.Value.MaxValue;
        }

        private async Task<decimal> CalculateFee()
        {
            var currentUser = await _workContext.GetCurrentUser();
            var cart = await _cartService.GetCart(currentUser.Id);
            var percent = _setting.Value.PaymentFee;

            return (cart.OrderTotal / 100) * percent;
        }
    }
}
