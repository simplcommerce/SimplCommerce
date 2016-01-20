using HvCommerce.Infrastructure.Domain.Models;

namespace HvCommerce.Core.Domain.Models
{
    public abstract class Media : Entity
    {
        public string Caption { get; set; }

        public string Alt { get; set; }

        public int DisplayOrder { get; set; }

        public bool IsCover { get; set; }

        public int FileSize { get; set; }

        public string FileName { get; set; }

        public MediaType MediaType { get; set; }
    }
}
