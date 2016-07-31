using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SimplCommerce.Module.Catalog.ViewModels
{
    public class ProductWidgetSetting
    {
        public int NumberOfProducts { get; set; }

        public IList<long> CategoryIds { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public ProductWidgetOrderBy OrderBy { get; set; }

        public bool FeaturedOnly { get; set; }
    }
}
