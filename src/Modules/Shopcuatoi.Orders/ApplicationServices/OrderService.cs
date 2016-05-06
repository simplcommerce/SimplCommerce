using System;
using System.Data.Entity;
using System.Linq;
using Shopcuatoi.Core.Domain.Models;
using Shopcuatoi.Infrastructure.Domain.IRepositories;
using Shopcuatoi.Orders.Domain.Models;

namespace Shopcuatoi.Orders.ApplicationServices
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<CartItem> cartItemRepository;
        private readonly IRepository<Order> orderRepository;

        public OrderService(IRepository<Order> orderRepository, IRepository<CartItem> cartItemRepository)
        {
            this.orderRepository = orderRepository;
            this.cartItemRepository = cartItemRepository;
        }

        public void CreateOrder(User user)
        {
            var cartItems = cartItemRepository
                .Query()
                .Include(x => x.Product)
                .Include(x => x.ProductVariation)
                .Where(x => x.CreatedById == user.Id).ToList();

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
                    ProductPrice = cartItem.ProductPrice,
                    ProductVariation = cartItem.ProductVariation,
                    Quantity = cartItem.Quantity
                };
                order.AddOrderItem(orderItem);

                cartItemRepository.Remove(cartItem);
            }

            orderRepository.Add(order);
        }
    }
}