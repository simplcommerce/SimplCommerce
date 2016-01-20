namespace HvCommerce.Core.Domain.Models
{
    public class ProductMedia : Media
    {
        public virtual Product Product { get; set; }
    }
}
