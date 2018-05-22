using SimplCommerce.Infrastructure.Models;

namespace SimplCommerce.Module.Catalog.Models
{
    public class ProductOption : EntityBase
    {
        public ProductOption()
        {

        }

        public ProductOption(long id)
        {
            Id = id;
        }

        public string Name { get; set; }
    }
}
