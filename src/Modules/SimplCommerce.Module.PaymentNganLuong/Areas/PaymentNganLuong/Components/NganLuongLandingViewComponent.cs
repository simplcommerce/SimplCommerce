using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Infrastructure.Web;
using SimplCommerce.Module.PaymentNganLuong.Models;
using SimplCommerce.Module.PaymentNganLuong.ViewModels;
using SimplCommerce.Module.Payments.Models;

namespace SimplCommerce.Module.PaymentNganLuong.Areas.PaymentNganLuong.Components
{
    public class NganLuongLandingViewComponent : ViewComponent
    {
        private readonly IRepositoryWithTypedId<PaymentProvider, string> _paymentProviderRepository;

        public NganLuongLandingViewComponent(IRepositoryWithTypedId<PaymentProvider, string> paymentProviderRepository)
        {
            _paymentProviderRepository = paymentProviderRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var nganLuongProvider = await _paymentProviderRepository.Query().FirstOrDefaultAsync(x => x.Id == PaymentProviderHelper.NganLuongPaymentProviderId);
            var nganLuongSetting = JsonConvert.DeserializeObject<NganLuongConfigForm>(nganLuongProvider.AdditionalSettings);

            return View(this.GetViewPath());
        }
    }
}
