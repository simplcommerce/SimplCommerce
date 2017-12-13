using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Core.Models;
using SimplCommerce.Module.Orders.Services;
using SimplCommerce.Module.Orders.ViewModels;
using SimplCommerce.Module.Payments.Models;
using SimplCommerce.Module.Payments.Services;
using SimplCommerce.Module.Payments.ViewModels;
using SimplCommerce.Module.ShoppingCart.Models;

namespace SimplCommerce.Module.Payments.Controllers
{
    [Route("checkout")]
    [Authorize]
    public class CheckoutController : Controller
    {
        private readonly IRepository<PaymentProvider> _paymentProviderRepository;
        private readonly IRepository<Cart> _cartRepository;
        private readonly IOrderService _orderService;
        private readonly IWorkContext _workContext;

        public CheckoutController(IRepository<PaymentProvider> paymentProviderRepository,
            IRepository<Cart> cartRepository,
            IOrderService orderService,
            IWorkContext workContext)
        {
            _paymentProviderRepository = paymentProviderRepository;
            _cartRepository = cartRepository;
            _orderService = orderService;
            _workContext = workContext;
        }

        [HttpGet("payment")]
        public async Task<IActionResult> Payment()
        {
            var checkoutPaymentForm = new CheckoutPaymentForm();
            checkoutPaymentForm.PaymentProviders = await _paymentProviderRepository.Query()
                .Where(x => x.IsEnabled)
                .Select(x => new PaymentProviderVm
                {
                    Id = x.Id,
                    Name = x.Name,
                    LandingViewComponentName = x.LandingViewComponentName
                }).ToListAsync();

            return View(checkoutPaymentForm);
        }

        [HttpPost("payment")]
        public async Task<IActionResult> Payment(IFormCollection formCollection)
        {
            var selectedPaymentMethod = "";
            var currentUser = await _workContext.GetCurrentUser();
            //var provider = _paymentProviderRepository.Query().Where(x => x.Name == selectedPaymentMethod).FirstOrDefault();
            //var paymentProviderServiceType = Type.GetType(provider.PaymentProviderTypeName);
            //var paymentServiceProviders = HttpContext.RequestServices.GetServices<IPaymentServiceProvider>();
            //var paymentProviderService = paymentServiceProviders.Where(x => x.GetType() == paymentProviderServiceType).FirstOrDefault();

            //var response = await paymentProviderService.ProcessPaymentPreOrder(new ProcessPaymentRequest());
            //if (response.IsSuccess)
            //{
                await _orderService.CreateOrder(currentUser, selectedPaymentMethod);
            //    await paymentProviderService.ProcessPaymentPostOrder();
            //}

            return Redirect("~/checkout/congratulation");
        }
    }
}
