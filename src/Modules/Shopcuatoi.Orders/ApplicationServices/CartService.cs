using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shopcuatoi.Core.Domain.Models;
using Shopcuatoi.Infrastructure.Domain.IRepositories;
using Shopcuatoi.Orders.Domain.Models;

namespace Shopcuatoi.Orders.ApplicationServices
{
    public class CartService : ICartService
    {
        private readonly IRepository<CartItem> cartItemRepository;
        private readonly IRepository<Product> productRepository;
        private readonly IRepository<ProductVariation> productVariationRepository;

        public CartService(IRepository<CartItem> cartItemRepository,
            IRepository<Product> productRepository, IRepository<ProductVariation> productVariationRepository)
        {
            this.cartItemRepository = cartItemRepository;
            this.productRepository = productRepository;
            this.productVariationRepository = productVariationRepository;
        }

        public CartItem AddToCart(long? userId, Guid? guestId, long productId, string variationName, int quantity)
        {
            ProductVariation productVariation = null;

            var cartItemQuery = cartItemRepository.Query().Where(x => x.ProductId == productId);

            if (userId.HasValue)
            {
                cartItemQuery = cartItemQuery.Where(x => x.CreatedById == userId.Value);
            }

            if (guestId.HasValue)
            {
                cartItemQuery = cartItemQuery.Where(x => x.GuestId == guestId.Value);
            }

            if (!string.IsNullOrWhiteSpace((variationName)))
            {
                productVariation =
                    productVariationRepository.Query()
                        .FirstOrDefault(x => x.Name == variationName && x.ProductId == productId);

                cartItemQuery = cartItemQuery.Where(x => x.ProductVariationId == productVariation.Id);
            }

            var cartItem = cartItemQuery.FirstOrDefault();

            if (cartItem == null)
            {
                cartItem = new CartItem
                {
                    CreatedById = userId,
                    GuestId = guestId,
                    ProductId = productId,
                    Quantity = quantity,
                    CreatedOn = DateTime.Now
                };

                cartItemRepository.Add(cartItem);
            }
            else
            {
                cartItem.Quantity = quantity;
            }

            var product = productRepository.Get(productId);
            cartItem.ProductPrice = product.Price;
            if (productVariation != null)
            {
                cartItem.ProductPrice = cartItem.ProductPrice + productVariation.PriceOffset;
                cartItem.ProductVariationId = productVariation.Id;
            }

            cartItemRepository.SaveChange();

            return cartItem;
        }

        public IList<CartItem> GetCartItems(long? userId, Guid? guestId)
        {
            var query = cartItemRepository
                .Query()
                .Include(x => x.Product)
                .Include(x => x.ProductVariation);

            if (userId.HasValue)
            {
                query = query.Where(x => x.CreatedById == userId);
            }

            if (guestId.HasValue)
            {
                query = query.Where(x => x.GuestId == guestId);
            }

            return query.ToList();
        }
    }
}
