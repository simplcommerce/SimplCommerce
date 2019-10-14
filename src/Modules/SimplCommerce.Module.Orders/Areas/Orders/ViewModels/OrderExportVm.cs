using System;

namespace SimplCommerce.Module.Orders.Areas.Orders.ViewModels
{
    public  class OrderExportVm
    {
        public long Id { get; set; }

        public long CustomerId { get; set; }

        public string CustomerName { get; set; }

        public string CustomerEmail { get; set; }

        public DateTimeOffset CreatedOn { get; set; }

        public DateTimeOffset LatestUpdatedOn { get; set; }

        public int Items { get; set; }

        public string Coupon { get; set; }

        public string OrderStatusString { get; set; }

        public int OrderStatus { get; set; }

        public decimal Subtotal { get; set; }

        public decimal DiscountAmount { get; set; }

        public decimal SubtotalWithDiscount { get; set; }

        public decimal TaxAmount { get; set; }

        public decimal ShippingAmount { get; set; }

        public decimal OrderTotal { get; set; }

        public string ShippingMethod { get; set; }

        public string PaymentMethod { get; set; }

        public decimal PaymentFeeAmount { get; set; }

        public string SubtotalString { get; set; }

        public string DiscountAmountString { get; set; }

        public string SubtotalWithDiscountString { get; set; }

        public string TaxAmountString { get; set; }

        public string ShippingAmountString { get; set; }

        public string PaymentFeeAmountString { get; set; }

        public string OrderTotalString { get; set; }

        public bool IsMasterOrder { get; set; }

        public long ShippingAddressId { get; set; }

        public string ShippingAddressContactName { get; set; }

        public string ShippingAddressPhone { get; set; }

        public string ShippingAddressAddressLine1 { get; set; }

        public string ShippingAddressAddressLine2 { get; set; }

        public long? ShippingAddressDistrictId { get; set; }

        public string ShippingAddressDistrictName { get; set; }

        public string ShippingAddressZipCode { get; set; }

        public long ShippingAddressStateOrProvinceId { get; set; }

        public string ShippingAddressStateOrProvinceName { get; set; }

        public string ShippingAddressCountryId { get; set; }

        public string ShippingAddressCountryName { get; set; }

        public bool ShippingAddressIsDistrictEnabled { get; set; }

        public bool ShippingAddressIsZipCodeEnabled { get; set; }

        public bool ShippingAddressIsCityEnabled { get; set; }

        public long BillingAddressId { get; set; }

        public string BillingAddressContactName { get; set; }

        public string BillingAddressPhone { get; set; }

        public string BillingAddressAddressLine1 { get; set; }

        public string BillingAddressAddressLine2 { get; set; }

        public long? BillingAddressDistrictId { get; set; }

        public string BillingAddressDistrictName { get; set; }

        public string BillingAddressZipCode { get; set; }

        public long BillingAddressStateOrProvinceId { get; set; }

        public string BillingAddressStateOrProvinceName { get; set; }

        public string BillingAddressCountryId { get; set; }

        public string BillingAddressCountryName { get; set; }

        public bool BillingAddressIsDistrictEnabled { get; set; }

        public bool BillingAddressIsZipCodeEnabled { get; set; }

        public bool BillingAddressIsCityEnabled { get; set; }
    }
}
