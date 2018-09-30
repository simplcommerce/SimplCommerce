using Microsoft.AspNetCore.Mvc;
using SimplCommerce.Infrastructure.Web;

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
