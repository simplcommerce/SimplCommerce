using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Iyzpay.NetCore;
using Iyzpay.NetCore.Model;
using Iyzpay.NetCore.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Core.Models;
using SimplCommerce.Module.Orders.Models;
using SimplCommerce.Module.Orders.Services;
using SimplCommerce.Module.PaymentIyzico.Models;
using SimplCommerce.Module.PaymentIyzico.ViewModels;
using SimplCommerce.Module.Payments.Models;
using SimplCommerce.Module.ShoppingCart.Services;
using Iyzpay.NetCore.Model;
using SimplCommerce.Module.ShoppingCart.ViewModels;
using Address = Iyzpay.NetCore.Model.Address;
using Payment = Iyzpay.NetCore.Model.Payment;

namespace SimplCommerce.Module.PaymentIyzico.Controllers
{
    [Authorize]
    [Route("iyzico")]
    public class IyzicoController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IOrderService _orderService;
        private readonly IWorkContext _workContext;
        private readonly IRepository<PaymentProvider> _paymentProviderRepository;
        private readonly IRepository<Payments.Models.Payment> _paymentRepository;
        private Lazy<IyzicoConfigForm> _setting;

        public IyzicoController(ICartService cartService, IOrderService orderService, IWorkContext workContext, IRepository<PaymentProvider> paymentProviderRepository, IRepository<Payments.Models.Payment> paymentRepository)
        {
            _cartService = cartService;
            _orderService = orderService;
            _workContext = workContext;
            _paymentProviderRepository = paymentProviderRepository;
            _paymentRepository = paymentRepository;
            _setting = new Lazy<IyzicoConfigForm>(GetSetting);
        }
        private IyzicoConfigForm GetSetting()
        {
            var paypalExpressProvider = _paymentProviderRepository.Query().FirstOrDefault(x => x.Id == PaymentProviderHelper.IyzicoProviderId);
            var paypalExpressSetting = JsonConvert.DeserializeObject<IyzicoConfigForm>(paypalExpressProvider.AdditionalSettings);
            return paypalExpressSetting;
        }
        [HttpGet("credit_card_info")]
        public IActionResult CreditCardInfo()
        {
            return View("CreditCardInfo");
        }

        [HttpPost("pay")]
        public async Task<IActionResult> Pay(CreditCardInfoFormVm request)
        {
            var currentUser = await _workContext.GetCurrentUser();
            var order = await _orderService.CreateOrder(currentUser, "Iyzico");
            var cart = await _cartService.GetCart(currentUser.Id);
            var status = CreatePayment(request, order, cart, currentUser);
            return View(status.Status == Status.SUCCESS.ToString() ? "Shared/success" : "Shared/unsuccessful");
        }
        [HttpPost("3dPay")]
        public async Task<IActionResult> ThreeDPay(CreditCardInfoFormVm request)
        {
            var currentUser = await _workContext.GetCurrentUser();
            var order = await _orderService.CreateOrder(currentUser, "Iyzico");
            var cart = await _cartService.GetCart(currentUser.Id);
            var create3DPayment = Create3dPayment(request,order,cart,currentUser);
            var options = GetIyzcioOptions();
            var threedsInitialize = ThreedsInitialize.Create(create3DPayment, options);
            if (threedsInitialize.Status == Status.SUCCESS.ToString())
            {
                return View(threedsInitialize.HtmlContent);
            }

            return View("Shared/unsuccessful",threedsInitialize.ErrorMessage);

        }

        private Payment CreatePayment(CreditCardInfoFormVm request, Order order, CartVm cartVm, User currentUser)
        {
            
            var paymentRequest = CreatePaymentRequest(request, order, cartVm, currentUser);
            var options = GetIyzcioOptions();
            return Payment.Create(paymentRequest, options);
        }

        private Options GetIyzcioOptions()
        {
            return new Options
            {
                ApiKey = _setting.Value.ApiKey,
                SecretKey = _setting.Value.SecretKey,
                BaseUrl = _setting.Value.BaseUrl
            };
        }

        private CreatePaymentRequest CreatePaymentRequest(CreditCardInfoFormVm request, Order order, CartVm cartVm, User currentUser)
        {

            var paymentRequest = new CreatePaymentRequest
            {
                Locale = Locale.TR.ToString(),
                ConversationId = "123456789",
                Price = Convert.ToString(cartVm.OrderTotal),
                PaidPrice = "0",
                Currency = Currency.TRY.ToString(),
                Installment = 1,
                BasketId = order.Id.ToString(),
                PaymentChannel = PaymentChannel.WEB.ToString(),
                PaymentGroup = PaymentGroup.PRODUCT.ToString(),
            };
            var paymentCard = new PaymentCard
            {
                CardHolderName = request.CardHolderName,
                CardNumber = request.CardNumber,
                ExpireMonth = request.ExpiryMonth.ToString(),
                ExpireYear = request.ExpiryYear.ToString(),
                Cvc = request.Cvv.ToString(),
                RegisterCard = 0
            };
            paymentRequest.PaymentCard = paymentCard;
            var buyer = new Buyer
            {
                Id = currentUser.Id.ToString(),
                Name = order.BillingAddress.ContactName,
                Surname = order.BillingAddress.LastName,
                GsmNumber = currentUser.PhoneNumber,
                Email = currentUser.Email,
                IdentityNumber = order.ShippingAddress.TaxId.ToString(),
                RegistrationDate = currentUser.CreatedOn.Date.ToString(),
                Ip = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString(),
                City = currentUser.DefaultBillingAddress.Address.City,
                Country = currentUser.DefaultBillingAddress.Address.Country.Name,
                ZipCode = currentUser.DefaultBillingAddress.Address.PostalCode
            };
            paymentRequest.Buyer = buyer;
            var shippingAddress = new Address
            {
                ContactName = order.ShippingAddress.ContactName,
                City = order.ShippingAddress.City,
                Country = order.ShippingAddress.Country.Name,
                Description =
                    $"{order.ShippingAddress.AddressLine1} {order.ShippingAddress.AddressLine2} {order.ShippingAddress.District} {order.ShippingAddress.City}",
                ZipCode = order.ShippingAddress.PostalCode
            };
            paymentRequest.ShippingAddress = shippingAddress;
            var billingAddress = new Address
            {
                ContactName = order.BillingAddress.ContactName,
                City = order.BillingAddress.City,
                Country = order.BillingAddress.Country.Name,
                Description =
                    $"{order.BillingAddress.AddressLine1} {order.BillingAddress.AddressLine2} {order.BillingAddress.District} {order.BillingAddress.City}",
                ZipCode = order.ShippingAddress.PostalCode
            };
            paymentRequest.BillingAddress = billingAddress;
            foreach (var orderItem in order.OrderItems)
            {
                paymentRequest.BasketItems.Add(new BasketItem
                {
                    Id = orderItem.Id.ToString(),
                    Name = orderItem.Product.Name,
                    Category1 = orderItem.Product.Categories.First().Category.Name,
                    ItemType = BasketItemType.PHYSICAL.ToString(),
                    Price = Convert.ToString(orderItem.ProductPrice)
                });
            }
            paymentRequest.PaymentCard = paymentCard;
            return paymentRequest;
        }

        private CreatePaymentRequest Create3dPayment(CreditCardInfoFormVm request, Order order, CartVm cartVm, User currentUser)
        {
            
            var paymentRequest = CreatePaymentRequest(request, order, cartVm, currentUser);
            paymentRequest.CallbackUrl = new Uri($"{Request.Scheme}://{Request.Host}/iyzico/threeds").AbsolutePath;
            return paymentRequest;
        }

        [HttpPost("threeds")]
        public IActionResult ThreedsPayment(ThreedsPaymentResponse response)
        {
            return View();
        }
    }


}