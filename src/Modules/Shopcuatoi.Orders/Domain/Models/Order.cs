using System;
using Shopcuatoi.Core.Domain.Models;
using Shopcuatoi.Infrastructure.Domain.Models;

namespace Shopcuatoi.Orders.Domain.Models
{
    public class Order : Entity
    {
        public DateTime CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public long? CreatedById { get; set; }

        public virtual User CreatedBy { get; set; }

        public string ShippingAddressFullName { get; set; }

        public string ShippingAddressPhone { get; set; }

        public string ShippingAddressLine1 { get; set; }

        public string ShippingAddressLine2 { get; set; }

        public long? ShippingAddressDistrictId { get; set; }

        public virtual District ShippingAddressDistrict { get; set; }

        public long ShippingAddressStateOrProvinceId { get; set; }

        public virtual StateOrProvince ShippingAddressStateOrProvince { get; set; }

    }
}