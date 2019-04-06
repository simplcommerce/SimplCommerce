using System;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NBitpayClient;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Orders.Models;
using SimplCommerce.Module.Orders.Services;
using SimplCommerce.Module.PaymentBtcPayServer.Models;
using SimplCommerce.Module.PaymentBtcPayServer.Services;
using SimplCommerce.Module.Payments.Models;
using SimplCommerce.Module.ShoppingCart.Services;

namespace SimplCommerce.Module.PaymentBtcPayServer.Areas.PaymentBtcPayServer.Controllers
{
    [Area("PaymentBtcPayServer")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class BtcPayServerController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IOrderService _orderService;
        private readonly IWorkContext _workContext;
        private readonly IRepository<Payment> _paymentRepository;
        private readonly IRepository<Order> _orderRepository;
        private readonly IBtcPayServerClientService _btcPayServerClientService;

        public BtcPayServerController(
            ICartService cartService,
            IOrderService orderService,
            IWorkContext workContext,
            IRepositoryWithTypedId<PaymentProvider, string> paymentProviderRepository,
            IRepository<Payment> paymentRepository,
            IRepository<Order> orderRepository,
            IBtcPayServerClientService btcPayServerClientService)
        {
            _cartService = cartService;
            _orderService = orderService;
            _workContext = workContext;
            _paymentRepository = paymentRepository;
            _orderRepository = orderRepository;
            _btcPayServerClientService = btcPayServerClientService;
        }

        [HttpPost]
        public async Task<IActionResult> Charge(string nonce)
        {
            var client = await _btcPayServerClientService.ConstructClient();
            if (!client.TestAccess(Facade.Merchant))
            {
                return BadRequest("btcpay payment provider not paired correctly");
            }

            var currentUser = await _workContext.GetCurrentUser();
            var cart = await _cartService.GetActiveCartDetails(currentUser.Id);
            if (cart == null)
            {
                return NotFound();
            }

            var orderCreateResult = await _orderService.CreateOrder(cart.Id,
                PaymentProviderConstants.BtcPayServerProviderId, 0, OrderStatus.PendingPayment);

            if (!orderCreateResult.Success)
            {
                return BadRequest(orderCreateResult.Error);
            }

            var order = orderCreateResult.Value;
            var regionInfo = new RegionInfo(CultureInfo.CurrentCulture.LCID);

            var result = await client.CreateInvoiceAsync(new Invoice()
            {
                Price = order.OrderTotal,
                Currency = regionInfo.ISOCurrencySymbol,
                OrderId = order.Id.ToString(),
                FullNotifications = true,
                NotificationURL = Url.Action("OnInvoiceCallback", "BtcPayServer", new { }, Request.Scheme,
                    Request.Host.ToString()),
                RedirectURL = Url.Action("OrderDetails", "Order", new { orderId = order.Id}, Request.Scheme,
                    Request.Host.ToString()),
                BuyerEmail = order.Customer?.Email,
            });

            
            return Ok(new {Status = "success", OrderId = order.Id, TransactionId = result.Id});
        }

        [HttpPost("InvoiceCallback")]
        public async Task<IActionResult> OnInvoiceCallback(InvoicePaymentNotification invoicePaymentNotification)
        {
            if (invoicePaymentNotification == null)
            {
                return BadRequest();
            }
            var client = await _btcPayServerClientService.ConstructClient();
            if (!client.TestAccess(Facade.Merchant))
            {
                return BadRequest("btcpay payment provider not paired correctly");
            }

            var invoiceId = invoicePaymentNotification.Id;
            var invoice = await client.GetInvoiceAsync(invoiceId);

            var order = _orderRepository.Query().SingleAsync(order1 =>
                order1.Id.ToString().Equals(invoice.Id, StringComparison.InvariantCultureIgnoreCase));
            PaymentStatus status;
            if (invoice.ExpirationTime.ToUniversalTime() <= DateTimeOffset.UtcNow)
            {
                status = PaymentStatus.Failed;
            }else if (invoice.IsPaid())
            {
                status = PaymentStatus.Succeeded;
            }
            else
            {
                return Ok();
            }
            
            var payment = new Payment()
            {
                GatewayTransactionId = invoice.Id,
                OrderId = order.Id,
                Amount = invoice.Price,
                FailureMessage = invoice.ExceptionStatus?.ToString(),
                PaymentMethod = PaymentProviderConstants.BtcPayServerProviderId,
                CreatedOn = invoice.InvoiceTime.ToUniversalTime(),
                LatestUpdatedOn = DateTimeOffset.UtcNow,
                Status = status
            };
            _paymentRepository.Add(payment);
            _paymentRepository.SaveChanges();
            
            return Ok();
        }
    }
}
