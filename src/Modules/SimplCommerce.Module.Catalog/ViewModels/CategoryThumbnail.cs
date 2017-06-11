using SimplCommerce.Module.Catalog.Models;
using SimplCommerce.Module.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplCommerce.Module.Catalog.ViewModels
{
    public class CategoryThumbnail
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string SeoTitle { get; set; }

        public string Description { get; set; }

        public Media ThumbnailImage { get; set; }

        public string ThumbnailUrl { get; set; }

        public static CategoryThumbnail FromCategory(Category category)
        {
            var result = new CategoryThumbnail() {
                Id = category.Id,
                Name = category.Name,
                SeoTitle = category.SeoTitle,
                Description = category.Description,
                ThumbnailImage = category.ThumbnailImage
            };

            return result;
        }
    }
}
