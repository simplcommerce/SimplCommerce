using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Infrastructure.Web;
using SimplCommerce.Module.PaymentPaypalExpress.Models;
using SimplCommerce.Module.PaymentPaypalExpress.ViewModels;
using SimplCommerce.Module.Payments.Models;

namespace SimplCommerce.Module.PaymentPaypalExpress.Areas.PaymentPaypalExpress.Components
{
    public class PaypalExpressLandingViewComponent : ViewComponent
    {
        private readonly IRepositoryWithTypedId<PaymentProvider, string> _paymentProviderRepository;

        public PaypalExpressLandingViewComponent(IRepositoryWithTypedId<PaymentProvider, string> paymentProviderRepository)
        {
            _paymentProviderRepository = paymentProviderRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid checkoutId)
        {
            var paypalExpressProvider = await _paymentProviderRepository.Query().FirstOrDefaultAsync(x => x.Id == PaymentProviderHelper.PaypalExpressProviderId);
            var paypalExpressSetting = JsonConvert.DeserializeObject<PaypalExpressConfigForm>(paypalExpressProvider.AdditionalSettings);

            var model = new PaypalExpressCheckoutForm();
            model.Environment = paypalExpressSetting.Environment;
            model.PaymentFee = paypalExpressSetting.PaymentFee;
            model.CheckoutId = checkoutId;

            return View(this.GetViewPath(), model);
        }
    }
}
