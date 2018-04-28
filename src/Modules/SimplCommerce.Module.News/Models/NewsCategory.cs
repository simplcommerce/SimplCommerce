using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SimplCommerce.Infrastructure.Models;

namespace SimplCommerce.Module.News.Models
{
    public class NewsCategory : EntityBase
    {
        public string Name { get; set; }

        public string Slug { get; set; }

        public string MetaTitle { get; set; }

        public string MetaKeywords { get; set; }

        public string MetaDescription { get; set; }

        [StringLength(5000)]
        public string Description { get; set; }

        public int DisplayOrder { get; set; }

        public bool IsPublished { get; set; }

        public bool IsDeleted { get; set; }

        public IList<NewsItemCategory> NewsItems { get; set; } = new List<NewsItemCategory>();
    }
}
