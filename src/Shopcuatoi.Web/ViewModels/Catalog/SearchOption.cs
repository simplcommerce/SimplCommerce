using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc.ViewFeatures;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Shopcuatoi.Web.ViewModels.Catalog
{
    public class SearchOption
    {
        public string Brand { get; set; }

        public decimal? MixPrice { get; set; }

        public decimal? MaxPrice { get; set; }

        public int? Page { get; set; }

        public IList<string> Brands
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Brand))
                {
                    return new List<string>();
                }
                return Brand.Split(new [] {"--"}, StringSplitOptions.RemoveEmptyEntries).ToList();
            }
        }

        public string ToJson()
        {
            var jsonSetting = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
            return JsonConvert.SerializeObject(this, jsonSetting);
        }
    }
}