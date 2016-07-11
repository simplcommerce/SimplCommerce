using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SimplCommerce.Cms.Domain.Models
{
    public class WidgetProductDisplaySetting
    {
        public int NumberOfProducts { get; set; }

        public IList<long> CategoryIds { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public WidgetProductDisplayOrderBy OrderBy { get; set; }

        public bool FeaturedOnly { get; set; }
    }
}
