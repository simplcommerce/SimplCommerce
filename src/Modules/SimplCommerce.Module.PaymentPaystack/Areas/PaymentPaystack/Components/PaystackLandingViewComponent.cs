using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Infrastructure.Web;
using SimplCommerce.Module.PaymentPaystack.Models;
using SimplCommerce.Module.PaymentPaystack.ViewModels;
using SimplCommerce.Module.Payments.Models;

namespace SimplCommerce.Module.PaymentPaystack.Areas.PaymentPaystack.Components
{
    public class PaystackLandingViewComponent : ViewComponent
    {
        private readonly IRepositoryWithTypedId<PaymentProvider, string> _paymentProviderRepository;

        public PaystackLandingViewComponent(IRepositoryWithTypedId<PaymentProvider, string> paymentProviderRepository)
        {
            _paymentProviderRepository = paymentProviderRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var paystackProvider = await _paymentProviderRepository.Query().FirstOrDefaultAsync(x => x.Id == PaymentProviderHelper.PaystackProviderId);
            var paystackSetting = JsonConvert.DeserializeObject<PaystackConfigForm>(paystackProvider.AdditionalSettings);

            var model = new PaystackCheckoutForm();
            model.PaymentFee = paystackSetting.PaymentFee;

            return View(this.GetViewPath(), model);
        }
    }
}
