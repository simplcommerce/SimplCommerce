using System;
using System.Threading.Tasks;
using HvCommerce.Core.ApplicationServices;
using Microsoft.AspNet.Routing;

namespace HvCommerce.Web.RouteConfigs
{
    public class CategoryRoute : Attribute, ICategoryRoute
    {
        private readonly IRouter _target;
        private readonly ICategoryService _categoryService;

        public CategoryRoute(ICategoryService categoryService, IRouter target)
        {
            _categoryService = categoryService;
            _target = target;
        }

        public async Task RouteAsync(RouteContext context)
        {
            var requestPath = context.HttpContext.Request.Path.Value;

            if (!string.IsNullOrEmpty(requestPath) && requestPath[0] == '/')
            {
                // Trim the leading slash
                requestPath = requestPath.Substring(1);
            }

            //Invoke MVC controller/action
            var oldRouteData = context.RouteData;
            var newRouteData = new RouteData(oldRouteData);
            newRouteData.Routers.Add(this._target);

            var isExistCategory = await _categoryService.CheckExistBySeoTitle(requestPath);
            if (!isExistCategory)
            {
                return;
            }

            // TODO: (Idea) We might use objects from the database to get both the controller and action, 
            // and possibly even an area.
            // Alternatively, we could create a route for each table and hard-code
            // this information.
            newRouteData.Values["controller"] = "Product";
            newRouteData.Values["action"] = "ProductsByCategory";
            newRouteData.Values["catSeoTitle"] = requestPath;

            try
            {
                context.RouteData = newRouteData;
                await this._target.RouteAsync(context);
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
