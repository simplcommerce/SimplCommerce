using Shopcuatoi.Infrastructure.Domain.Models;

namespace Shopcuatoi.Core.Domain.Models
{
    public class Address : Entity
    {
        public string ContactName { get; set; }

        public string Phone { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public long DistrictId { get; set; }

        public virtual District District { get; set; }

        public long StateOrProvinceId { get; set; }

        public virtual StateOrProvince StateOrProvince { get; set; }

        public long CountryId { get; set; }

        public virtual Country Country { get; set; }
    }
}