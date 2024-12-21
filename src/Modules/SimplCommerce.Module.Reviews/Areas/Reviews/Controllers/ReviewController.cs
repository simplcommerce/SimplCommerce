using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Orders.Models;
using SimplCommerce.Module.Reviews.Areas.Reviews.ViewModels;
using SimplCommerce.Module.Reviews.Data;
using SimplCommerce.Module.Reviews.Models;

namespace SimplCommerce.Module.Reviews.Areas.Reviews.Controllers
{
    [Area("Reviews")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ReviewController : Controller
    {
        private const int DefaultPageSize = 25;

        private readonly IReviewRepository _reviewRepository;
        private readonly IRepository<Order> _orderRepository;
        private readonly IWorkContext _workContext;

        public ReviewController(
            IReviewRepository reviewRepository,
            IRepository<Order> orderRepository,
            IWorkContext workContext)
        {
            _reviewRepository = reviewRepository;
            _orderRepository = orderRepository;
            _workContext = workContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddReview(ReviewForm model)
        {
            if (ModelState.IsValid)
            {
                var user = await _workContext.GetCurrentUser();
                model.ReviewerName = user.FullName; // Otherwise ReviewerName is null

                if (!await _orderRepository.Query().AnyAsync(o => o.CustomerId == user.Id && o.OrderItems.Any(i => i.ProductId == model.EntityId)))
                {
                    ModelState.AddModelError("*", "You can only review products you have purchased.");

                    return PartialView("_ReviewForm", model);
                }

                var review = new Review
                {
                    Rating = model.Rating,
                    Title = model.Title,
                    Comment = model.Comment,
                    ReviewerName = user.FullName,
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
