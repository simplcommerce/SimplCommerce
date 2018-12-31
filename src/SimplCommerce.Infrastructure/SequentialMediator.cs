using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimplCommerce.Infrastructure
{
    public class SequentialMediator : Mediator
    {
        public SequentialMediator(ServiceFactory serviceFactory) : base(serviceFactory)
        {
        }

        protected async override Task PublishCore(IEnumerable<Func<Task>> allHandlers)
        {
            foreach (var allHandler in allHandlers)
            {
                await allHandler().ConfigureAwait(continueOnCapturedContext: false);
            }
        }
    }
}
