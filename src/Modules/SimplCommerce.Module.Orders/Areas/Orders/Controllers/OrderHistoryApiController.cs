using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Orders.Models;

namespace SimplCommerce.Module.Orders.Areas.Orders.Controllers
{
    [Area("Orders")]
    [Authorize(Roles = "admin, vendor")]
    public class OrderHistoryApiController : Controller
    {
        private readonly IRepository<OrderHistory> _orderHistoryRepository;
        private readonly IWorkContext _workContext;

        public OrderHistoryApiController(IRepository<OrderHistory> orderHistoryRepository, IWorkContext workContext)
        {
            _orderHistoryRepository = orderHistoryRepository;
            _workContext = workContext;
        }

        [HttpGet("api/orders/{orderId}/history")]
        public async Task<IActionResult> Get(long orderId)
        {
            var query = _orderHistoryRepository.Query()
                .Where(x => x.OrderId == orderId);

            var currentUser = await _workContext.GetCurrentUser();
            if (!User.IsInRole("admin"))
            {
                query = query.Where(x => x.Order.VendorId == currentUser.VendorId);
            }

            var histories = await query
                .Select(x => new
                {
                    OldStatus = x.OldStatus.ToString(),
                    NewStatus = x.NewStatus.ToString(),
                    CreatedById = x.CreatedById,
                    CreatedByFullName = x.CreatedBy.FullName,
                    x.Note,
                    x.CreatedOn
                }).ToListAsync();

            return Ok(histories);
        }
    }
}
