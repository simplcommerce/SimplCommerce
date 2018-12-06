using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Localization.Areas.Localization.ViewModel;

namespace SimplCommerce.Module.Localization.Areas.Localization.Views.Shared.Components.LanguageSwitcher
{
    public class LanguageSwitcherViewComponent : ViewComponent
    {
        private readonly IWorkContext _workContext;

        public LanguageSwitcherViewComponent(IWorkContext workContext)
        {
            _workContext = workContext;
        }

        public IViewComponentResult Invoke()
        {
            return View("Default", new LanguageSwitcherModel {
                CurrentUICulture = ViewContext.HttpContext.Features.Get<IRequestCultureFeature>().RequestCulture.UICulture.Name,
                SelectedCulture = _workContext.GetCurrentUser().Result.Culture
            });
        }
    }
}
