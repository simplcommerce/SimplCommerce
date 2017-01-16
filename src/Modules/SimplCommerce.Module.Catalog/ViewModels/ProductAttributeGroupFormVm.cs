using System.ComponentModel.DataAnnotations;

namespace SimplCommerce.Module.Catalog.ViewModels
{
    public class ProductAttributeGroupFormVm
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
