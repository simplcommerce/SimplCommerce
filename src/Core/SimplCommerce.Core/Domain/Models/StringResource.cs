using SimplCommerce.Infrastructure.Domain.Models;

namespace SimplCommerce.Core.Domain.Models
{
    public class StringResource : Entity
    {
        public string Key { get; set; }

        public string Value { get; set; }

        public string Culture { get; set; }
    }
}