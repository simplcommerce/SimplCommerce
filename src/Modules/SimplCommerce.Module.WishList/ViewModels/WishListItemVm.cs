using SimplCommerce.Module.Catalog.ViewModels;

namespace SimplCommerce.Module.WishList.ViewModels
{
    public class WishListItemVm
    {
        public long Id { get; set; }

        public long WishListId { get; set; }

        public long ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductImage { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }
    }
}
