using System.Collections.Generic;

namespace SimplCommerce.Module.Orders.Areas.Orders.ViewModels
{
    public class OrderHistoryProductVm
    {
        public long ProductId { get; set; }

        public string ProductName { get; set; }

        public IEnumerable<string> ProductOptions { get; set; } = new List<string>();

        public string ProductOptionString
        {
            get { return string.Join(",", ProductOptions); }
        }

        public int Quantity { get; set; }

        public string ThumbnailImage { get; set; }
    }
}
