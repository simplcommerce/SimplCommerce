using System.ComponentModel.DataAnnotations;

namespace SimplCommerce.Module.Cms.Areas.Cms.ViewModels
{
    public class PageForm
    {
        public PageForm()
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

        [Required(ErrorMessage = "The {0} field is required.")]
        public string Body { get; set; }

        public bool IsPublished { get; set; }
    }
}
