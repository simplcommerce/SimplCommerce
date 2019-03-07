using System;
using System.Collections.Generic;

namespace SimplCommerce.Module.Reviews.Areas.Reviews.ViewModels
{
    public class ReviewItem
    {
        public long Id { get; set; }

        public int Rating { get; set; }

        public string Title { get; set; }

        public string Comment { get; set; }

        public string ReviewerName { get; set; }

        public DateTimeOffset CreatedOn { get; set; }

        public IList<Reply> Replies { get; set; } = new List<Reply>();
    }
}
