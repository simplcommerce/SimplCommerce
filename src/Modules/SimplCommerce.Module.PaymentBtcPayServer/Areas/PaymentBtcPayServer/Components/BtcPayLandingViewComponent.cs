using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Infrastructure.Web;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.PaymentBtcPayServer.Areas.PaymentBtcPayServer.ViewModels;
using SimplCommerce.Module.PaymentBtcPayServer.Models;
using SimplCommerce.Module.PaymentBtcPayServer.Services;
using SimplCommerce.Module.Payments.Models;
using SimplCommerce.Module.ShoppingCart.Services;

namespace SimplCommerce.Module.PaymentBtcPayServer.Areas.PaymentBtcPayServer.Components
{
    public class BtcPayLandingViewComponent : ViewComponent
    {
        private readonly ICartService _cartService;
        private readonly IWorkContext _workContext;
        private readonly IRepositoryWithTypedId<PaymentProvider, string> _paymentProviderRepository;
        private readonly IBtcPayServerClientService _btcPayServerClientService;

        public BtcPayLandingViewComponent(ICartService cartService,
            IWorkContext workContext,
            IRepositoryWithTypedId<PaymentProvider, string> paymentProviderRepository,
            BtcPayServerClientService btcPayServerClientService)
        {
            _cartService = cartService;
            _workContext = workContext;
            _paymentProviderRepository = paymentProviderRepository;
            _btcPayServerClientService = btcPayServerClientService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var btcPayServerPaymentProvider = await _paymentProviderRepository.Query()
                .FirstOrDefaultAsync(x => x.Id == PaymentProviderConstants.BtcPayServerProviderId);
            var config =
                JsonConvert.DeserializeObject<BtcPayServerConfig>(btcPayServerPaymentProvider.AdditionalSettings);
            var curentUser = await _workContext.GetCurrentUser();
            var cart = await _cartService.GetActiveCartDetails(curentUser.Id);
            
            var regionInfo = new RegionInfo(CultureInfo.CurrentCulture.LCID);
            var model = new BTCPayCheckoutForm
            {
                Server = config.Server,
                Amount = cart.OrderTotal,
                ISOCurrencyCode = regionInfo.ISOCurrencySymbol
            };

            return View(this.GetViewPath(), model);
        }
    }
}
