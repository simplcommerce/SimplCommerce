using Shopcuatoi.Infrastructure.Domain.Models;

namespace Shopcuatoi.Core.Domain.Models
{
    public class District : Entity
    {
        public long StateOrProvinceId { get; set; }

        public virtual StateOrProvince StateOrProvince { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Location { get; set; }

    }
}