using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using SimplCommerce.Infrastructure;
using SimplCommerce.Module.Core.Extensions;

namespace SimplCommerce.Module.Localization.TagHelpers
{
    [HtmlTargetElement("language-switcher")]
    public class LanguageSwitcherTagHelper : TagHelper
    {
        private readonly IWorkContext _workContext;

        public LanguageSwitcherTagHelper(IWorkContext workContext)
        {
            _workContext = workContext;
        }

        [ViewContext, HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var uiCulture = ViewContext.HttpContext.Features.Get<IRequestCultureFeature>().RequestCulture.UICulture.Name;
            var selectedCulture = _workContext.GetCurrentUser().Result.Culture;

            output.TagName = null;
            output.Content.AppendHtml($@"<li class='nav-item dropdown'>
     <a href='#' class='nav-link dropdown-toggle' data-toggle='dropdown'>
        Language ({uiCulture})
        <span class='caret'></span>
    </a>
    <ul class='dropdown-menu lang-selector'>");
            foreach (var culture in GlobalConfiguration.Cultures)
            {
                output.Content.AppendHtml($@"<li class='dropdown-item'>
                <a href='#' data-value='{culture.Id}' onclick=""appendLanguageSwitcherCookie('{culture.Id}');"">{culture.Name}");
                if (culture.Id == selectedCulture)
                {
                    output.Content.AppendHtml("<span class='glyphicon glyphicon-ok' aria-hidden='true'></span>");
                }
                output.Content.AppendHtml(@"</a>
            </li>");
            }
            output.Content.AppendHtml(@"</ul>
</li>");
        }
    }
}
