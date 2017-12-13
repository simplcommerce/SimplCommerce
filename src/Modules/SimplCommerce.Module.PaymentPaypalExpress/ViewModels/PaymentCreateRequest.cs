using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplCommerce.Module.PaymentPaypalExpress.ViewModels
{
    public class PaymentCreateRequest
    {
        public string intent { get; set; }
        public Payer payer { get; set; }
        public Transaction[] transactions { get; set; }
        public string note_to_payer { get; set; }
        public Redirect_Urls redirect_urls { get; set; }
    }

    public class Payer
    {
        public string payment_method { get; set; }
    }

    public class Redirect_Urls
    {
        public string return_url { get; set; }
        public string cancel_url { get; set; }
    }

    public class Transaction
    {
        public Amount amount { get; set; }
        public string description { get; set; }
        public string custom { get; set; }
        public string invoice_number { get; set; }
        public Payment_Options payment_options { get; set; }
        public string soft_descriptor { get; set; }
        public Item_List item_list { get; set; }
    }

    public class Amount
    {
        public string total { get; set; }
        public string currency { get; set; }
        public Details details { get; set; }
    }

    public class Details
    {
        public string subtotal { get; set; }
        public string tax { get; set; }
        public string shipping { get; set; }
        public string handling_fee { get; set; }
        public string shipping_discount { get; set; }
        public string insurance { get; set; }
    }

    public class Payment_Options
    {
        public string allowed_payment_method { get; set; }
    }

    public class Item_List
    {
        public Item[] items { get; set; }
        public Shipping_Address shipping_address { get; set; }
    }

    public class Shipping_Address
    {
        public string recipient_name { get; set; }
        public string line1 { get; set; }
        public string line2 { get; set; }
        public string city { get; set; }
        public string country_code { get; set; }
        public string postal_code { get; set; }
        public string phone { get; set; }
        public string state { get; set; }
    }

    public class Item
    {
        public string name { get; set; }
        public string description { get; set; }
        public string quantity { get; set; }
        public string price { get; set; }
        public string tax { get; set; }
        public string sku { get; set; }
        public string currency { get; set; }
    }
}
