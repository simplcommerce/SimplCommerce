using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Orders.Models;

namespace SimplCommerce.Module.Orders.Services
{
    public class CartService : ICartService
    {
        private readonly IRepository<CartItem> _cartItemRepository;

        public CartService(IRepository<CartItem> cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }

        public CartItem AddToCart(long userId, long productId, string variationName, int quantity)
        {

            var cartItemQuery = _cartItemRepository
                .Query()
                .Include(x => x.Product)
                .Where(x => x.ProductId == productId && x.UserId == userId);

            var cartItem = cartItemQuery.FirstOrDefault();

            if (cartItem == null)
            {
                cartItem = new CartItem
                {
                    UserId = userId,
                    ProductId = productId,
                    Quantity = quantity,
                    CreatedOn = DateTimeOffset.Now
                };

                _cartItemRepository.Add(cartItem);
            }
            else
            {
                cartItem.Quantity = quantity;
            }

            _cartItemRepository.SaveChange();

            return cartItem;
        }

        public IList<CartItem> GetCartItems(long userId)
        {
            IQueryable<CartItem> query = _cartItemRepository
                .Query()
                .Include(x => x.Product).ThenInclude(p => p.ThumbnailImage)
                .Include(x => x.Product).ThenInclude(p => p.OptionCombinations).ThenInclude(o => o.Option)
                .Where(x => x.UserId == userId);

            return query.ToList();
        }

        public void MigrateCart(long fromUserId, long toUserId)
        {
            var cartItems = _cartItemRepository.Query().Where(x => x.UserId == fromUserId);

            foreach (var cartItem in cartItems)
            {
                cartItem.UserId = toUserId;
            }

            _cartItemRepository.SaveChange();
        }
    }
}
