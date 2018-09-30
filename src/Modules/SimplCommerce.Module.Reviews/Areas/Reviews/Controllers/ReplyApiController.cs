using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimplCommerce.Infrastructure.Web.SmartTable;
using SimplCommerce.Module.Reviews.Data;
using SimplCommerce.Module.Reviews.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SimplCommerce.Module.Reviews.Controllers
{
    [Area("Reviews")]
    [Authorize(Roles = "admin")]
    [Route("api/review-replies")]
    public class ReplyApiController : Controller
    {
        private readonly IReplyRepository _replyRepository;
        private readonly IMediator _mediator;

        public ReplyApiController(IReplyRepository replyRepository, IMediator mediator)
        {
            _replyRepository = replyRepository;
            _mediator = mediator;
        }

        [HttpGet]
        public ActionResult Get(int status, int numRecords)
        {
            var replyStatus = (ReplyStatus)status;

            if ((numRecords <= 0) || (numRecords > 100))
            {
                numRecords = 5;
            }

            var model = _replyRepository
                .List()
                .Where(x => x.Status == replyStatus)
                .OrderByDescending(x => x.CreatedOn)
                .Take(numRecords)
                .Select(x => new
                {
                    x.Id,
                    x.ReplierName,
                    x.EntityName,
                    x.EntitySlug,
                    x.ReviewTitle,
                    x.Comment,
                    Status = x.Status.ToString(),
                    x.CreatedOn
                });

            return Json(model);
        }

        [HttpPost("grid")]
        public ActionResult List([FromBody] SmartTableParam param)
        {
            var query = _replyRepository.List();

            if (param.Search.PredicateObject != null)
            {
                dynamic search = param.Search.PredicateObject;

                if (search.EntityName != null)
                {
                    string entityName = search.EntityName;
                    query = query.Where(x => x.EntityName == entityName);
                }

                if (search.Status != null)
                {
                    var status = (ReplyStatus)search.Status;
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

            var replies = query.ToSmartTableResult(
                param,
                x => new
                {
                    x.Id,
                    x.ReplierName,
                    x.EntityName,
                    x.EntitySlug,
                    x.ReviewTitle,
                    x.Comment,
                    Status = x.Status.ToString(),
                    x.CreatedOn
                });

            return Json(replies);
        }

        [HttpPost("change-status/{id}")]
        public async Task<IActionResult> ChangeStatus(long id, [FromBody] int statusId)
        {
            var reply = _replyRepository.Query().FirstOrDefault(x => x.Id == id);

            if (reply == null)
            {
                return NotFound();
            }

            if (Enum.IsDefined(typeof(ReplyStatus), statusId))
            {
                reply.Status = (ReplyStatus)statusId;
                await _replyRepository.SaveChangesAsync();

                return Accepted();
            }

            return BadRequest(new { Error = "unsupported reply status" });
        }
    }
}
