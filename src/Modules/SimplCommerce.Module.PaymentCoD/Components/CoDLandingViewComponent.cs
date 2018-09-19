using Microsoft.AspNetCore.Mvc;

namespace SimplCommerce.Module.PaymentCoD.Components
{
    public class CoDLandingViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke() 
            => View();
    }
}
