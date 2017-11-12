using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Reviews.Models;
using SimplCommerce.Module.Reviews.ViewModels;

namespace SimplCommerce.Module.Reviews.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IRepository<Review> _reviewRepository;
        private readonly IWorkContext _workContext;

        public ReviewController(IRepository<Review> reviewRepository, IWorkContext workContext)
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
    }
}