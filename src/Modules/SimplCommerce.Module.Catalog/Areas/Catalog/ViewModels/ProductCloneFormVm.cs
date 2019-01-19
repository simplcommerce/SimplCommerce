using System.ComponentModel.DataAnnotations;

namespace SimplCommerce.Module.Catalog.Areas.Catalog.ViewModels
{
    public class ProductCloneFormVm
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public string Slug { get; set; }
    }
}
