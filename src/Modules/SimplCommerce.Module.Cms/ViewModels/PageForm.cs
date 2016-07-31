using System.ComponentModel.DataAnnotations;

namespace SimplCommerce.Module.Cms.ViewModels
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
        public string SeoTitle { get; set; }

        [Required]
        public string Body { get; set; }

        public bool IsPublished { get; set; }
    }
}
