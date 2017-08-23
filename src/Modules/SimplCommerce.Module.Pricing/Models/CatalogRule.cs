using System;
using System.Collections.Generic;
using SimplCommerce.Infrastructure.Models;

namespace SimplCommerce.Module.Pricing.Models
{
    public class CatalogRule : EntityBase
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public DateTimeOffset? StartOn { get; set; }

        public DateTimeOffset? EndOn { get; set; }

        public string RuleToApply { get; set; }

        public decimal DiscountAmount { get; set; }

        public decimal MaxDiscountAmount { get; set; }

        public IList<CatalogRuleCustomerGroup> CustomerGroups { get; set; } = new List<CatalogRuleCustomerGroup>();
    }
}
