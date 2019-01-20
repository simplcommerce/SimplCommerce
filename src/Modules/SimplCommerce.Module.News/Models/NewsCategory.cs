using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SimplCommerce.Infrastructure.Models;

namespace SimplCommerce.Module.News.Models
{
    public class NewsCategory : EntityBase
    {
        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(450)]
        public string Name { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(450)]
        public string Slug { get; set; }

        [StringLength(450)]
        public string MetaTitle { get; set; }

        [StringLength(450)]
        public string MetaKeywords { get; set; }

        public string MetaDescription { get; set; }

        public string Description { get; set; }

        public int DisplayOrder { get; set; }

        public bool IsPublished { get; set; }

        public bool IsDeleted { get; set; }

        public IList<NewsItemCategory> NewsItems { get; set; } = new List<NewsItemCategory>();
    }
}
