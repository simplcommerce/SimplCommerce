using Microsoft.AspNetCore.Mvc;
using Stripe;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Orders.Services;
using SimplCommerce.Module.ShoppingCart.Models;
using System.Threading.Tasks;

namespace SimplCommerce.Module.PaymentStripe.Controllers
{
    public class StripeController : Controller
    {
        private readonly IRepository<Cart> _cartRepository;
        private readonly IOrderService _orderService;
        private readonly IWorkContext _workContext;

        public StripeController(
            IRepository<Cart> cartRepository,
            IOrderService orderService,
            IWorkContext workContext)
        {
            _cartRepository = cartRepository;
            _orderService = orderService;
            _workContext = workContext;
        }

        public async Task<IActionResult> Charge(string stripeEmail, string stripeToken)
        {
            var customers = new StripeCustomerService();
            var charges = new StripeChargeService();
            var currentUser = await _workContext.GetCurrentUser();

            var customer = customers.Create(new StripeCustomerCreateOptions
            {
                Email = stripeEmail,
                SourceToken = stripeToken
            });

            var charge = charges.Create(new StripeChargeCreateOptions
            {
                Amount = 500,
                Description = "Sample Charge",
                Currency = "usd",
                CustomerId = customer.Id
            });

            await _orderService.CreateOrder(currentUser, "Stripe");

            return View();
        }
    }
}
