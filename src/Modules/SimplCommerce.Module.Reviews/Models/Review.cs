using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SimplCommerce.Infrastructure.Models;
using SimplCommerce.Module.Core.Models;

namespace SimplCommerce.Module.Reviews.Models
{
    public class Review : EntityBase
    {
        public Review()
        {
            Status = ReviewStatus.Pending;
            CreatedOn = DateTimeOffset.Now;
        }

        public long UserId { get; set; }

        public User User { get; set; }

        [StringLength(450)]
        public string Title { get; set; }

        public string Comment { get; set; }

        public int Rating { get; set; }

        [StringLength(450)]
        public string ReviewerName { get; set; }

        public ReviewStatus Status { get; set; }

        public DateTimeOffset CreatedOn { get; set; }

        [StringLength(450)]
        public string EntityTypeId { get; set; }

        public long EntityId { get; set; }

        public IList<Reply> Replies { get; protected set; } = new List<Reply>();

    }
}
