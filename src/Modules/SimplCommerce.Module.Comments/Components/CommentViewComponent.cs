using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Infrastructure.Web;
using SimplCommerce.Module.Comments.Models;
using SimplCommerce.Module.Comments.ViewModels;

namespace SimplCommerce.Module.Comments.Components
{
    public class CommentViewComponent : ViewComponent
    {
        private readonly IRepository<Comment> _commentRepository;

        public CommentViewComponent(IRepository<Comment> commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync(long entityId, string entityTypeId)
        {
            var model = new CommentVm
            {
                EntityId = entityId,
                EntityTypeId = entityTypeId
            };

            model.Items.Data = await _commentRepository
                .Query()
                .Where(x => (x.EntityId == entityId) && (x.EntityTypeId == entityTypeId) && (x.Status == CommentStatus.Approved))
                .Where(x => x.ParentId == null)
                .OrderByDescending(x => x.CreatedOn)
                .Select(x => new CommentItem
                {
                    Id = x.Id,
                    CommentText = x.CommentText,
                    CommenterName = x.CommenterName,
                    CreatedOn = x.CreatedOn,
                    Replies = x.Replies
                        .Where(r => r.Status == CommentStatus.Approved)
                        .OrderByDescending(r => r.CreatedOn)
                        .Select(r => new CommentItem()
                        {
                            CommentText = r.CommentText,
                            CommenterName = r.CommenterName,
                            CreatedOn = r.CreatedOn
                        })
                        .ToList()
                }).ToListAsync();

            model.CommentsCount = model.Items.Data.Count;

            return View(this.GetViewPath(), model);
        }
    }
}
