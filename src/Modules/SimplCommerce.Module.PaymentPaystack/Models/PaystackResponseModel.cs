using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplCommerce.Module.PaymentPaystack.Models
{
    public class PaystackResponseModel
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public Data Data { get; set; }
    }

    public class Data
    {
        public string Authorization_url { get; set; }
        public string Access_code { get; set; }
        public string Reference { get; set; }
        public string Amount { get; set; }
        public string Transaction_date { get; set; }
        public string Status { get; set; }
        public string Gateway_response { get; set; }
    }
    public class VerifyPayStackResponseModel
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public Data Data { get; set; }
    }

}
