using System;
using System.Collections.Generic;
using SimplCommerce.Orders.Domain.Models;

namespace SimplCommerce.Orders.ApplicationServices
{
    public interface ICartService
    {
        CartItem AddToCart(long? userId, Guid? guestId, long productId, string variationName, int quantity);

        IList<CartItem> GetCartItems(long? userId, Guid? guestId);

        void UpdateGuestIdToUser(Guid guestId, long userId);
    }
}