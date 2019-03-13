using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Infrastructure.Web;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Orders.Models;
using SimplCommerce.Module.Orders.Services;
using SimplCommerce.Module.PaymentNganLuong.Models;
using SimplCommerce.Module.PaymentNganLuong.ViewModels;
using SimplCommerce.Module.Payments.Models;
using SimplCommerce.Module.ShoppingCart.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SimplCommerce.Module.PaymentNganLuong.Areas.PaymentNganLuong.Controllers
{
    [Authorize]
    [ApiExplorerSettings(IgnoreApi = true)]
    [Area("PaymentNganLuong")]
    public class NganLuongController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<Payment> _paymentRepository;
        private readonly IWorkContext _workContext;
        private readonly ICartService _cartService;
        private readonly IRepositoryWithTypedId<PaymentProvider, string> _paymentProviderRepository;
        private readonly IHttpClientFactory _httpClientFactory;
        private Lazy<NganLuongConfigForm> _setting;

        public NganLuongController(
            IOrderService orderService,
            IRepository<Order> orderRepository,
            IRepository<Payment> paymentRepository,
            ICartService cartService,
            IWorkContext workContext,
            IRepositoryWithTypedId<PaymentProvider, string> paymentProviderRepository,
            IHttpClientFactory httpClientFactory)
        {
            _orderService = orderService;
            _orderRepository = orderRepository;
            _paymentRepository = paymentRepository;
            _cartService = cartService;
            _workContext = workContext;
            _paymentProviderRepository = paymentProviderRepository;
            _httpClientFactory = httpClientFactory;
            _setting = new Lazy<NganLuongConfigForm>(GetSetting());
        }

        [HttpGet("ngan-luong/payment-methods")]
        public IActionResult PaymentMethods()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> Payment(string paymentOption, string bankCode)
        {
            var currentUser = await _workContext.GetCurrentUser();
            var cart = await _cartService.GetActiveCartDetails(currentUser.Id);
            if (cart == null)
            {
                return NotFound();
            }

            var orderCreateResult = await _orderService.CreateOrder(cart.Id, "NganLuong", 0, OrderStatus.PendingPayment);

            if (!orderCreateResult.Success)
            {
                TempData["Error"] = orderCreateResult.Error;
                return Redirect("~/checkout/payment");
            }

            var rootUrl = Request.GetFullHostingUrlRoot();
            var request = new PaymentSubmitRequest
            {
                MerchantId = _setting.Value.MerchantId,
                MerchantPassword = _setting.Value.MerchantPassword,
                ReceiverEmail = "nlqthien@gmail.com",
                OrderCode = orderCreateResult.Value.Id.ToString(),
                TotalAmount = (int)orderCreateResult.Value.OrderTotal,
                PaymentMethod = paymentOption,
                BankCode = bankCode,
                ReturnUrl = $"{rootUrl}/ngan-luong/success",
                CancelUrl = $"{rootUrl}/ngan-luong/cancel",
                BuyerFullname = currentUser.FullName,
                BuyerEmail = currentUser.Email,
                BuyerMobile = "0984141633"
            };

            var httpClient = _httpClientFactory.CreateClient();
            var nganLuongUrl = _setting.Value.IsSandbox ? "https://sandbox.nganluong.vn:8088/nl35/checkout.api.nganluong.post.php" : "https://www.nganluong.vn/checkout.api.nganluong.post.php";
            var requestMesage = new HttpRequestMessage(HttpMethod.Post, nganLuongUrl);
            requestMesage.Content = request.MakePostContent();
            var response = await httpClient.SendAsync(requestMesage);
            response.EnsureSuccessStatusCode();
            var result = response.Content.ReadAsStringAsync();
            return Ok(result);
        }

        [Route("ngan-luong/success")]
        public IActionResult Success(PaymentSuccessReturn model)
        {
            return Redirect($"~/checkout/success?orderId={model.OrderCode}");
        }

        [Route("ngan-luong/cancel")]
        public IActionResult Cancel()
        {
            var orderId = 0;
            return Redirect($"~/checkout/error?orderId={orderId}");
        }

        private NganLuongConfigForm GetSetting()
        {
            var nganLuongPaymentProvider = _paymentProviderRepository.Query().FirstOrDefault(x => x.Id == PaymentProviderHelper.NganLuongPaymentProviderId);
            var nganLuongSetting = JsonConvert.DeserializeObject<NganLuongConfigForm>(nganLuongPaymentProvider.AdditionalSettings);
            return nganLuongSetting;
        }
    }
}
