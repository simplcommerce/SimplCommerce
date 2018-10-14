using System;
using System.Collections.Generic;

namespace SimplCommerce.Module.Comments.Areas.Comments.ViewModels
{
    public class CommentItem
    {
        public long Id { get; set; }

        public string CommentText { get; set; }

        public string CommenterName { get; set; }

        public DateTimeOffset CreatedOn { get; set; }

        public IList<CommentItem> Replies { get; set; } = new List<CommentItem>();
    }
}
