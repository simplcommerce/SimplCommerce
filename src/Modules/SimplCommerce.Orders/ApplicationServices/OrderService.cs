using System;
using System.Linq;
using SimplCommerce.Core.Domain.Models;
using SimplCommerce.Infrastructure.Domain.IRepositories;
using SimplCommerce.Orders.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace SimplCommerce.Orders.ApplicationServices
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
                CreatedById = user.Id
               // ShippingAddress = user.CurrentShippingAddress
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

            order.SubTotal = order.OrderItems.Sum(x => x.ProductPrice*x.Quantity);

            orderRepository.Add(order);
        }
    }
}