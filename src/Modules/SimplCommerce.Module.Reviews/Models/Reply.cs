using SimplCommerce.Infrastructure.Models;
using SimplCommerce.Module.Core.Models;
using System;

namespace SimplCommerce.Module.Reviews.Models
{
    public class Reply : EntityBase
    {
        public Reply()
        {
            Status = ReplyStatus.Pending;
            CreatedOn = DateTimeOffset.Now;
        }

        public long ReviewId { get; set; }

        public Review Review { get; set; }

        public long UserId { get; set; }

        public User User { get; set; }

        public string Comment { get; set; }

        public string ReplierName { get; set; }

        public ReplyStatus Status { get; set; }

        public DateTimeOffset CreatedOn { get; set; }
    }
}
