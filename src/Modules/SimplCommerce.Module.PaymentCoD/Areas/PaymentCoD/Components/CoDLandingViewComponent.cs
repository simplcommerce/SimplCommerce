using System;
using Microsoft.AspNetCore.Mvc;
using SimplCommerce.Infrastructure.Web;

namespace SimplCommerce.Module.PaymentCoD.Areas.PaymentCoD.Components
{
    public class CoDLandingViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(Guid checkoutId)
        {
            return View(this.GetViewPath(), checkoutId);
        }
    }
}
