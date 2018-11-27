using System.Collections.Generic;
using SimplCommerce.Module.Catalog.Models;

namespace SimplCommerce.Module.ProductComparison.Areas.ProductComparison.ViewModels
{
    public class ComparingProductVm
    {
        public long ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductImage { get; set; }

        public CalculatedProductPrice CalculatedProductPrice { get; set; }

        public IList<AttributeValueVm> AttributeValues { get; set; } = new List<AttributeValueVm>();
    }
}
