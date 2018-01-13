using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace SimplCommerce.Infrastructure.ScheduledTasks
{
    public static class SchedulerTasksExtensions
    {
        public static IServiceCollection AddScheduler(this IServiceCollection services)
        {
            return services.AddSingleton<IHostedService, SchedulerBackgroundService>();
        }

        public static IServiceCollection AddScheduler(this IServiceCollection services, EventHandler<UnobservedTaskExceptionEventArgs> unobservedTaskExceptionHandler)
        {
            return services.AddSingleton<IHostedService, SchedulerBackgroundService>(serviceProvider =>
            {
                var instance = new SchedulerBackgroundService(serviceProvider.GetServices<IScheduledTask>());
                instance.UnobservedTaskException += unobservedTaskExceptionHandler;
                return instance;
            });
        }
    }
}
