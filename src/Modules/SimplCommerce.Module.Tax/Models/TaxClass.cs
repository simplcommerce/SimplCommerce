using SimplCommerce.Infrastructure.Models;

namespace SimplCommerce.Module.Tax.Models
{
    public class TaxClass : EntityBase
    {
        public TaxClass() { }

        public TaxClass(long id)
        {
            Id = id;
        }

        public string Name { get; set; }
    }
}
