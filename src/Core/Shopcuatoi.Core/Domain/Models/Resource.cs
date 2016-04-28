using System.ComponentModel.DataAnnotations.Schema;
using Shopcuatoi.Infrastructure.Domain.Models;

namespace Shopcuatoi.Core.Domain.Models
{
    public class Resource : Entity
    {
        public string Key { get; set; }

        public string Value { get; set; }

        public string Culture { get; set; }

        [NotMapped]
        public string Type { get; set; } = "string";
    }
}
