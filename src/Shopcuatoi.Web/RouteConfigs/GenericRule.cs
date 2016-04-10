using System.Data.Entity;
using System.Threading.Tasks;
using Shopcuatoi.Core.Domain.Models;
using Shopcuatoi.Infrastructure.Domain.IRepositories;
using Microsoft.AspNet.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Practices.ServiceLocation;

namespace Shopcuatoi.Web.RouteConfigs
{
    public class GenericRule : IRouter
    {
        private readonly IRouter target;

        public GenericRule(IRouter target)
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
                    newRouteData.Values["controller"] = "Product";
                    newRouteData.Values["action"] = "ProductsByCategory";
                    newRouteData.Values["catSeoTitle"] = urlSlug.Slug;
                    break;
                case "Product":
                    newRouteData.Values["controller"] = "Product";
                    newRouteData.Values["action"] = "ProductDetail";
                    newRouteData.Values["seoTitle"] = urlSlug.Slug;
                    break;
                case "Page":
                    newRouteData.Values["controller"] = "Page";
                    newRouteData.Values["action"] = "PageDetail";
                    newRouteData.Values["id"] = urlSlug.EntityId;
                    break;
            }

            try
            {
                context.RouteData = newRouteData;
                await target.RouteAsync(context);
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