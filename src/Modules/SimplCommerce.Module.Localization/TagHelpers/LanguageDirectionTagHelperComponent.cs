using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Razor.TagHelpers;
using SimplCommerce.Module.Localization.Extensions;

namespace SimplCommerce.Module.Localization.TagHelpers
{
    public class LanguageDirectionTagHelperComponent : TagHelperComponent
    {
        const string LanguageDirectionAttribute = "dir";

        private readonly HttpContext _httpContext;

        public LanguageDirectionTagHelperComponent(IHttpContextAccessor httpContextAccessor)
        {
            _httpContext = httpContextAccessor.HttpContext;
        }

        public override int Order => 1;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (string.Equals(context.TagName, "body", StringComparison.Ordinal))
            {
                var languageDirection = _httpContext.Features.Get<IRequestCultureFeature>()
                    .RequestCulture.UICulture.GetLanguageDirection()
                    .ToString().ToLower();
                if (!output.Attributes.ContainsName(LanguageDirectionAttribute))
                {
                    output.Attributes.Add(LanguageDirectionAttribute, languageDirection);
                }
                else
                {
                    output.Attributes.SetAttribute(LanguageDirectionAttribute, languageDirection);
                }
            }
        }
    }
}