using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Core.Models;
using SimplCommerce.Module.Orders.Models;

namespace SimplCommerce.Module.Orders.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<CartItem> _cartItemRepository;
        private readonly IRepository<Order> _orderRepository;

        public OrderService(IRepository<Order> orderRepository, IRepository<CartItem> cartItemRepository)
        {
            _orderRepository = orderRepository;
            _cartItemRepository = cartItemRepository;
        }

        public void CreateOrder(User user)
        {
            var cartItems = _cartItemRepository
                .Query()
                .Include(x => x.Product)
                .Where(x => x.UserId == user.Id).ToList();

            var order = new Order
            {
                CreatedOn = DateTime.Now,
                CreatedById = user.Id,
                ShippingAddress = user.CurrentShippingAddress
            };

            foreach (var cartItem in cartItems)
            {
                var orderItem = new OrderItem
                {
                    Product = cartItem.Product,
                    ProductPrice = cartItem.Product.Price,
                    Quantity = cartItem.Quantity
                };
                order.AddOrderItem(orderItem);

                _cartItemRepository.Remove(cartItem);
            }

            order.SubTotal = order.OrderItems.Sum(x => x.ProductPrice * x.Quantity);

            _orderRepository.Add(order);
            _orderRepository.SaveChange();
        }
    }
}
