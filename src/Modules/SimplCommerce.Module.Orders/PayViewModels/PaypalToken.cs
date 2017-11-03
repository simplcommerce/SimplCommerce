using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplCommerce.Module.Orders.PayViewModels
{
    public class PaypalToken
    {
        public string scope { get; set; }
        public string nonce { get; set; }
        [FromQuery(Name = "Access-Token")]
        public string AccessToken { get; set; }
        public int token_type { get; set; }
        public string app_id { get; set; }
        public string expires_in { get; set; }
    }
}
