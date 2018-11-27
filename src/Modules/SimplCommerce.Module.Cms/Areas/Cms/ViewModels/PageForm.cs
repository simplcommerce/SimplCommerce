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

        [Required]
        public string Name { get; set; }

        [Required]
        public string Slug { get; set; }

        public string MetaTitle { get; set; }

        public string MetaKeywords { get; set; }

        public string MetaDescription { get; set; }

        [Required]
        public string Body { get; set; }

        public bool IsPublished { get; set; }
    }
}
