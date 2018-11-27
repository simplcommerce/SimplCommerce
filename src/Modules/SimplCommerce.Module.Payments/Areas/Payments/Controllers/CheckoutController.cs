using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Orders.Services;
using SimplCommerce.Module.Payments.Areas.Payments.ViewModels;
using SimplCommerce.Module.Payments.Models;
using SimplCommerce.Module.ShoppingCart.Models;
using SimplCommerce.Module.ShoppingCart.Services;

namespace SimplCommerce.Module.Payments.Areas.Payments.Controllers
{
    [Area("Payments")]
    [Route("checkout")]
    [Authorize]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class CheckoutController : Controller
    {
        private readonly IRepositoryWithTypedId<PaymentProvider, string> _paymentProviderRepository;
        private readonly ICartService _cartService;
        private readonly IOrderService _orderService;
        private readonly IWorkContext _workContext;

        public CheckoutController(IRepositoryWithTypedId<PaymentProvider, string> paymentProviderRepository,
            ICartService cartService,
            IOrderService orderService,
            IWorkContext workContext)
        {
            _paymentProviderRepository = paymentProviderRepository;
            _cartService = cartService;
            _orderService = orderService;
            _workContext = workContext;
        }

        [HttpGet("payment")]
        public async Task<IActionResult> Payment()
        {
            var currentUser = await _workContext.GetCurrentUser();
            var cart = await _cartService.GetActiveCart(currentUser.Id).FirstOrDefaultAsync();
            if(cart == null)
            {
                return Redirect("~/");
            }

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
    }
}
