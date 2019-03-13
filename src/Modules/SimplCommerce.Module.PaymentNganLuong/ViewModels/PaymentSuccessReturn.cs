using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimplCommerce.Module.PaymentNganLuong.ViewModels
{
    public class PaymentSuccessReturn
    {
        [FromQuery(Name = "error_code")]
        public string ErrorCode { get; set; }

        [FromQuery(Name = "token")]
        public string Token { get; set; }

        [FromQuery(Name = "order_code")]
        public string OrderCode { get; set; }

        [FromQuery(Name = "order_id")]
        public string OrderId { get; set; }
    }
}
