using Microsoft.AspNetCore.Mvc;

namespace SimplCommerce.Module.PaymentPaypalExpress.Components
{
    public class PaymentExpressLandingViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("/Modules/SimplCommerce.Module.PaymentPaypalExpress/Views/Components/PaymentExpressLanding.cshtml");
        }
    }
}
