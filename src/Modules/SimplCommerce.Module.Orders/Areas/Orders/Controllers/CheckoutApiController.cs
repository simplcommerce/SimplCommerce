using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SimplCommerce.Module.Orders.Areas.Orders.Controllers
{
    [Area("ShoppingCart")]
    [Authorize(Roles = "admin")]
    public class CheckoutApiController : Controller
    {
    }
}
