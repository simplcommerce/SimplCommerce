using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SimplCommerce.Core.Domain.Models;
using SimplCommerce.Infrastructure.Domain.IRepositories;
using SimplCommerce.Orders.Domain.Models;

namespace SimplCommerce.Orders.ApplicationServices
{
    public class CartService : ICartService
    {
        private readonly IRepository<CartItem> cartItemRepository;
        private readonly IRepository<ProductVariation> productVariationRepository;

        public CartService(IRepository<CartItem> cartItemRepository, IRepository<ProductVariation> productVariationRepository)
        {
            this.cartItemRepository = cartItemRepository;
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

            if (!string.IsNullOrWhiteSpace(variationName))
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

            if (productVariation != null)
            {
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
                .Include(x => x.ProductVariation)
                .Include(x => x.ProductVariation.OptionCombinations);

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

        public void UpdateGuestIdToUser(Guid guestId, long userId)
        {
            var cartItems = cartItemRepository.Query().Where(x => x.GuestId == guestId);

            foreach (var cartItem in cartItems)
            {
                cartItem.CreatedById = userId;
            }

            cartItemRepository.SaveChange();
        }
    }
}
