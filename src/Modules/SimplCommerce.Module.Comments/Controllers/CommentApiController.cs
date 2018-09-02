using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimplCommerce.Infrastructure.Web.SmartTable;
using SimplCommerce.Module.Core.Events;
using SimplCommerce.Module.Comments.Data;
using SimplCommerce.Module.Comments.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SimplCommerce.Module.Comments.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/comments")]
    public class CommentApiController : Controller
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMediator _mediator;

        public CommentApiController(ICommentRepository commentRepository, IMediator mediator)
        {
            _commentRepository = commentRepository;
            _mediator = mediator;
        }

        [HttpGet]
        public ActionResult Get(int status, int numRecords)
        {
            var reviewStatus = (CommentStatus) status;
            if ((numRecords <= 0) || (numRecords > 100))
            {
                numRecords = 5;
            }

            var model = _commentRepository
                .List()
                .Where(x => x.Status == reviewStatus)
                .OrderByDescending(x => x.CreatedOn)
                .Take(numRecords)
                .Select(x => new
                {
                    x.Id,
                    x.CommenterName,
                    x.EntityName,
                    x.EntitySlug,
                    x.CommentText,
                    x.ParentId,
                    Status = x.Status.ToString(),
                    x.CreatedOn
                });

            return Json(model);
        }

        [HttpPost("grid")]
        public ActionResult List([FromBody] SmartTableParam param)
        {
            var query = _commentRepository.List();

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
                    var status = (CommentStatus) search.Status;
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

            var comments = query.ToSmartTableResult(
                param,
                x => new
                {
                    x.Id,
                    x.CommenterName,
                    x.CommentText,
                    x.EntityName,
                    x.EntitySlug,
                    x.ParentId,
                    Type = x.ParentId == null ? "Comment" : "Reply",
                    Status = x.Status.ToString(),
                    x.CreatedOn
                });

            return Json(comments);
        }

        [HttpPost("change-status/{id}")]
        public async Task<IActionResult> ChangeStatus(long id, [FromBody] int statusId)
        {
            var comment = _commentRepository.Query().FirstOrDefault(x => x.Id == id);
            if (comment == null)
            {
                return NotFound();
            }

            if (Enum.IsDefined(typeof(CommentStatus), statusId))
            {
                comment.Status = (CommentStatus) statusId;
                _commentRepository.SaveChanges();

                await _commentRepository.SaveChangesAsync();
                return Accepted();
            }
            return BadRequest(new {Error = "unsupported order status"});
        }
    }
}