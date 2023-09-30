using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Checkouts.Areas.Checkouts.ViewModels;
using SimplCommerce.Module.Checkouts.Services;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Orders.Services;
using SimplCommerce.Module.PaymentCoD.Models;
using SimplCommerce.Module.Payments.Models;
using SimplCommerce.Module.ShoppingCart.Areas.ShoppingCart.ViewModels;
using SimplCommerce.Module.ShoppingCart.Services;

namespace SimplCommerce.Module.PaymentCoD.Areas.PaymentCoD.Controllers
{
    [Authorize]
    [Area("PaymentCoD")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class CoDController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IWorkContext _workContext;
        private readonly ICheckoutService _checkoutService;
        private readonly IRepositoryWithTypedId<PaymentProvider, string> _paymentProviderRepository;
        private Lazy<CoDSetting> _setting;

        public CoDController(
            ICheckoutService checkoutService,
            IOrderService orderService,
            IRepositoryWithTypedId<PaymentProvider, string> paymentProviderRepository,
            IWorkContext workContext)
        {
            _paymentProviderRepository = paymentProviderRepository;
            _checkoutService = checkoutService;
            _orderService = orderService;
            _workContext = workContext;
            _setting = new Lazy<CoDSetting>(GetSetting());
        }

        public async Task<IActionResult> CoDCheckout([FromForm]Guid checkoutId)
        {
            var currentUser = await _workContext.GetCurrentUser();
            var checkoutVm = await _checkoutService.GetCheckoutDetails(checkoutId);
            if(checkoutVm == null)
            {
                return NotFound();
            }

            //TODO Validate again user login

            if (!ValidateCoD(checkoutVm))
            {
                TempData["Error"] = "Payment Method is not eligible for this order.";
                return Redirect("~/checkout/{checkoutId}/payment");
            }

            var calculatedFee = CalculateFee(checkoutVm);           
            var orderCreateResult = await _orderService.CreateOrder(checkoutVm.Id, "CashOnDelivery", calculatedFee);

            if (!orderCreateResult.Success)
            {
                TempData["Error"] = orderCreateResult.Error;
                return Redirect("~/checkout/{checkoutId}/payment");
            }

            return Redirect($"~/checkout/success?orderId={orderCreateResult.Value.Id}");
        }

        private CoDSetting GetSetting()
        {
            var coDProvider = _paymentProviderRepository.Query().FirstOrDefault(x => x.Id == PaymentProviderHelper.CODProviderId);
            if (string.IsNullOrEmpty(coDProvider.AdditionalSettings))
            {
                return new CoDSetting();
            }

            var coDSetting = JsonConvert.DeserializeObject<CoDSetting>(coDProvider.AdditionalSettings);
            return coDSetting;
        }

        private bool ValidateCoD(CheckoutVm checkoutVm)
        {
            if (_setting.Value.MinOrderValue.HasValue && _setting.Value.MinOrderValue.Value > checkoutVm.OrderTotal)
            {
                return false;
            }

            if (_setting.Value.MaxOrderValue.HasValue && _setting.Value.MaxOrderValue.Value < checkoutVm.OrderTotal)
            {
                return false;
            }

            return true;
        }

        private decimal CalculateFee(CheckoutVm chekoutVm)
        {
            var percent = _setting.Value.PaymentFee;
            return (chekoutVm.OrderTotal / 100) * percent;
        }
    }
}
