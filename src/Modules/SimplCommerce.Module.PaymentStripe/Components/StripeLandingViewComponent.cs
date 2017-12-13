using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplCommerce.Module.PaymentStripe.Components
{
    public class StripeLandingViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("/Modules/SimplCommerce.Module.PaymentStripe/Views/Components/StripeLanding.cshtml");
        }
    }
}
