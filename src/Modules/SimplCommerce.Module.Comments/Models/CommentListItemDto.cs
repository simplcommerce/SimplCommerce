using System;

namespace SimplCommerce.Module.Comments.Models
{
    public class CommentListItemDto
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public string CommentText { get; set; }

        public string CommenterName { get; set; }

        public CommentStatus Status { get; set; }

        public DateTimeOffset CreatedOn { get; set; }

        public string EntityTypeId { get; set; }

        public long EntityId { get; set; }

        public string EntityName { get; set; }

        public long? ParentId { get; set; }

        public string EntitySlug { get; set; }
    }
}