using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimplCommerce.Module.Catalog.Areas.Catalog.ViewModels
{
    public class ProductTemplateFrom
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        public IList<ProductAttributeVm> Attributes { get; set; } = new List<ProductAttributeVm>();
    }
}
