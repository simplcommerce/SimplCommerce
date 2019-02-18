using System.Threading.Tasks;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using SimplCommerce.Infrastructure.Web;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Localization.Areas.Localization.ViewModel;

namespace SimplCommerce.Module.Localization.Areas.Localization.Components
{
    public class LanguageSwitcherViewComponent : ViewComponent
    {
        private readonly IWorkContext _workContext;

        public LanguageSwitcherViewComponent(IWorkContext workContext)
        {
            _workContext = workContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            return View(this.GetViewPath(), new LanguageSwitcherModel
            {
                CurrentUICulture = ViewContext.HttpContext.Features.Get<IRequestCultureFeature>().RequestCulture.UICulture.Name,
                UserSelectedCulture = (await _workContext.GetCurrentUser()).Culture
            });
        }
    }
}
