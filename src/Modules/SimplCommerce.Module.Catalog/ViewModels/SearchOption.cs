using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace SimplCommerce.Module.Catalog.ViewModels
{
    public class SearchOption
    {
        public string Brand { get; set; }

        public int? Page { get; set; }

        public string Sort { get; set; }

        public int? MinPrice { get; set; }

        public int? MaxPrice { get; set; }

        public IList<string> GetBrands()
        {
            return string.IsNullOrWhiteSpace(Brand) ? new List<string>() : Brand.Split(new[] { "--" }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        public string ToJson()
        {
            var jsonSetting = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
            return JsonConvert.SerializeObject(this, jsonSetting);
        }
    }
}
