using System;

namespace SimplCommerce.Module.Reviews.Models
{
    public class ReviewListItemDto
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public string Title { get; set; }

        public string Comment { get; set; }

        public int Rating { get; set; }

        public string ReviewerName { get; set; }

        public ReviewStatus Status { get; set; }

        public DateTimeOffset CreatedOn { get; set; }

        public long EntityTypeId { get; set; }

        public long EntityId { get; set; }

        public string EntityName { get; set; }
    }
}