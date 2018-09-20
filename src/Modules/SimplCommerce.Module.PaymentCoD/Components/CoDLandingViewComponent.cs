using Microsoft.AspNetCore.Mvc;
using static SimplCommerce.Infrastructure.Web.ViewComponentExtensions;

namespace SimplCommerce.Module.PaymentCoD.Components
{
    public class CoDLandingViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(this.GetViewPath());
        }
    }
}
