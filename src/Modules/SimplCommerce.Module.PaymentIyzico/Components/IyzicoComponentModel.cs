using Microsoft.AspNetCore.Mvc;

namespace SimplCommerce.Module.PaymentIyzico.Components
{
    public class IyzicoComponentModel: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("/Modules/SimplCommerce.Module.PaymentIyzico/Views/Components/IyzicoLanding.cshtml");
        }
    }
}
