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
        private readonly IRepository<Order> _orderRepository;

        public ReviewViewComponent(IRepository<Review> reviewRepository, IWorkContext workContext, IRepository<Order> orderRepository )
        {
            _reviewRepository = reviewRepository;
            _workContext = workContext;
            _orderRepository = orderRepository;
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
                var currentUserOrder = _orderRepository
                    .Query()
                    .Where(x => x.CreatedById == user.Id);

                var userOrderedProduct = currentUserOrder
                    .Where(x => x.OrderItems.Where(y =>y.ProductId == entityId).Count() > 0);
                 model.HasBoughtProduct = userOrderedProduct.Any() ? true : false;
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

