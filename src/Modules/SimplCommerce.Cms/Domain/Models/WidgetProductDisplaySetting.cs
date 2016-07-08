using System.Collections.Generic;

namespace SimplCommerce.Cms.Domain.Models
{
    public class WidgetProductDisplaySetting
    {
        public int NumberOfProducts { get; set; }

        public IList<long> CategoryIds { get; set; }

        public WidgetProductDisplayOrderBy OrderBy { get; set; }

        public bool FeaturedOnly { get; set; }
    }
}
