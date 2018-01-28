using MediatR;
using SimplCommerce.Module.Orders.ViewModels;

namespace SimplCommerce.Module.Orders.Events
{
    public class OrderDetailGot : INotification
    {
        public OrderDetailVm OrderDetailVm { get; set; }
    }
}
