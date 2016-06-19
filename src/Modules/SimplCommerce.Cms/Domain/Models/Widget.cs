using System;
using SimplCommerce.Infrastructure.Domain.Models;

namespace SimplCommerce.Cms.Domain.Models
{
    public class Widget : Entity
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public string ViewComponentName { get; set; }

        public string CreateUrl { get; set; }

        public string EditUrl { get; set; }

        public string DeleteUrl { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsPublished { get; set; }
    }
}
