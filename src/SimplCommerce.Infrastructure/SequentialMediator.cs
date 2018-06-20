using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimplCommerce.Infrastructure
{
    public class SequentialMediator : Mediator
    {
        public SequentialMediator(ServiceFactory serviceFactory) : base(serviceFactory)
        {
        }

        protected async override Task PublishCore(IEnumerable<Task> allHandlers)
        {
            foreach(var handler in allHandlers)
            {
                await handler;
            }
        }
    }
}
