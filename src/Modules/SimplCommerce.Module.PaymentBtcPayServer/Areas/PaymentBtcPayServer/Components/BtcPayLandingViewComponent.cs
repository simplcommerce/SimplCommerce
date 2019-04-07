using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Infrastructure.Web;
using SimplCommerce.Module.PaymentBtcPayServer.Areas.PaymentBtcPayServer.ViewModels;
using SimplCommerce.Module.PaymentBtcPayServer.Models;
using SimplCommerce.Module.Payments.Models;

namespace SimplCommerce.Module.PaymentBtcPayServer.Areas.PaymentBtcPayServer.Components
{
    public class BtcPayLandingViewComponent : ViewComponent
    {
        private readonly IRepositoryWithTypedId<PaymentProvider, string> _paymentProviderRepository;

        public BtcPayLandingViewComponent(IRepositoryWithTypedId<PaymentProvider, string> paymentProviderRepository)
        {
            _paymentProviderRepository = paymentProviderRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var btcPayServerPaymentProvider = await _paymentProviderRepository.Query()
                .FirstOrDefaultAsync(x => x.Id == PaymentProviderConstants.BtcPayServerProviderId);
            var config =
                JsonConvert.DeserializeObject<BtcPayServerConfig>(btcPayServerPaymentProvider.AdditionalSettings);
            var model = new BTCPayCheckoutForm
            {
                Server = config.Server,
                UseModal = config.UseModal,
                PaymentButtonLabel = config.PaymentButtonLabel
            };

            return View(this.GetViewPath(), model);
        }
    }
}
