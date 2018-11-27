using System;

namespace SimplCommerce.Module.Reviews.Areas.Reviews.ViewModels
{
    public class Reply
    {
        public string Comment { get; set; }

        public string ReplierName { get; set; }

        public DateTimeOffset CreatedOn { get; set; }
    }
}
