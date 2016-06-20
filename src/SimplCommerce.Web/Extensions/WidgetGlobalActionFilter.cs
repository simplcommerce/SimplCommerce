using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Cms.Domain.Models;
using SimplCommerce.Infrastructure.Domain.IRepositories;

namespace SimplCommerce.Web.Extensions
{
    public class WidgetGlobalActionFilter : IActionFilter
    {
        private IRepository<WidgetInstance> _widgetInstanceRepository;

        public WidgetGlobalActionFilter(IRepository<WidgetInstance> widgetInstanceRepository)
        {
            _widgetInstanceRepository = widgetInstanceRepository;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            var viewResult = context.Result as ViewResult;
            if(viewResult == null)
            {
                return;
            }

            var widgetInstances = _widgetInstanceRepository.Query()
                .Include(x => x.WidgetProperties)
                .Include(x => x.Widget).ToList();

            viewResult.ViewData["WidgetInstances"] = widgetInstances;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            
        }
    }
}
