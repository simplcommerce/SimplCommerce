using System;
using System.Collections.Generic;
using Shopcuatoi.Orders.Domain.Models;

namespace Shopcuatoi.Orders.ApplicationServices
{
    public interface ICartService
    {
        CartItem AddToCart(long? userId, Guid? guestId, long productId, string variationName, int quantity);

        IList<CartItem> GetCartItems(long? userId, Guid? guestId);
    }
}