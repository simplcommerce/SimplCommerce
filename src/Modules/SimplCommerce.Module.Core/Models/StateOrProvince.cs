using SimplCommerce.Infrastructure.Models;

namespace SimplCommerce.Module.Core.Models
{
    public class StateOrProvince : EntityBase
    {
        public long CountryId { get; set; }

        public virtual Country Country { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }
    }
}
