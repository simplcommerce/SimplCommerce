using System;
using System.Linq;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimplCommerce.Infrastructure.Web.SmartTable;
using SimplCommerce.Module.Core.Events;
using SimplCommerce.Module.Reviews.Data;
using SimplCommerce.Module.Reviews.Models;

namespace SimplCommerce.Module.Reviews.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/reviews")]
    public class ReviewApiController : Controller
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMediator _mediator;

        public ReviewApiController(IReviewRepository reviewRepository, IMediator mediator)
        {
            _reviewRepository = reviewRepository;
            _mediator = mediator;
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
                .List()
                .Where(x => x.Status == reviewStatus)
                .OrderByDescending(x => x.CreatedOn)
                .Take(numRecords)
                .Select(x => new
                {
                    x.Id,
                    x.ReviewerName,
                    x.EntityName,
                    x.EntitySlug,
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
                        query = query.Where(x => x.CreatedOn <= before);
                    }

                    if (search.CreatedOn.after != null)
                    {
                        DateTimeOffset after = search.CreatedOn.after;
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
                    x.EntitySlug,
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
                _reviewRepository.SaveChanges();

                var rattings = _reviewRepository.Query()
                    .Where(x => x.EntityId == review.EntityId && x.EntityTypeId == review.EntityTypeId && x.Status == ReviewStatus.Approved);

                var reviewSummary = new ReviewSummaryChanged
                {
                    EntityId = review.EntityId,
                    EntityTypeId = review.EntityTypeId,
                    ReviewsCount = rattings.Count()
                };
                if (reviewSummary.ReviewsCount == 0)
                {
                    reviewSummary.RatingAverage = null;
                }
                else
                {
                    var grouped = rattings.GroupBy(x => x.Rating).Select(x => new { Rating = x.Key, Count = x.Count() });
                    reviewSummary.RatingAverage = grouped.Select(x => x.Rating * x.Count).Sum() / (double)reviewSummary.ReviewsCount;
                }

                _mediator.Publish(reviewSummary);
                _reviewRepository.SaveChanges();
                return Ok();
            }
            return BadRequest(new {Error = "unsupported order status"});
        }
    }
}