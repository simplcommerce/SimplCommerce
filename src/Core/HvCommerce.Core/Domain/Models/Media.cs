using HvCommerce.Infrastructure.Domain.Models;

namespace HvCommerce.Core.Domain.Models
{
    public class Media : Entity
    {
        public string Caption { get; set; }

        public int FileSize { get; set; }

        public string FileName { get; set; }

        public MediaType MediaType { get; set; }
    }
}
