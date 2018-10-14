using cloudscribe.Pagination.Models;

namespace SimplCommerce.Module.Comments.Areas.Comments.ViewModels
{
    public class CommentVm
    {
        public long EntityId { get; set; }

        public string EntityTypeId { get; set; }

        public string EntityName { get; set; }

        public string EntitySlug { get; set; }

        public int CommentsCount { get; set; }

        public PagedResult<CommentItem> Items { get; set; } = new PagedResult<CommentItem>();
    }
}
