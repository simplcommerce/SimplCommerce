using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace SimplCommerce.Module.Catalog.Areas.Catalog.ViewModels
{
    public class CategoryForm
    {
        public CategoryForm()
        {
            IsPublished = true;
        }

        public long Id { get; set; }

        [Required]
        public string Slug { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public string MetaTitle { get; set; }

        public string MetaKeywords { get; set; }

        public string MetaDescription { get; set; }

        public int DisplayOrder { get; set; }

        public long? ParentId { get; set; }

        public bool IncludeInMenu { get; set; }

        public bool IsPublished { get; set; }

        public IFormFile ThumbnailImage { get; set; }

        public string ThumbnailImageUrl { get; set; }
    }
}
