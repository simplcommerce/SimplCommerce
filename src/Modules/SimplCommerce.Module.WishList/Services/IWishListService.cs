namespace SimplCommerce.Module.WishList.Services
{
    public interface IWishListService
    {
        string GenerateSharingCode(long wishListId);
    }
}
