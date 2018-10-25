using System.Threading.Tasks;
using SimplCommerce.Module.Pricing.Services;
using SimplCommerce.Module.ShoppingCart.Areas.ShoppingCart.ViewModels;

namespace SimplCommerce.Module.ShoppingCart.Services
{
    public interface ICartService
    {
        Task AddToCart(long userId, long productId, int quantity);

        Task<CartVm> GetCart(long userId);

        Task<CouponValidationResult> ApplyCoupon(long userId, string couponCode);

        Task SaveOrderNote(long userId, string orderNote);

        Task MigrateCart(long fromUserId, long toUserId);
    }
}
