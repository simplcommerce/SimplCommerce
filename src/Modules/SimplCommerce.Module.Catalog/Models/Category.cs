using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SimplCommerce.Infrastructure.Models;
using SimplCommerce.Module.Core.Models;

namespace SimplCommerce.Module.Catalog.Models
{
    public class Category : EntityBase
    {
        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(450)]
        public string Name { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(450)]
        public string Slug { get; set; }

        public string MetaTitle { get; set; }

        public string MetaKeywords { get; set; }

        public string MetaDescription { get; set; }

        public string Description { get; set; }

        public int DisplayOrder { get; set; }

        public bool IsPublished { get; set; }

        public bool IncludeInMenu { get; set; }

        public bool IsDeleted { get; set; }

        public long? ParentId { get; set; }

        public Category Parent { get; set; }

        public IList<Category> Children { get; protected set; } = new List<Category>();

        public Media ThumbnailImage { get; set; }
    }
}
