using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace SimplCommerce.Module.PaymentStripeV2.Models
{
    public class AdditionalInformation
    {
        public AdditionalInformation([CallerMemberName] string callerMemberName = null)
        {
            Component = callerMemberName;
        }

        public DateTimeOffset CreatedOn { get; set; } = DateTimeOffset.Now;

        public string Component { get; set; }

        public string Message { get; set; }

        internal static string GetSerialization(List<AdditionalInformation> list)
        {
            return JsonConvert.SerializeObject(list);
        }

        internal static List<AdditionalInformation> GetListFromJson(string json)
        {
            return JsonConvert.DeserializeObject<List<AdditionalInformation>>(json);
        }
    }
}
