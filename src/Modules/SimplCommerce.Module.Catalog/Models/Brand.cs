using System.ComponentModel.DataAnnotations;
using SimplCommerce.Infrastructure.Models;

namespace SimplCommerce.Module.Catalog.Models
{
    public class Brand : EntityBase
    {
        public string Name { get; set; }

        public string Slug { get; set; }

        [StringLength(5000)]
        public string Description { get; set; }

        public bool IsPublished { get; set; }

        public bool IsDeleted { get; set; }
    }
}
