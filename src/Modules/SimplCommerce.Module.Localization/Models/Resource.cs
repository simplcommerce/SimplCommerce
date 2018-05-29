using SimplCommerce.Infrastructure.Models;

namespace SimplCommerce.Module.Localization.Models
{
    public class Resource : EntityBase
    {
        public string Key { get; set; }

        public string Value { get; set; }

        public string CultureId { get; set; }

        public Culture Culture { get; set; }
    }
}
