using System;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Infrastructure.Helpers;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Orders.Models;
using SimplCommerce.Module.Orders.Services;
using SimplCommerce.Module.Payments.Models;
using SimplCommerce.Module.PaymentCashfree.Areas.PaymentCashfree.ViewModels;
using SimplCommerce.Module.PaymentCashfree.Models;
using SimplCommerce.Module.ShoppingCart.Services;
using Microsoft.AspNetCore.Http;
using SimplCommerce.Module.Checkouts.Services;

namespace SimplCommerce.Module.PaymentCashfree.Areas.PaymentCashfree.Controllers
{
    [Area("PaymentCashfree")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class CashfreeController : Controller
    {
        private readonly ICheckoutService _checkoutService;
        private readonly IOrderService _orderService;
        private readonly IWorkContext _workContext;
        private readonly IRepositoryWithTypedId<PaymentProvider, string> _paymentProviderRepository;
        private readonly IRepository<Payment> _paymentRepository;

        public CashfreeController(
            ICheckoutService checkoutService,
            IOrderService orderService,
            IWorkContext workContext,
            IRepositoryWithTypedId<PaymentProvider, string> paymentProviderRepository,
            IRepository<Payment> paymentRepository)
        {
            _checkoutService = checkoutService;
            _orderService = orderService;
            _workContext = workContext;
            _paymentProviderRepository = paymentProviderRepository;
            _paymentRepository = paymentRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Charge([FromForm] CashfreeResponse cashfreeResponse)
        {
            var cashfreeProvider = await _paymentProviderRepository.Query().FirstOrDefaultAsync(x => x.Id == PaymentProviderHelper.CashfreeProviderId);
            var cashfreeSetting = JsonConvert.DeserializeObject<CashfreeConfigForm>(cashfreeProvider.AdditionalSettings);
            // Check the response signature
            string data = "";
            data = data + cashfreeResponse.OrderId;
            data = data + cashfreeResponse.OrderAmount;
            data = data + cashfreeResponse.ReferenceId;
            data = data + cashfreeResponse.TxStatus;
            data = data + cashfreeResponse.PaymentMode;
            data = data + cashfreeResponse.TxMsg;
            data = data + cashfreeResponse.TxTime;
            var responseToken = PaymentProviderHelper.GetToken(data, cashfreeSetting.SecretKey);
            if (responseToken.Equals(cashfreeResponse.Signature))
            {
                var curentUser = await _workContext.GetCurrentUser();
                //TODO: pass checkout Id here
                var cart = await _checkoutService.GetCheckoutDetails(Guid.Empty);
                if (cart == null)
                {
                    return NotFound();
                }

                var checkoutId = Guid.NewGuid();
                var orderCreateResult = await _orderService.CreateOrder(checkoutId, cashfreeResponse.PaymentMode, 0, OrderStatus.PendingPayment);

                if (!orderCreateResult.Success)
                {
                    TempData["Error"] = orderCreateResult.Error;
                    return Redirect("~/checkout/payment");
                }

                var order = orderCreateResult.Value;
                var payment = new Payment()
                {
                    OrderId = order.Id,
                    Amount = order.OrderTotal,
                    PaymentMethod = PaymentProviderHelper.CashfreeProviderId + " - " + cashfreeResponse.PaymentMode,
                    CreatedOn = DateTimeOffset.UtcNow
                };

                if (cashfreeResponse.TxStatus == "SUCCESS")
                {
                    payment.GatewayTransactionId = cashfreeResponse.ReferenceId;
                    payment.Status = PaymentStatus.Succeeded;
                    order.OrderStatus = OrderStatus.PaymentReceived;
                    _paymentRepository.Add(payment);
                    await _paymentRepository.SaveChangesAsync();

                    return Ok(new { Status = "success", OrderId = order.Id });
                }
                else
                {
                    payment.GatewayTransactionId = cashfreeResponse.ReferenceId;
                    payment.Status = PaymentStatus.Failed;
                    payment.FailureMessage = cashfreeResponse.TxMsg;
                    order.OrderStatus = OrderStatus.PaymentFailed;
                    _paymentRepository.Add(payment);
                    await _paymentRepository.SaveChangesAsync();

                    var error = "Error: " + cashfreeResponse.TxStatus + " - " + cashfreeResponse.TxMsg;
                    return BadRequest(error);
                }
            }
            else
            {
                return BadRequest("PaymentTampered");
            }
        }
    }
}
