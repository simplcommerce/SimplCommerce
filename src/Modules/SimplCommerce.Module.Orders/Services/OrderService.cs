using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Core.Models;
using SimplCommerce.Module.Orders.Models;
using SimplCommerce.Module.Pricing.Services;
using SimplCommerce.Module.Shipping.Models;
using SimplCommerce.Module.Shipping.Services;
using SimplCommerce.Module.PaymentType.Services;

namespace SimplCommerce.Module.Orders.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Cart> _cartRepository;
        private readonly IRepository<Order> _orderRepository;
        private readonly IShippingService _shippingService;
        private readonly IPaymentType _paymenttypeService;
        private readonly ICouponService _couponService;

        public OrderService(IPaymentType paymenttypeService , IShippingService shippingService , IRepository<Order> orderRepository, IRepository<Cart> cartRepository, ICouponService couponService)
        {
            _orderRepository = orderRepository;
            _cartRepository = cartRepository;
            _couponService = couponService;
            _shippingService = shippingService;
            _paymenttypeService = paymenttypeService;
        }

        public async Task<Order> CreateOrder(User user, Address billingAddress, Address shippingAddress , ShippingMethod shippingmethod, PaymentType.Models.PaymentType paymentmethod)
        {
            var cart = _cartRepository
                .Query()
                .Include(c => c.Items).ThenInclude(x => x.Product)
                .Where(x => x.UserId == user.Id && x.IsActive).FirstOrDefault();

            if(cart == null)
            {
                throw new ApplicationException($"Cart of user {user.Id} can no be found");
            }

            decimal discount = 0; 
            if (!string.IsNullOrWhiteSpace(cart.CouponCode))
            {
                var cartInfoForCoupon = new CartInfoForCoupon
                {
                    Items = cart.Items.Select(x => new CartItemForCoupon { ProductId = x.ProductId, Quantity = x.Quantity }).ToList()
                };
                var couponValidationResult = await _couponService.Validate(cart.CouponCode, cartInfoForCoupon);
                if (couponValidationResult.Succeeded)
                {
                    discount = couponValidationResult.DiscountAmount;
                    _couponService.AddCouponUsage(user.Id, couponValidationResult.CouponId);
                }
                else
                {
                    throw new ApplicationException($"Unable to apply coupon {cart.CouponCode}. {couponValidationResult.ErrorMessage}");
                }
            }

            var orderBillingAddress = new OrderAddress()
            {
                AddressLine1 = billingAddress.AddressLine1,
                ContactName = billingAddress.ContactName,
                CountryId = billingAddress.CountryId,
                StateOrProvinceId = billingAddress.StateOrProvinceId,
                DistrictId = billingAddress.DistrictId,
                Phone = billingAddress.Phone
            };

            var orderShippingAddress = new OrderAddress()
            {
                AddressLine1 = shippingAddress.AddressLine1,
                ContactName = shippingAddress.ContactName,
                CountryId = shippingAddress.CountryId,
                StateOrProvinceId = shippingAddress.StateOrProvinceId,
                DistrictId = shippingAddress.DistrictId,
                Phone = shippingAddress.Phone
            };

            var order = new Order
            {
                CreatedOn = DateTimeOffset.Now,
                CreatedById = user.Id,
                BillingAddress = orderBillingAddress,
                ShippingAddress = orderShippingAddress
            };

            foreach (var cartItem in cart.Items)
            {
                var orderItem = new OrderItem
                {
                    Product = cartItem.Product,
                    ProductPrice = cartItem.Product.Price,
                    Quantity = cartItem.Quantity
                };
                order.AddOrderItem(orderItem);
            }

            order.CouponCode = cart.CouponCode;
            order.CouponRuleName = cart.CouponRuleName;
            order.Discount = discount;
            order.SubTotal = order.OrderItems.Sum(x => x.ProductPrice * x.Quantity);
            order.SubTotalWithDiscount = order.SubTotal - discount;
            order.PaymentCost = _paymenttypeService.Calculate(paymentmethod.Id, order.SubTotalWithDiscount);
            order.ShippingCost = shippingmethod.ShippingPrice;
            order.GranTotal = order.SubTotalWithDiscount + order.PaymentCost + order.ShippingCost ;
            order.ShippingMethodId = shippingmethod.Id;
            order.PaymentMethodId = paymentmethod.Id;
            order.PaymentId = paymentmethod.Id;
            _orderRepository.Add(order);

            cart.IsActive = false;

            var vendorIds = cart.Items.Where(x => x.Product.VendorId.HasValue).Select(x => x.Product.VendorId.Value).Distinct();
            foreach(var vendorId in vendorIds)
            {
                var subOrder = new Order
                {
                    CreatedOn = DateTimeOffset.Now,
                    CreatedById = user.Id,
                    BillingAddress = orderBillingAddress,
                    ShippingAddress = orderShippingAddress,
                    VendorId = vendorId,
                    Parent = order
                };

                foreach (var cartItem in cart.Items.Where(x => x.Product.VendorId == vendorId))
                {
                    var orderItem = new OrderItem
                    {
                        Product = cartItem.Product,
                        ProductPrice = cartItem.Product.Price,
                        Quantity = cartItem.Quantity
                    };

                    subOrder.AddOrderItem(orderItem);
                }

                subOrder.SubTotal = subOrder.OrderItems.Sum(x => x.ProductPrice * x.Quantity);
                subOrder.PaymentCost = _paymenttypeService.Calculate(paymentmethod.Id, order.SubTotalWithDiscount);
                subOrder.ShippingCost = shippingmethod.ShippingPrice;
                subOrder.GranTotal = order.SubTotalWithDiscount + order.PaymentCost + order.ShippingCost;
                subOrder.ShippingMethodId = shippingmethod.Id;
                subOrder.PaymentMethodId = paymentmethod.Id;
                subOrder.PaymentId = paymentmethod.Id;
                _orderRepository.Add(subOrder);
            }

            _orderRepository.SaveChange();
            return order;
        }
    }
}
