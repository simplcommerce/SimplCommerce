using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimplCommerce.Infrastructure.Web
{
    public class SimplResponse
    {
        public bool Success { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public object Payload { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public SimplResponseError Error { get; set; }
    }
    public class SimplCustomResponse<T>
    {
        public bool Success { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public T Payload { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public SimplResponseError Error { get; set; }
    }
    public class SimplResponseError
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}
