using Microsoft.AspNetCore.Mvc;
using SimplCommerce.Infrastructure.Web;
using SimplCommerce.Module.Comments.Areas.Comments.ViewModels;

namespace SimplCommerce.Module.Comments.Areas.Comments.Components
{
    public class CommentViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(long entityId, string entityTypeId)
        {

            var model = new CommentVm
            {
                EntityId = entityId,
                EntityTypeId = entityTypeId
            };

            return View(this.GetViewPath(), model);
        }
    }
}
