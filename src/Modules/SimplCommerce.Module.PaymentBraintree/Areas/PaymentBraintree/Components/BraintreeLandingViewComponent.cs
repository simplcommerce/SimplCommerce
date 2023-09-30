using System;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Infrastructure.Helpers;
using SimplCommerce.Infrastructure.Web;
using SimplCommerce.Module.Checkouts.Services;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Core.Services;
using SimplCommerce.Module.PaymentBraintree.Areas.PaymentBraintree.ViewModels;
using SimplCommerce.Module.PaymentBraintree.Models;
using SimplCommerce.Module.PaymentBraintree.Services;
using SimplCommerce.Module.Payments.Models;
using SimplCommerce.Module.ShoppingCart.Services;

namespace SimplCommerce.Module.PaymentBraintree.Areas.PaymentBraintree.Components
{
    public class BraintreeLandingViewComponent : ViewComponent
    {
        private readonly ICheckoutService _checkoutService;
        private readonly IWorkContext _workContext;
        private readonly IRepositoryWithTypedId<PaymentProvider, string> _paymentProviderRepository;
        private readonly IBraintreeConfiguration _braintreeConfiguration;
        private readonly ICurrencyService _currencyService;

        public BraintreeLandingViewComponent(
            ICheckoutService checkoutService, 
            IWorkContext workContext, 
            IRepositoryWithTypedId<PaymentProvider, string> paymentProviderRepository,
            IBraintreeConfiguration braintreeConfiguration,
            ICurrencyService currencyService)
        {
            _checkoutService = checkoutService;
            _workContext = workContext;
            _paymentProviderRepository = paymentProviderRepository;
            _braintreeConfiguration = braintreeConfiguration;
            _currencyService = currencyService;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid checkoutId)
        {
            var stripeProvider = await _paymentProviderRepository.Query().FirstOrDefaultAsync(x => x.Id == PaymentProviderHelper.BraintreeProviderId);
            var stripeSetting = JsonConvert.DeserializeObject<BraintreeConfigForm>(stripeProvider.AdditionalSettings);
            var curentUser = await _workContext.GetCurrentUser();
            var cart = await _checkoutService.GetCheckoutDetails(checkoutId);
            var zeroDecimalAmount = cart.OrderTotal;
            if (!CurrencyHelper.IsZeroDecimalCurrencies(_currencyService.CurrencyCulture))
            {
                zeroDecimalAmount = zeroDecimalAmount * 100;
            }

            var regionInfo = new RegionInfo(_currencyService.CurrencyCulture.LCID);
            var model = new BraintreeCheckoutForm
            {
                ClientToken = await _braintreeConfiguration.GetClientToken(),
                Amount = zeroDecimalAmount,
                ISOCurrencyCode = regionInfo.ISOCurrencySymbol
            };

            return View(this.GetViewPath(), model);
        }
    }
}
