using System.Linq;
using System.Threading.Tasks;
using HvCommerce.Core.ApplicationServices;
using Microsoft.AspNet.Routing;

namespace HvCommerce.Web.RouteConfigs
{
    public class GenericRule : IRouter
    {
        private readonly IRouter target;
        private readonly IUrlSlugService urlSlugService;

        public GenericRule(IRouter target, IUrlSlugService urlSlugService)
        {
            this.target = target;
            this.urlSlugService = urlSlugService;
        }

        public async Task RouteAsync(RouteContext context)
        {
            var requestPath = context.HttpContext.Request.Path.Value;

            if (!string.IsNullOrEmpty(requestPath) && requestPath[0] == '/')
            {
                // Trim the leading slash
                requestPath = requestPath.Substring(1);
            }

            // Get the slug that matches.
            var urlSlugs = await this.urlSlugService.Query();
            var urlSlug = urlSlugs.FirstOrDefault(x => x.Slug.Equals(requestPath));

            // Invoke MVC controller/action
            var oldRouteData = context.RouteData;
            var newRouteData = new RouteData(oldRouteData);
            newRouteData.Routers.Add(this.target);

            // If we got back a null value set, that means the URI did not match)
            if (urlSlug == null)
            {
                return;
            }

            switch (urlSlug.EntityName)
            {
                case "Category":
                    newRouteData.Values["controller"] = "Product";
                    newRouteData.Values["action"] = "ProductsByCategory";
                    newRouteData.Values["catSeoTitle"] = urlSlug.Slug;
                    break;
                case "Product":
                    newRouteData.Values["controller"] = "Product";
                    newRouteData.Values["action"] = "ProductDetail";
                    newRouteData.Values["seoTitle"] = urlSlug.Slug;
                    break;
            }

            try
            {
                context.RouteData = newRouteData;
                await this.target.RouteAsync(context);
            }
            finally
            {
                if (!context.IsHandled)
                {
                    context.RouteData = oldRouteData;
                }
            }
        }

        public VirtualPathData GetVirtualPath(VirtualPathContext context)
        {
            return null;
        }
    }
}
