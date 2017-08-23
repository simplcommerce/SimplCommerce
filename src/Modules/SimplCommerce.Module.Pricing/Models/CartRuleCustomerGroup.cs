using SimplCommerce.Module.Core.Models;

namespace SimplCommerce.Module.Pricing.Models
{
    public class CartRuleCustomerGroup
    {
        public long CartRuleId { get; set; }

        public CatalogRule CartRule { get; set; }

        public long CustomerGroupId { get; set; }

        public CustomerGroup CustomerGroup { get; set; }
    }
}
