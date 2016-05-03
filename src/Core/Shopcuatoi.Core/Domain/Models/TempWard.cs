using Shopcuatoi.Infrastructure.Domain.Models;

namespace Shopcuatoi.Core.Domain.Models
{
    public class TempWard : Entity
    {
        public string ProvinceName { get; set; }

        public string DistrictName { get; set; }

        public long DistrictId { get; set; }

        public string WardName { get; set; }

        public long WardId { get; set; }
    }
}