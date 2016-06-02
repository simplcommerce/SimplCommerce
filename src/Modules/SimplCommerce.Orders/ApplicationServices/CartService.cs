using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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

        public CartItem AddToCart(long userId, long productId, string variationName, int quantity)
        {
            ProductVariation productVariation = null;

            var cartItemQuery = cartItemRepository
                .Query()
                .Include(x => x.Product)
                .Where(x => x.ProductId == productId && x.UserId == userId);

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
                    UserId = userId,
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

        public IList<CartItem> GetCartItems(long userId)
        {
            IQueryable<CartItem> query = cartItemRepository
                .Query()
                .Include(x => x.Product).ThenInclude(p => p.ThumbnailImage)
                .Include(x => x.ProductVariation)
                .Include(x => x.ProductVariation).ThenInclude(p => p.OptionCombinations).ThenInclude(o => o.Option)
                .Where(x => x.UserId == userId);

            return query.ToList();
        }

        public void MigrateCart(long fromUserId, long toUserId)
        {
            var cartItems = cartItemRepository.Query().Where(x => x.UserId == fromUserId);

            foreach (var cartItem in cartItems)
            {
                cartItem.UserId = toUserId;
            }

            cartItemRepository.SaveChange();
        }
    }
}
