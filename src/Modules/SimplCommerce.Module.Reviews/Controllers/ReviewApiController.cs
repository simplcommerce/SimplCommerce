using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Reviews.Models;

namespace SimplCommerce.Module.Reviews.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/reviews")]
    public class ReviewApiController : Controller
    {
        private readonly IRepository<Review> _reviewRepository;

        public ReviewApiController(IRepository<Review> reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        [HttpGet]
        public ActionResult Get(int status, int numRecords)
        {
            var reviewStatus = (ReviewStatus) status;
            if ((numRecords <= 0) || (numRecords > 100))
            {
                numRecords = 5;
            }

            var model = _reviewRepository
                .Query()
                .Where(x => x.Status == reviewStatus)
                .OrderByDescending(x => x.CreatedOn)
                .Take(numRecords)
                .Select(x => new
                {
                    x.Id,
                    x.ReviewerName,
                    x.Rating,
                    x.Title,
                    x.Comment,
                    Status = x.Status.ToString(),
                    x.CreatedOn
                });

            return Json(model);
        }
    }
}