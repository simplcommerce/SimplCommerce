using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimplCommerce.Infrastructure
{
    public class SequentialMediator : Mediator
    {
        public SequentialMediator(SingleInstanceFactory singleInstanceFactory, MultiInstanceFactory multiInstanceFactory) : base(singleInstanceFactory, multiInstanceFactory)
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
