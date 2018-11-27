using System.ComponentModel.DataAnnotations;

namespace SimplCommerce.Module.News.Areas.News.ViewModels
{
    public class NewsCategoryForm
    {
        public NewsCategoryForm()
        {
            IsPublished = true;
        }

        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Slug { get; set; }

        public string MetaTitle { get; set; }

        public string MetaKeywords { get; set; }

        public string MetaDescription { get; set; }

        public bool IsPublished { get; set; }
    }
}
