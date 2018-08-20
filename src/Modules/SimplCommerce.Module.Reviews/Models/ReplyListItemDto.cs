using System;

namespace SimplCommerce.Module.Reviews.Models
{
    public class ReplyListItemDto
    {
        public long Id { get; set; }

        public string Comment { get; set; }

        public string ReplierName { get; set; }

        public ReplyStatus Status { get; set; }

        public DateTimeOffset CreatedOn { get; set; }

        public string ReviewTitle { get; set; }

        public string EntityName { get; set; }

        public string EntitySlug { get; set; }
    }
}
