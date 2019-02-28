using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SimplCommerce.Module.Comments.Areas.Comments.ViewModels;
using SimplCommerce.Module.Comments.Data;
using SimplCommerce.Module.Comments.Models;
using SimplCommerce.Module.Core.Extensions;

namespace SimplCommerce.Module.Comments.Areas.Comments.Controllers
{
    [Area("Comments")]
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("comments")]
    [Authorize]
    public class CommentController : Controller
    {
        private const int DefaultPageSize = 10;

        private readonly ICommentRepository _commentRepository;
        private readonly IWorkContext _workContext;
        private readonly bool _isCommentsRequireApproval;

        public CommentController(ICommentRepository commentRepository, IWorkContext workContext, IConfiguration config)
        {
            _commentRepository = commentRepository;
            _workContext = workContext;
            _isCommentsRequireApproval = config.GetValue<bool>("Product.IsCommentsRequireApproval");
        }

        public async Task<IActionResult> Get(long entityId, string entityTypeId, int page)
        {
            var itemsPerPage = DefaultPageSize;
            var offset = (itemsPerPage * page) - itemsPerPage;
            var query = _commentRepository.Query().Where(x => x.EntityId == entityId && x.EntityTypeId == entityTypeId && x.Parent == null);
            var totalItems = await query.CountAsync();
            var items = await query.OrderByDescending(x => x.CreatedOn).Select(x => new CommentItem
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
                                Id = r.Id,
                                CommentText = r.CommentText,
                                CommenterName = r.CommenterName,
                                CreatedOn = r.CreatedOn
                            })
            })
                .Skip(offset)
                .Take(itemsPerPage)
                .ToListAsync();

            return Ok(new { TotalItems = totalItems, Items = items });
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CommentForm model)
        {
            if (ModelState.IsValid)
            {
                var user = await _workContext.GetCurrentUser();
                var comment = new Comment
                {
                    ParentId = model.ParentId,
                    CommentText = model.CommentText,
                    CommenterName = user.FullName,
                    Status = _isCommentsRequireApproval ? CommentStatus.Pending : CommentStatus.Approved,
                    EntityId = model.EntityId,
                    EntityTypeId = model.EntityTypeId,
                    UserId = user.Id
                };

                _commentRepository.Add(comment);
                await _commentRepository.SaveChangesAsync();
                var commentItem = new CommentItem
                {
                    Id = comment.Id,
                    CommentText = comment.CommentText,
                    CommenterName = comment.CommenterName,
                    CreatedOn = comment.CreatedOn,
                };

                return Ok(commentItem);
            }

            return BadRequest(ModelState);
        }

    }
}
