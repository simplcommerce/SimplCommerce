using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SimplCommerce.Module.Orders.Services;

namespace SimplCommerce.Module.Orders.Events
{
    public class AfterOrderCreatedSendEmailHanlder : INotificationHandler<AfterOrderCreated>
    {
        private readonly IOrderEmailService _orderEmailService;

        public AfterOrderCreatedSendEmailHanlder(IOrderEmailService orderEmailService)
        {
            _orderEmailService = orderEmailService;
        }

        public async Task Handle(AfterOrderCreated notification, CancellationToken cancellationToken)
        {
            await _orderEmailService.SendEmailToUser(notification.Order.Customer, notification.Order);
        }
    }
}
