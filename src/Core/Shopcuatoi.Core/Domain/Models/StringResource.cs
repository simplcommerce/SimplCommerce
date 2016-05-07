using Shopcuatoi.Infrastructure.Domain.Models;

namespace Shopcuatoi.Core.Domain.Models
{
    public class StringResource : Entity
    {
        public string Key { get; set; }

        public string Value { get; set; }

        public string Culture { get; set; }
    }
}