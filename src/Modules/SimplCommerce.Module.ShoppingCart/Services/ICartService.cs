using System.Linq;
using System.Threading.Tasks;
using SimplCommerce.Module.Pricing.Services;
using SimplCommerce.Module.ShoppingCart.Areas.ShoppingCart.ViewModels;
using SimplCommerce.Module.ShoppingCart.Models;

namespace SimplCommerce.Module.ShoppingCart.Services
{
    public interface ICartService
    {
        Task AddToCart(long customerId, long productId, int quantity);

        Task AddToCart(long customerId, long createdById, long productId, int quantity);

        IQueryable<Cart> Query();

        IQueryable<Cart> GetActiveCart(long customerId);

        IQueryable<Cart> GetActiveCart(long customerId, long createdById);

        Task<CartVm> GetActiveCartDetails(long customerId);

        Task<CartVm> GetActiveCartDetails(long customerId, long createdById);

        Task<CouponValidationResult> ApplyCoupon(long cartId, string couponCode);

        Task MigrateCart(long fromUserId, long toUserId);
    }
}
