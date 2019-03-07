using MediatR;
using SimplCommerce.Module.Orders.Areas.Orders.ViewModels;

namespace SimplCommerce.Module.Orders.Events
{
    public class OrderDetailGot : INotification
    {
        public OrderDetailVm OrderDetailVm { get; set; }
    }
}
