using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using SimplCommerce.Infrastructure.Domain.IRepositories;
using SimplCommerce.Orders.Domain.Models;
using SimplCommerce.Web.Areas.Admin.ViewModels.Orders;
using SimplCommerce.Web.Areas.Admin.ViewModels.SmartTable;

namespace SimplCommerce.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class OrderController : Controller
    {
        private readonly IRepository<Order> orderRepository;

        public OrderController(IRepository<Order> orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        [HttpPost]
        public ActionResult List([FromBody] SmartTableParam param)
        {
            var query = orderRepository.Query();

            var orders = query.ToSmartTableResult(
                param,
                order => new OrderListItem
                {
                    Id = order.Id,
                    CustomerName = order.CreatedBy.FullName,
                    SubTotal = order.SubTotal,
                    CreatedOn = order.CreatedOn
                });

            return Json(orders);
        }
    }
}