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

        [Required(ErrorMessage = "The {0} field is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public string Slug { get; set; }

        public string MetaTitle { get; set; }

        public string MetaKeywords { get; set; }

        public string MetaDescription { get; set; }

        public bool IsPublished { get; set; }
    }
}
