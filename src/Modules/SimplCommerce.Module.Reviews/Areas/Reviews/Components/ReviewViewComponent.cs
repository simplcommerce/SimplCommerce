using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Infrastructure.Web;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Orders.Models;
using SimplCommerce.Module.Reviews.Areas.Reviews.ViewModels;
using SimplCommerce.Module.Reviews.Models;

namespace SimplCommerce.Module.Reviews.Areas.Reviews.Components
{
    public class ReviewViewComponent : ViewComponent
    {
        private readonly IRepository<Review> _reviewRepository;
        private readonly IWorkContext _workContext;
        private readonly IRepository<OrderItem> _orderItemRepository;

        public ReviewViewComponent(IRepository<Review> reviewRepository, IWorkContext workContext, IRepository<OrderItem> orderItemRepository )
        {
            _reviewRepository = reviewRepository;
            _workContext = workContext;
            _orderItemRepository = orderItemRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync(long entityId, string entityTypeId)
        {
            var model = new ReviewVm
            {
                EntityId = entityId,
                EntityTypeId = entityTypeId
            };

            model.Items.Data = await _reviewRepository
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
                }).ToListAsync();

            model.ReviewsCount = model.Items.Data.Count;
            model.Rating1Count = model.Items.Data.Count(x => x.Rating == 1);
            model.Rating2Count = model.Items.Data.Count(x => x.Rating == 2);
            model.Rating3Count = model.Items.Data.Count(x => x.Rating == 3);
            model.Rating4Count = model.Items.Data.Count(x => x.Rating == 4);
            model.Rating5Count = model.Items.Data.Count(x => x.Rating == 5);

            if (User.Identity.IsAuthenticated)
            {
                var user = await _workContext.GetCurrentUser();
                model.LoggedUserName = user.FullName;

                var query = _orderItemRepository.Query().Where(x => x.Order.CustomerId == user.Id && (x.Product.Id == entityId || x.Product.LinkedProductLinks.Any(i => i.Product.Id == entityId)));
                if(query.Count() > 0)
                {
                    model.HasBoughtProduct = true;
                }
                else
                {
                    model.HasBoughtProduct = false;
                }
            }
            else
            {
                model.LoggedUserName = string.Empty;
                model.HasBoughtProduct = false;
            }

            return View(this.GetViewPath(), model);
        }
    }
}

