using System;
using System.Collections.Generic;
using System.Text;

namespace SimplCommerce.Module.ProductComparison.ViewModels
{
    public class ProductComparisonModel
    {
        public long ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductImage { get; set; }

        public decimal ProductPrice { get; set; }
    }
}
