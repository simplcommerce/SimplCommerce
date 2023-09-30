using System;
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
using SimplCommerce.Module.Checkouts.Models;

namespace SimplCommerce.Module.Payments.Areas.Payments.Controllers
{
    [Area("Payments")]
    [Route("checkout")]
    [Authorize]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class CheckoutController : Controller
    {
        private readonly IRepositoryWithTypedId<PaymentProvider, string> _paymentProviderRepository;
        private readonly IRepositoryWithTypedId<Checkout, Guid> _checkoutRepository;
        private readonly IOrderService _orderService;
        private readonly IWorkContext _workContext;

        public CheckoutController(IRepositoryWithTypedId<PaymentProvider, string> paymentProviderRepository,
            IRepositoryWithTypedId<Checkout, Guid> checkoutRepository,
            IOrderService orderService,
            IWorkContext workContext)
        {
            _paymentProviderRepository = paymentProviderRepository;
            _checkoutRepository = checkoutRepository;
            _orderService = orderService;
            _workContext = workContext;
        }

        [HttpGet("{checkoutId}/payment")]
        public async Task<IActionResult> Payment(Guid checkoutId)
        {
            var currentUser = await _workContext.GetCurrentUser();
            var checkout = await _checkoutRepository.Query().FirstOrDefaultAsync(x => x.Id == checkoutId);
            if (checkout == null)
            {
                return NotFound();
            }

            if (checkout.CreatedBy != currentUser)
            {
                return Forbid();
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

            checkoutPaymentForm.CheckoutId = checkoutId;
            return View(checkoutPaymentForm);
        }
    }
}
