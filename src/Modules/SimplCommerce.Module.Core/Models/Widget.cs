using System;
using System.ComponentModel.DataAnnotations;
using SimplCommerce.Infrastructure.Models;

namespace SimplCommerce.Module.Core.Models
{
    public class Widget : EntityBaseWithTypedId<string>
    {
        public Widget(string id)
        {
            Id = id;
            CreatedOn = DateTimeOffset.Now;
        }

        public string Code
        {
            get
            {
                return Id;
            }
        }

        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(450)]
        public string Name { get; set; }

        [StringLength(450)]
        public string ViewComponentName { get; set; }

        [StringLength(450)]
        public string CreateUrl { get; set; }

        [StringLength(450)]
        public string EditUrl { get; set; }

        public DateTimeOffset CreatedOn { get; set; }

        public bool IsPublished { get; set; }
    }
}
