using System.Threading.Tasks;
using SimplCommerce.Module.Pricing.Services;
using SimplCommerce.Module.ShoppingCart.Areas.ShoppingCart.ViewModels;

namespace SimplCommerce.Module.ShoppingCart.Services
{
    public interface ICartService
    {
        Task<AddToCartResult> AddToCart(long customerId, long productId, int quantity);

        Task<CartVm> GetCartDetails(long customerId);

        Task<CouponValidationResult> ApplyCoupon(long customerId, string couponCode);

        Task MigrateCart(long fromUserId, long toUserId);
    }
}
