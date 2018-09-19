using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.PaymentPaypalExpress.Models;
using SimplCommerce.Module.PaymentPaypalExpress.ViewModels;
using SimplCommerce.Module.Payments.Models;
using System.Threading.Tasks;

namespace SimplCommerce.Module.PaymentPaypalExpress.Components
{
    public class PaypalExpressLandingViewComponent : ViewComponent
    {
        private readonly IRepositoryWithTypedId<PaymentProvider, string> _paymentProviderRepository;

        public PaypalExpressLandingViewComponent(IRepositoryWithTypedId<PaymentProvider, string> paymentProviderRepository) 
            => _paymentProviderRepository = paymentProviderRepository;

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var paypalExpressProvider = await _paymentProviderRepository.Query().FirstOrDefaultAsync(x => x.Id == PaymentProviderHelper.PaypalExpressProviderId);
            var paypalExpressSetting = JsonConvert.DeserializeObject<PaypalExpressConfigForm>(paypalExpressProvider.AdditionalSettings);

            var model = new PaypalExpressCheckoutForm();
            model.Environment = paypalExpressSetting.Environment;
            model.PaymentFee = paypalExpressSetting.PaymentFee;

            return View(model);
        }
    }
}
