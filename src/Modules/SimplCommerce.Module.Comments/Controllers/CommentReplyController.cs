using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Comments.ViewModels;
using System.Threading.Tasks;

namespace SimplCommerce.Module.Comments.Controllers
{
    public class CommentReplyController : Controller
    {
        private readonly IRepository<Models.Reply> _replyRepository;
        private readonly IWorkContext _workContext;

        public CommentReplyController(IRepository<Models.Reply> replyRepository, IWorkContext workContext)
        {
            _replyRepository = replyRepository;
            _workContext = workContext;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddReply(ReplyForm model)
        {
            if (ModelState.IsValid)
            {
                var user = await _workContext.GetCurrentUser();

                var reply = new Models.Reply
                {
                    CommentId = model.CommentId,
                    UserId = user.Id,
                    CommentText = model.Comment,
                    ReplierName = model.ReplierName,
                };

                _replyRepository.Add(reply);
                _replyRepository.SaveChanges();

                return PartialView("_ReplyFormSuccess", model);
            }

            return PartialView("_ReplyForm", model);
        }
    }
}