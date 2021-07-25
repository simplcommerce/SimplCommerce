using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SimplCommerce.Infrastructure.Web
{
    public class ThemeableViewLocationExpander : IViewLocationExpander
    {
        private const string THEME_KEY = "theme";

        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context,
            IEnumerable<string> viewLocations)
        {
            context.Values.TryGetValue(THEME_KEY, out var theme);

            if (!string.IsNullOrWhiteSpace(theme) &&
                !string.Equals(theme, "Generic", StringComparison.InvariantCultureIgnoreCase))
            {
                var moduleViewLocations = new[]
                {
                    $"/Themes/{theme}/Areas/{{2}}/Views/{{1}}/{{0}}.cshtml",
                    $"/Themes/{theme}/Areas/{{2}}/Views/Shared/{{0}}.cshtml",
                    $"/Themes/{theme}/Views/{{1}}/{{0}}.cshtml", $"/Themes/{theme}/Views/Shared/{{0}}.cshtml"
                };

                viewLocations = moduleViewLocations.Concat(viewLocations);
            }

            return viewLocations;
        }

        public void PopulateValues(ViewLocationExpanderContext context)
        {
            var controllerName = context.ActionContext.ActionDescriptor.DisplayName;
            if (controllerName == null) // in case of render view to string
            {
                return;
            }

            context.ActionContext.HttpContext.Request.Cookies.TryGetValue("theme", out var previewingTheme);
            if (!string.IsNullOrWhiteSpace(previewingTheme))
            {
                context.Values[THEME_KEY] = previewingTheme;
            }
            else
            {
                var config = context.ActionContext.HttpContext.RequestServices.GetService<IConfiguration>();
                context.Values[THEME_KEY] = config["Theme"];
            }
        }
    }
}
