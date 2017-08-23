using SimplCommerce.Infrastructure.Models;
using SimplCommerce.Module.Core.Models;

namespace SimplCommerce.Module.Pricing.Models
{
    public class CatalogRuleCustomerGroup : EntityBase
    {
        public long CatalogRuleId { get; set; }

        public CatalogRule CatalogRule { get; set; }

        public long CustomerGroupId { get; set; }

        public CustomerGroup CustomerGroup { get; set; }
    }
}
