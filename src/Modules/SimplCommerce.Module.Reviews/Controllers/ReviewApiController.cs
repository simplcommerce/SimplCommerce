using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimplCommerce.Infrastructure.Web.SmartTable;
using SimplCommerce.Module.Reviews.Data;
using SimplCommerce.Module.Reviews.Models;

namespace SimplCommerce.Module.Reviews.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/reviews")]
    public class ReviewApiController : Controller
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewApiController(IReviewRepository reviewRepository)
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

        [HttpPost("grid")]
        public ActionResult List([FromBody] SmartTableParam param)
        {
            var query = _reviewRepository.List();

            if (param.Search.PredicateObject != null)
            {
                dynamic search = param.Search.PredicateObject;
                if (search.Id != null)
                {
                    long id = search.Id;
                    query = query.Where(x => x.Id == id);
                }

                if (search.EntityName != null)
                {
                    string entityName = search.EntityName;
                    query = query.Where(x => x.EntityName == entityName);
                }

                if (search.Status != null)
                {
                    var status = (ReviewStatus) search.Status;
                    query = query.Where(x => x.Status == status);
                }

                if (search.CreatedOn != null)
                {
                    if (search.CreatedOn.before != null)
                    {
                        DateTimeOffset before = search.CreatedOn.before;
                        before = before.Date.AddDays(1);
                        query = query.Where(x => x.CreatedOn <= before);
                    }

                    if (search.CreatedOn.after != null)
                    {
                        DateTimeOffset after = search.CreatedOn.after;
                        after = after.Date;
                        query = query.Where(x => x.CreatedOn >= after);
                    }
                }
            }

            var reviews = query.ToSmartTableResult(
                param,
                x => new
                {
                    x.Id,
                    x.ReviewerName,
                    x.Rating,
                    x.Title,
                    x.Comment,
                    x.EntityName,
                    Status = x.Status.ToString(),
                    x.CreatedOn
                });

            return Json(reviews);
        }

        [HttpPost("change-status/{id}")]
        public IActionResult ChangeStatus(long id, [FromBody] int statusId)
        {
            var review = _reviewRepository.Query().FirstOrDefault(x => x.Id == id);
            if (review == null)
            {
                return NotFound();
            }

            if (Enum.IsDefined(typeof(ReviewStatus), statusId))
            {
                review.Status = (ReviewStatus) statusId;
                _reviewRepository.SaveChange();
                return Ok();
            }
            return BadRequest(new {Error = "unsupported order status"});
        }
    }
}