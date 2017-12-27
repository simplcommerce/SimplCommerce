using System;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Core.Models;
using SimplCommerce.Module.Orders.Models;
using SimplCommerce.Module.Pricing.Services;
using SimplCommerce.Module.ShoppingCart.Models;
using SimplCommerce.Module.Orders.ViewModels;
using SimplCommerce.Module.ShippingPrices.Services;
using SimplCommerce.Module.Tax.Services;

namespace SimplCommerce.Module.Orders.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Cart> _cartRepository;
        private readonly IRepository<Order> _orderRepository;
        private readonly ICouponService _couponService;
        private readonly IRepository<CartItem> _cartItemRepository;
        private readonly ITaxService _taxService;
        private readonly IShippingPriceService _shippingPriceService;
        private readonly IRepository<UserAddress> _userAddressRepository;
        private readonly IOrderEmailService _orderEmailService;

        public OrderService(IRepository<Order> orderRepository,
            IRepository<Cart> cartRepository,
            ICouponService couponService,
            IRepository<CartItem> cartItemRepository,
            ITaxService taxService,
            IShippingPriceService shippingPriceService,
            IRepository<UserAddress> userAddressRepository,
            IOrderEmailService orderEmailService)
        {
            _orderRepository = orderRepository;
            _cartRepository = cartRepository;
            _couponService = couponService;
            _cartItemRepository = cartItemRepository;
            _taxService = taxService;
            _shippingPriceService = shippingPriceService;
            _userAddressRepository = userAddressRepository;
            _orderEmailService = orderEmailService;
        }

        public async Task<Order> CreateOrder(User user, string paymentMethod)
        {
            var cart = await _cartRepository
               .Query()
               .Where(x => x.UserId == user.Id && x.IsActive).FirstOrDefaultAsync();

            if (cart == null)
            {
                throw new ApplicationException($"Cart of user {user.Id} cannot be found");
            }

            var shippingData = JsonConvert.DeserializeObject<DeliveryInformationVm>(cart.ShippingData);
            Address billingAddress;
            Address shippingAddress;
            if (shippingData.ShippingAddressId == 0)
            {
                var address = new Address
                {
                    AddressLine1 = shippingData.NewAddressForm.AddressLine1,
                    AddressLine2 = shippingData.NewAddressForm.AddressLine2,
                    ContactName = shippingData.NewAddressForm.ContactName,
                    CountryId = shippingData.NewAddressForm.CountryId,
                    StateOrProvinceId = shippingData.NewAddressForm.StateOrProvinceId,
                    DistrictId = shippingData.NewAddressForm.DistrictId,
                    City = shippingData.NewAddressForm.City,
                    PostalCode = shippingData.NewAddressForm.PostalCode,
                    Phone = shippingData.NewAddressForm.Phone
                };

                var userAddress = new UserAddress
                {
                    Address = address,
                    AddressType = AddressType.Shipping,
                    UserId = user.Id
                };

                _userAddressRepository.Add(userAddress);

                billingAddress = shippingAddress = address;
            }
            else
            {
                billingAddress = shippingAddress = _userAddressRepository.Query().Where(x => x.Id == shippingData.ShippingAddressId).Select(x => x.Address).First();
            }

            return await CreateOrder(user, paymentMethod, shippingData.ShippingMethod, billingAddress, shippingAddress);
        }

        public async Task<Order> CreateOrder(User user, string paymentMethod, string shippingMethodName, Address billingAddress, Address shippingAddress)
        {
            var cart = _cartRepository
                .Query()
                .Include(c => c.Items).ThenInclude(x => x.Product)
                .Where(x => x.UserId == user.Id && x.IsActive).FirstOrDefault();

            if (cart == null)
            {
                throw new ApplicationException($"Cart of user {user.Id} cannot be found");
            }

            var discount = await ApplyDiscount(user, cart);
            var shippingMethod = await ValidateShippingMethod(shippingMethodName, shippingAddress, cart);

            var orderBillingAddress = new OrderAddress()
            {
                AddressLine1 = billingAddress.AddressLine1,
                AddressLine2 = billingAddress.AddressLine2,
                ContactName = billingAddress.ContactName,
                CountryId = billingAddress.CountryId,
                StateOrProvinceId = billingAddress.StateOrProvinceId,
                DistrictId = billingAddress.DistrictId,
                City = billingAddress.City,
                PostalCode = billingAddress.PostalCode,
                Phone = billingAddress.Phone
            };

            var orderShippingAddress = new OrderAddress()
            {
                AddressLine1 = shippingAddress.AddressLine1,
                AddressLine2 = shippingAddress.AddressLine2,
                ContactName = shippingAddress.ContactName,
                CountryId = shippingAddress.CountryId,
                StateOrProvinceId = shippingAddress.StateOrProvinceId,
                DistrictId = shippingAddress.DistrictId,
                City = shippingAddress.City,
                PostalCode = shippingAddress.PostalCode,
                Phone = shippingAddress.Phone
            };

            var order = new Order
            {
                CreatedOn = DateTimeOffset.Now,
                CreatedById = user.Id,
                BillingAddress = orderBillingAddress,
                ShippingAddress = orderShippingAddress,
                PaymentMethod = paymentMethod,
            };

            foreach (var cartItem in cart.Items)
            {
                var taxPercent = await _taxService.GetTaxPercent(cartItem.Product.TaxClassId, shippingAddress.CountryId, shippingAddress.StateOrProvinceId);
                var orderItem = new OrderItem
                {
                    Product = cartItem.Product,
                    ProductPrice = cartItem.Product.Price,
                    Quantity = cartItem.Quantity,
                    TaxPercent = taxPercent,
                    TaxAmount = cartItem.Quantity * (cartItem.Product.Price * taxPercent / 100)
                };
                order.AddOrderItem(orderItem);
            }

            order.CouponCode = cart.CouponCode;
            order.CouponRuleName = cart.CouponRuleName;
            order.Discount = discount;
            order.ShippingAmount = shippingMethod.Price;
            order.ShippingMethod = shippingMethod.Name;
            order.TaxAmount = order.OrderItems.Sum(x => x.TaxAmount);
            order.SubTotal = order.OrderItems.Sum(x => x.ProductPrice * x.Quantity);
            order.SubTotalWithDiscount = order.SubTotal - discount;
            order.OrderTotal = order.SubTotal + order.TaxAmount + order.ShippingAmount - order.Discount;
            _orderRepository.Add(order);

            cart.IsActive = false;

            var vendorIds = cart.Items.Where(x => x.Product.VendorId.HasValue).Select(x => x.Product.VendorId.Value).Distinct();
            foreach (var vendorId in vendorIds)
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
                    var taxPercent = await _taxService.GetTaxPercent(cartItem.Product.TaxClassId, shippingAddress.CountryId, shippingAddress.StateOrProvinceId);
                    var orderItem = new OrderItem
                    {
                        Product = cartItem.Product,
                        ProductPrice = cartItem.Product.Price,
                        Quantity = cartItem.Quantity,
                        TaxPercent = taxPercent,
                        TaxAmount = cartItem.Quantity * (cartItem.Product.Price * taxPercent / 100)
                    };

                    subOrder.AddOrderItem(orderItem);
                }

                subOrder.SubTotal = subOrder.OrderItems.Sum(x => x.ProductPrice * x.Quantity);
                subOrder.TaxAmount = subOrder.OrderItems.Sum(x => x.TaxAmount);
                subOrder.OrderTotal = subOrder.SubTotal + subOrder.TaxAmount + subOrder.ShippingAmount - subOrder.Discount;
                _orderRepository.Add(subOrder);
            }

            _orderRepository.SaveChanges();
           // await _orderEmailService.SendEmailToUser(user, order);
            return order;
        }

        public async Task<decimal> GetTax(long cartOwnerUserId, long countryId, long stateOrProvinceId)
        {
            decimal taxAmount = 0;
            var cart = await _cartRepository.Query().FirstOrDefaultAsync(x => x.UserId == cartOwnerUserId && x.IsActive);
            if (cart == null)
            {
                throw new ApplicationException($"No active cart of user {cartOwnerUserId}");
            }

            var cartItems = _cartItemRepository.Query()
                .Where(x => x.CartId == cart.Id)
                .Select(x => new CartItemVm
                {
                    Quantity = x.Quantity,
                    Price = x.Product.Price,
                    TaxClassId = x.Product.TaxClass.Id
                }).ToList();

            foreach (var cartItem in cartItems)
            {
                if (cartItem.TaxClassId.HasValue)
                {
                    var taxRate = await _taxService.GetTaxPercent(cartItem.TaxClassId, countryId, stateOrProvinceId);
                    taxAmount = taxAmount + cartItem.Quantity * cartItem.Price * taxRate / 100;
                }
            }

            return taxAmount;
        }

        private async Task<decimal> ApplyDiscount(User user, Cart cart)
        {
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

            return discount;
        }

        private async Task<ShippingPrice> ValidateShippingMethod(string shippingMethodName, Address shippingAddress, Cart cart)
        {
            var applicableShippingPrices = await _shippingPriceService.GetApplicableShippingPrices(new GetShippingPriceRequest
            {
                OrderAmount = cart.Items.Sum(x => x.Product.Price * x.Quantity),
                ShippingAddress = shippingAddress
            });

            var shippingMethod = applicableShippingPrices.FirstOrDefault(x => x.Name == shippingMethodName);
            if (shippingMethod == null)
            {
                throw new ApplicationException($"Invalid shipping method {shippingMethod}");
            }

            return shippingMethod;
        }
    }
}
