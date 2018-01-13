using System.Threading;
using System.Threading.Tasks;

namespace SimplCommerce.Infrastructure.ScheduledTasks
{
    public interface IScheduledTask
    {
        string Schedule { get; }
        Task ExecuteAsync(CancellationToken cancellationToken);
    }
}
