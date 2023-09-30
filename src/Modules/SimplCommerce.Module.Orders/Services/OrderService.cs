using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Core.Models;
using SimplCommerce.Module.Orders.Areas.Orders.ViewModels;
using SimplCommerce.Module.Orders.Models;
using SimplCommerce.Module.Pricing.Services;
using SimplCommerce.Module.ShippingPrices.Services;
using SimplCommerce.Module.ShoppingCart.Models;
using SimplCommerce.Module.Tax.Services;
using SimplCommerce.Module.Orders.Events;
using SimplCommerce.Module.Checkouts.Services;
using SimplCommerce.Module.Checkouts.Models;
using SimplCommerce.Module.Checkouts.Areas.Checkouts.ViewModels;

namespace SimplCommerce.Module.Orders.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly ICouponService _couponService;
        private readonly IRepository<CheckoutItem> _checkoutItemRepository;
        private readonly IRepository<OrderItem> _orderItemRepository;
        private readonly ITaxService _taxService;
        private readonly ICheckoutService _checkoutService;
        private readonly IRepositoryWithTypedId<Checkout, Guid> _checkoutRepository;
        private readonly IShippingPriceService _shippingPriceService;
        private readonly IRepository<UserAddress> _userAddressRepository;
        private readonly IMediator _mediator;

        public OrderService(IRepository<Order> orderRepository,
            ICouponService couponService,
            IRepository<CheckoutItem> checkoutItemRepository,
            IRepository<OrderItem> orderItemRepository,
            ITaxService taxService,
            ICheckoutService checkoutSerivce,
            IRepositoryWithTypedId<Checkout, Guid> checkoutRepository,
            IShippingPriceService shippingPriceService,
            IRepository<UserAddress> userAddressRepository,
            IMediator mediator)
        {
            _orderRepository = orderRepository;
            _couponService = couponService;
            _checkoutItemRepository = checkoutItemRepository;
            _orderItemRepository = orderItemRepository;
            _taxService = taxService;
            _checkoutService = checkoutSerivce;
            _checkoutRepository = checkoutRepository;
            _shippingPriceService = shippingPriceService;
            _userAddressRepository = userAddressRepository;
            _mediator = mediator;
        }

        public async Task<Result<Order>> CreateOrder(Guid checkoutId, string paymentMethod, decimal paymentFeeAmount, OrderStatus orderStatus = OrderStatus.New)
        {
            var checkout = await _checkoutRepository
               .Query()
               .Where(x => x.Id == checkoutId).FirstOrDefaultAsync();

            if (checkout == null)
            {
                return Result.Fail<Order>($"Checkout id {checkoutId} cannot be found");
            }

            var shippingData = JsonConvert.DeserializeObject<DeliveryInformationVm>(checkout.ShippingData);
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
                    ZipCode = shippingData.NewAddressForm.ZipCode,
                    Phone = shippingData.NewAddressForm.Phone
                };

                var userAddress = new UserAddress
                {
                    Address = address,
                    AddressType = AddressType.Shipping,
                    UserId = checkout.CustomerId
                };

                _userAddressRepository.Add(userAddress);

                shippingAddress = address;
            }
            else
            {
                shippingAddress = _userAddressRepository.Query().Where(x => x.Id == shippingData.ShippingAddressId).Select(x => x.Address).First();
            }

            if (shippingData.UseShippingAddressAsBillingAddress)
            {
                billingAddress = shippingAddress;
            }
            else if (shippingData.BillingAddressId == 0)
            {
                var address = new Address
                {
                    AddressLine1 = shippingData.NewBillingAddressForm.AddressLine1,
                    AddressLine2 = shippingData.NewBillingAddressForm.AddressLine2,
                    ContactName = shippingData.NewBillingAddressForm.ContactName,
                    CountryId = shippingData.NewBillingAddressForm.CountryId,
                    StateOrProvinceId = shippingData.NewBillingAddressForm.StateOrProvinceId,
                    DistrictId = shippingData.NewBillingAddressForm.DistrictId,
                    City = shippingData.NewBillingAddressForm.City,
                    ZipCode = shippingData.NewBillingAddressForm.ZipCode,
                    Phone = shippingData.NewBillingAddressForm.Phone
                };

                var userAddress = new UserAddress
                {
                    Address = address,
                    AddressType = AddressType.Billing,
                    UserId = checkout.CustomerId
                };

                _userAddressRepository.Add(userAddress);

                billingAddress = address;
            }
            else
            {
                billingAddress = _userAddressRepository.Query().Where(x => x.Id == shippingData.BillingAddressId).Select(x => x.Address).First();
            }

            return await CreateOrder(checkoutId, paymentMethod, paymentFeeAmount, shippingData.ShippingMethod, billingAddress, shippingAddress, orderStatus);
        }

        public async Task<Result<Order>> CreateOrder(Guid checkoutId, string paymentMethod, decimal paymentFeeAmount, string shippingMethodName, Address billingAddress, Address shippingAddress, OrderStatus orderStatus = OrderStatus.New)
        {
            var checkout = _checkoutRepository
                .Query()
                .Include(c => c.CheckoutItems).ThenInclude(x => x.Product)
                .Include(c => c.Customer)
                .Include(c => c.CreatedBy)
                .Where(x => x.Id == checkoutId).FirstOrDefault();

            if (checkout == null)
            {
                return Result.Fail<Order>($"Checkout id {checkoutId} cannot be found");
            }

            var checkingDiscountResult = await CheckForDiscountIfAny(checkout);
            if (!checkingDiscountResult.Succeeded)
            {
                return Result.Fail<Order>(checkingDiscountResult.ErrorMessage);
            }

            var validateShippingMethodResult = await ValidateShippingMethod(shippingMethodName, shippingAddress, checkout);
            if (!validateShippingMethodResult.Success)
            {
                return Result.Fail<Order>(validateShippingMethodResult.Error);
            }

            var shippingMethod = validateShippingMethodResult.Value;

            var orderBillingAddress = new OrderAddress()
            {
                AddressLine1 = billingAddress.AddressLine1,
                AddressLine2 = billingAddress.AddressLine2,
                ContactName = billingAddress.ContactName,
                CountryId = billingAddress.CountryId,
                StateOrProvinceId = billingAddress.StateOrProvinceId,
                DistrictId = billingAddress.DistrictId,
                City = billingAddress.City,
                ZipCode = billingAddress.ZipCode,
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
                ZipCode = shippingAddress.ZipCode,
                Phone = shippingAddress.Phone
            };

            var order = new Order
            {
                Customer = checkout.Customer,
                CreatedOn = DateTimeOffset.Now,
                CreatedBy = checkout.CreatedBy,
                LatestUpdatedOn = DateTimeOffset.Now,
                LatestUpdatedById = checkout.CreatedById,
                BillingAddress = orderBillingAddress,
                ShippingAddress = orderShippingAddress,
                PaymentMethod = paymentMethod,
                PaymentFeeAmount = paymentFeeAmount
            };

            foreach (var checkoutItem in checkout.CheckoutItems)
            {
                if (!checkoutItem.Product.IsAllowToOrder || !checkoutItem.Product.IsPublished || checkoutItem.Product.IsDeleted)
                {
                    return Result.Fail<Order>($"The product {checkoutItem.Product.Name} is not available any more");
                }

                if (checkoutItem.Product.StockTrackingIsEnabled && checkoutItem.Product.StockQuantity < checkoutItem.Quantity)
                {
                    return Result.Fail<Order>($"There are only {checkoutItem.Product.StockQuantity} items available for {checkoutItem.Product.Name}");
                }

                var taxPercent = await _taxService.GetTaxPercent(checkoutItem.Product.TaxClassId, shippingAddress.CountryId, shippingAddress.StateOrProvinceId, shippingAddress.ZipCode);
                var productPrice = checkoutItem.Product.Price;
                if (checkout.IsProductPriceIncludeTax)
                {
                    productPrice = productPrice / (1 + (taxPercent / 100));
                }

                var orderItem = new OrderItem
                {
                    Product = checkoutItem.Product,
                    ProductPrice = productPrice,
                    Quantity = checkoutItem.Quantity,
                    TaxPercent = taxPercent,
                    TaxAmount = checkoutItem.Quantity * (productPrice * taxPercent / 100)
                };

                var discountedItem = checkingDiscountResult.DiscountedProducts.FirstOrDefault(x => x.Id == checkoutItem.ProductId);
                if (discountedItem != null)
                {
                    orderItem.DiscountAmount = discountedItem.DiscountAmount;
                }

                order.AddOrderItem(orderItem);
                if (checkoutItem.Product.StockTrackingIsEnabled)
                {
                    checkoutItem.Product.StockQuantity = checkoutItem.Product.StockQuantity - checkoutItem.Quantity;
                }
            }

            order.OrderStatus = orderStatus;
            order.OrderNote = checkout.OrderNote;
            order.CouponCode = checkingDiscountResult.CouponCode;
            order.CouponRuleName = checkout.CouponRuleName;
            order.DiscountAmount = checkingDiscountResult.DiscountAmount;
            order.ShippingFeeAmount = shippingMethod.Price;
            order.ShippingMethod = shippingMethod.Name;
            order.TaxAmount = order.OrderItems.Sum(x => x.TaxAmount);
            order.SubTotal = order.OrderItems.Sum(x => x.ProductPrice * x.Quantity);
            order.SubTotalWithDiscount = order.SubTotal - checkingDiscountResult.DiscountAmount;
            order.OrderTotal = order.SubTotal + order.TaxAmount + order.ShippingFeeAmount + order.PaymentFeeAmount - order.DiscountAmount;
            _orderRepository.Add(order);

            var vendorIds = checkout.CheckoutItems.Where(x => x.Product.VendorId.HasValue).Select(x => x.Product.VendorId.Value).Distinct();
            if (vendorIds.Any())
            {
                order.IsMasterOrder = true;
            }

            IList<Order> subOrders = new List<Order>();
            foreach (var vendorId in vendorIds)
            {
                var subOrder = new Order
                {
                    CustomerId = checkout.CustomerId,
                    CreatedOn = DateTimeOffset.Now,
                    CreatedById = checkout.CreatedById,
                    LatestUpdatedOn = DateTimeOffset.Now,
                    LatestUpdatedById = checkout.CreatedById,
                    BillingAddress = orderBillingAddress,
                    ShippingAddress = orderShippingAddress,
                    VendorId = vendorId,
                    Parent = order
                };

                foreach (var cartItem in checkout.CheckoutItems.Where(x => x.Product.VendorId == vendorId))
                {
                    var taxPercent = await _taxService.GetTaxPercent(cartItem.Product.TaxClassId, shippingAddress.CountryId, shippingAddress.StateOrProvinceId, shippingAddress.ZipCode);
                    var productPrice = cartItem.Product.Price;
                    if (checkout.IsProductPriceIncludeTax)
                    {
                        productPrice = productPrice / (1 + (taxPercent / 100));
                    }

                    var orderItem = new OrderItem
                    {
                        Product = cartItem.Product,
                        ProductPrice = productPrice,
                        Quantity = cartItem.Quantity,
                        TaxPercent = taxPercent,
                        TaxAmount = cartItem.Quantity * (productPrice * taxPercent / 100)
                    };

                    if (checkout.IsProductPriceIncludeTax)
                    {
                        orderItem.ProductPrice = orderItem.ProductPrice - orderItem.TaxAmount;
                    }

                    subOrder.AddOrderItem(orderItem);
                }

                subOrder.SubTotal = subOrder.OrderItems.Sum(x => x.ProductPrice * x.Quantity);
                subOrder.TaxAmount = subOrder.OrderItems.Sum(x => x.TaxAmount);
                subOrder.OrderTotal = subOrder.SubTotal + subOrder.TaxAmount + subOrder.ShippingFeeAmount - subOrder.DiscountAmount;
                _orderRepository.Add(subOrder);
                subOrders.Add(subOrder);
            }

            using (var transaction = _orderRepository.BeginTransaction())
            {
                _orderRepository.SaveChanges();
                await _mediator.Publish(new OrderCreated(order));
                foreach (var subOrder in subOrders)
                {
                    await _mediator.Publish(new OrderCreated(subOrder));
                }

                _couponService.AddCouponUsage(checkout.CustomerId, order.Id, checkingDiscountResult);
                _orderRepository.SaveChanges();
                transaction.Commit();
            }

            await _mediator.Publish(new AfterOrderCreated(order));

            return Result.Ok(order);
        }

        public void CancelOrder(Order order)
        {
            order.OrderStatus = OrderStatus.Canceled;
            order.LatestUpdatedOn = DateTimeOffset.Now;

            var orderItems = _orderItemRepository.Query().Include(x => x.Product).Where(x => x.Order.Id == order.Id);
            foreach (var item in orderItems)
            {
                if (item.Product.StockTrackingIsEnabled)
                {
                    item.Product.StockQuantity = item.Product.StockQuantity + item.Quantity;
                }
            }
        }

        public async Task<decimal> GetTax(Guid checkoutId, string countryId, long stateOrProvinceId, string zipCode)
        {
            decimal taxAmount = 0;

            var cartItems = _checkoutItemRepository.Query()
                .Where(x => x.CheckoutId == checkoutId)
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
                    var taxRate = await _taxService.GetTaxPercent(cartItem.TaxClassId, countryId, stateOrProvinceId, zipCode);
                    taxAmount = taxAmount + cartItem.Quantity * cartItem.Price * taxRate / 100;
                }
            }

            return taxAmount;
        }

        private async Task<CouponValidationResult> CheckForDiscountIfAny(Checkout checkout)
        {
            if (string.IsNullOrWhiteSpace(checkout.CouponCode))
            {
                return new CouponValidationResult { Succeeded = true, DiscountAmount = 0 };
            }

            var cartInfoForCoupon = new CartInfoForCoupon
            {
                Items = checkout.CheckoutItems.Select(x => new CartItemForCoupon { ProductId = x.ProductId, Quantity = x.Quantity }).ToList()
            };

            var couponValidationResult = await _couponService.Validate(checkout.CustomerId, checkout.CouponCode, cartInfoForCoupon);
            return couponValidationResult;
        }

        private async Task<Result<ShippingPrice>> ValidateShippingMethod(string shippingMethodName, Address shippingAddress, Checkout checkout)
        {
            var applicableShippingPrices = await _shippingPriceService.GetApplicableShippingPrices(new GetShippingPriceRequest
            {
                OrderAmount = checkout.CheckoutItems.Sum(x => x.Product.Price * x.Quantity),
                ShippingAddress = shippingAddress
            });

            var shippingMethod = applicableShippingPrices.FirstOrDefault(x => x.Name == shippingMethodName);
            if (shippingMethod == null)
            {
                return Result.Fail<ShippingPrice>($"Invalid shipping method {shippingMethod}");
            }

            return Result.Ok(shippingMethod);
        }
    }
}
