using SimplCommerce.Infrastructure.Models;
using SimplCommerce.Module.Core.Models;
using System;

namespace SimplCommerce.Module.Comments.Models
{
    public class Reply : EntityBase
    {
        public Reply()
        {
            Status = ReplyStatus.Pending;
            CreatedOn = DateTimeOffset.Now;
        }

        public long CommentId { get; set; }

        public Comment Comment { get; set; }

        public long UserId { get; set; }

        public User User { get; set; }

        public string CommentText { get; set; }

        public string ReplierName { get; set; }

        public ReplyStatus Status { get; set; }

        public DateTimeOffset CreatedOn { get; set; }
    }
}
