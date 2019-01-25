using System;
using System.ComponentModel.DataAnnotations;

namespace SimplCommerce.Module.Core.Areas.Core.ViewModels
{
    public class WidgetFormBase
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public string Name { get; set; }

        public long WidgetZoneId { get; set; }

        public DateTimeOffset? PublishStart { get; set; }

        public DateTimeOffset? PublishEnd { get; set; }

        public int DisplayOrder { get; set; }
    }
}
