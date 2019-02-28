using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Infrastructure.Web;
using SimplCommerce.Module.Comments.Areas.Comments.ViewModels;
using SimplCommerce.Module.Core.Models;

namespace SimplCommerce.Module.Comments.Areas.Comments.Components
{
    public class CommentViewComponent : ViewComponent
    {
        private readonly IRepository<Entity> _entityRepository;

        public CommentViewComponent(IRepository<Entity> entityRepository)
        {
            _entityRepository = entityRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync(long entityId, string entityTypeId)
        {

            var entity = await _entityRepository.Query().FirstOrDefaultAsync(x => x.EntityId == entityId && x.EntityTypeId == entityTypeId);
            var model = new CommentVm
            {
                EntityId = entityId,
                EntityTypeId = entityTypeId
            };

            return View(this.GetViewPath(), model);
        }
    }
}
