using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Core.Models;

namespace SimplCommerce.Module.Core.Extensions
{
    public class UrlSlugRoute : IRouter
    {
        private readonly IRouter target;

        public UrlSlugRoute(IRouter target)
        {
            this.target = target;
        }

        public async Task RouteAsync(RouteContext context)
        {
            var requestPath = context.HttpContext.Request.Path.Value;

            if (!string.IsNullOrEmpty(requestPath) && requestPath[0] == '/')
            {
                // Trim the leading slash
                requestPath = requestPath.Substring(1);
            }

            var urlSlugRepository = context.HttpContext.RequestServices.GetService<IRepository<UrlSlug>>();

            // Get the slug that matches.
            var urlSlug = await urlSlugRepository.Query().FirstOrDefaultAsync(x => x.Slug == requestPath);

            // Invoke MVC controller/action
            var oldRouteData = context.RouteData;
            var newRouteData = new RouteData(oldRouteData);
            newRouteData.Routers.Add(target);

            // If we got back a null value set, that means the URI did not match)
            if (urlSlug == null)
            {
                return;
            }

            switch (urlSlug.EntityName)
            {
                case "Category":
                    newRouteData.Values["controller"] = "Category";
                    newRouteData.Values["action"] = "CategoryDetail";
                    newRouteData.Values["id"] = urlSlug.EntityId;
                    break;
                case "Product":
                    newRouteData.Values["controller"] = "Product";
                    newRouteData.Values["action"] = "ProductDetail";
                    newRouteData.Values["id"] = urlSlug.EntityId;
                    break;
                case "Page":
                    newRouteData.Values["controller"] = "Page";
                    newRouteData.Values["action"] = "PageDetail";
                    newRouteData.Values["id"] = urlSlug.EntityId;
                    break;
                case "Brand":
                    newRouteData.Values["controller"] = "Brand";
                    newRouteData.Values["action"] = "BrandDetail";
                    newRouteData.Values["id"] = urlSlug.EntityId;
                    break;
            }

            context.RouteData = newRouteData;
            await target.RouteAsync(context);
        }

        public VirtualPathData GetVirtualPath(VirtualPathContext context)
        {
            return null;
        }
    }
}
