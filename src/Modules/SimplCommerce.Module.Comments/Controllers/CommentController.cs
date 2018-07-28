using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Comments.Data;
using SimplCommerce.Module.Comments.Models;
using SimplCommerce.Module.Comments.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace SimplCommerce.Module.Comments.Controllers
{
    public class CommentController : Controller
    {
        private const int DefaultPageSize = 25;

        private readonly ICommentRepository _commentRepository;
        private readonly IWorkContext _workContext;

        public CommentController(ICommentRepository commentRepository, IWorkContext workContext)
        {
            _commentRepository = commentRepository;
            _workContext = workContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(CommentForm model)
        {
            if (ModelState.IsValid)
            {
                var user = await _workContext.GetCurrentUser();
                var review = new Comment
                {
                    CommentText = model.CommentText,
                    CommenterName = model.CommenterName,
                    EntityId = model.EntityId,
                    EntityTypeId = model.EntityTypeId,
                    UserId = user.Id
                };

                _commentRepository.Add(review);
                _commentRepository.SaveChanges();

                return PartialView("_CommentFormSuccess", model);
            }
            return PartialView("_CommentForm", model);
        }

        public async Task<IActionResult> List(long entityId, string entityTypeId, int? pageNumber, int? pageSize)
        {
            var entity = _commentRepository
                .List()
                .FirstOrDefault();

            if (entity == null)
            {
                return Redirect("~/Error/FindNotFound");
            }

            var itemsPerPage = pageSize.HasValue ? pageSize.Value : DefaultPageSize;
            var currentPageNum = pageNumber.HasValue ? pageNumber.Value : 1;
            var offset = (itemsPerPage * currentPageNum) - itemsPerPage;

            var model = new CommentVm();

            model.EntityName = entity.EntityName;
            model.EntitySlug = entity.EntitySlug;

            var query = _commentRepository
                .Query()
                .Where(x => (x.EntityId == entityId) && (x.EntityTypeId == entityTypeId) && (x.Status == CommentStatus.Approved))
                .OrderByDescending(x => x.CreatedOn)
                .Select(x => new CommentItem
                {
                    Id = x.Id,
                    CommentText = x.CommentText,
                    CommenterName = x.CommenterName,
                    CreatedOn = x.CreatedOn
                });

            model.Items.Data = await query
                .Skip(offset)
                .Take(itemsPerPage)
                .ToListAsync();

            model.Items.PageNumber = currentPageNum;
            model.Items.PageSize = itemsPerPage;
            model.Items.TotalItems = await query.CountAsync();

            var allItems = await query.ToListAsync();

            model.CommentsCount = allItems.Count;

            model.EntityId = entityId;
            model.EntityTypeId = entityTypeId;

            return View(model);
        }
    }
}