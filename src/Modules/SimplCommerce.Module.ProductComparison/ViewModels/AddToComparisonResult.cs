using System;
using System.Collections.Generic;
using System.Text;

namespace SimplCommerce.Module.ProductComparison.ViewModels
{
    public class AddToComparisonResult
    {
        public string ProductName { get; set; }

        public string ProductImage { get; set; }

        public decimal ProductPrice { get; set; }

        public string VariationName { get; set; }

        public int ComparisonItemCount { get; set; }
    }
}
