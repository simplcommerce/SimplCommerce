using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.PaymentIyzico.ViewModels;
using SimplCommerce.Module.Payments.Models;
using SimplCommerce.Module.ShoppingCart.Services;

namespace SimplCommerce.Module.PaymentIyzico.Components
{
    //PaypalExpressLandingViewComponent
    public class IyzicoLandingViewComponent : ViewComponent
    {
        private readonly ICartService _cartService;
        private readonly IWorkContext _workContext;
        private readonly IRepository<PaymentProvider> _paymentProviderRepository;

        public IyzicoLandingViewComponent(ICartService cartService, IWorkContext workContext, IRepository<PaymentProvider> paymentProviderRepository)
        {
            _cartService = cartService;
            _workContext = workContext;
            _paymentProviderRepository = paymentProviderRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var paymentProvider = await _paymentProviderRepository.Query().FirstOrDefaultAsync(f => f.Id == Models.PaymentProviderHelper.IyzicoProviderId);

            var model = new IyzicoCheckoutForm
            {
                Config = JsonConvert.DeserializeObject<IyzicoConfigForm>(paymentProvider.AdditionalSettings)
            };
            return View("/Modules/SimplCommerce.Module.PaymentIyzico/Views/Components/IyzicoLanding.cshtml", model);
        }
    }
}
