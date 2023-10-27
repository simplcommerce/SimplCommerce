using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.ShoppingCart.Models;

namespace SimplCommerce.Module.Orders.Events
{
    public class OrderCreatedClearCartHandler : INotificationHandler<OrderCreated>
    {
        private readonly IRepository<CartItem> _cartItemRepository;

        public OrderCreatedClearCartHandler(IRepository<CartItem> cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }

        public async Task Handle(OrderCreated notification, CancellationToken cancellationToken)
        {
            foreach (var orderItem in notification.Order.OrderItems)
            {
                var cartItem = await _cartItemRepository.Query().FirstOrDefaultAsync(x => x.ProductId == orderItem.ProductId && x.CustomerId == notification.Order.CustomerId);
                if (cartItem != null)
                {
                    _cartItemRepository.Remove(cartItem);
                }
            }

            await _cartItemRepository.SaveChangesAsync();
        }
    }
}
