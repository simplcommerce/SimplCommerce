using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Reviews.Data;
using SimplCommerce.Module.Reviews.Models;
using SimplCommerce.Module.Reviews.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace SimplCommerce.Module.Reviews.Controllers
{
    public class ReviewController : Controller
    {
        private const int DefaultPageSize = 25;

        private readonly IReviewRepository _reviewRepository;
        private readonly IWorkContext _workContext;

        public ReviewController(IReviewRepository reviewRepository, IWorkContext workContext)
        {
            _reviewRepository = reviewRepository;
            _workContext = workContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddReview(ReviewForm model)
        {
            if (ModelState.IsValid)
            {
                var user = await _workContext.GetCurrentUser();
                var review = new Review
                {
                    Rating = model.Rating,
                    Title = model.Title,
                    Comment = model.Comment,
                    ReviewerName = model.ReviewerName,
                    EntityId = model.EntityId,
                    EntityTypeId = model.EntityTypeId,
                    UserId = user.Id,
                };

                _reviewRepository.Add(review);
                _reviewRepository.SaveChanges();

                return PartialView("_ReviewFormSuccess", model);
            }
            return PartialView("_ReviewForm", model);
        }

        public async Task<IActionResult> List(long entityId, string entityTypeId, int? pageNumber, int? pageSize)
        {
            var entity = _reviewRepository
                .List()
                .FirstOrDefault();

            if (entity == null)
            {
                return Redirect("~/Error/FindNotFound");
            }

            var itemsPerPage = pageSize.HasValue ? pageSize.Value : DefaultPageSize;
            var currentPageNum = pageNumber.HasValue ? pageNumber.Value : 1;
            var offset = (itemsPerPage * currentPageNum) - itemsPerPage;

            var model = new ReviewVm();

            model.EntityName = entity.EntityName;
            model.EntitySlug = entity.EntitySlug;

            var query = _reviewRepository
                .Query()
                .Where(x => (x.EntityId == entityId) && (x.EntityTypeId == entityTypeId) && (x.Status == ReviewStatus.Approved))
                .OrderByDescending(x => x.CreatedOn)
                .Select(x => new ReviewItem
                {
                    Id = x.Id,
                    Title = x.Title,
                    Rating = x.Rating,
                    Comment = x.Comment,
                    ReviewerName = x.ReviewerName,
                    CreatedOn = x.CreatedOn,
                    Replies = x.Replies
                        .Where(r => r.Status == ReplyStatus.Approved)
                        .OrderByDescending(r => r.CreatedOn)
                        .Select(r => new ViewModels.Reply
                        {
                            Comment = r.Comment,
                            ReplierName = r.ReplierName,
                            CreatedOn = r.CreatedOn
                        })
                        .ToList()
                });

            model.Items.Data = await query
                .Skip(offset)
                .Take(itemsPerPage)
                .ToListAsync();

            model.Items.PageNumber = currentPageNum;
            model.Items.PageSize = itemsPerPage;
            model.Items.TotalItems = await query.CountAsync();

            var allItems = await query.ToListAsync();

            model.ReviewsCount = allItems.Count;
            model.Rating1Count = allItems.Count(x => x.Rating == 1);
            model.Rating2Count = allItems.Count(x => x.Rating == 2);
            model.Rating3Count = allItems.Count(x => x.Rating == 3);
            model.Rating4Count = allItems.Count(x => x.Rating == 4);
            model.Rating5Count = allItems.Count(x => x.Rating == 5);

            model.EntityId = entityId;
            model.EntityTypeId = entityTypeId;

            return View(model);
        }
    }
}