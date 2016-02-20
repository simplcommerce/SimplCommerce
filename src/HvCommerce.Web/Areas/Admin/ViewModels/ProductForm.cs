using System.ComponentModel.DataAnnotations;

namespace HvCommerce.Web.Areas.Admin.ViewModels
{
    public class ProductForm
    {
        public ProductForm()
        {
            IsPublished = true;
        }

        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public bool IsPublished { get; set; }
    }
}