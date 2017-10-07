using SimplCommerce.Infrastructure.Models;

namespace SimplCommerce.Module.Catalog.Models
{
    public class ProductOptionValue : EntityBase
    {
        public long OptionId { get; set; }

        public ProductOption Option { get; set; }

        public long ProductId { get; set; }

        public Product Product { get; set; }

        public string Value { get; set; }

        public string DisplayType { get; set; }

        public int SortIndex { get; set; }
    }
}
