using System;
using System.Collections.Generic;
using System.Text;

namespace SimplCommerce.Module.ProductComparison.ViewModels
{
    public class AddToComparisonResult
    {
        public int ComparisonItemCount { get; set; }

        public int MaxItem { get; set; }

        public String Message { get; set; }

        public bool AddResult { get; set; }

        public IList<ProductComparisonModel> ProductComparisons { get; set; } = new List<ProductComparisonModel>();
    }
}
