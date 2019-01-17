using System;
using System.Threading.Tasks;
using Hangfire;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using SimplCommerce.Module.HangfireJobs.Internal;
using SimplCommerce.Module.HangfireJobs.Models;

namespace SimplCommerce.Module.HangfireJobs.Services
{
    public class BackgroundJobManager : IBackgroundJobManager
    {
        public ILogger<BackgroundJobManager> Logger { protected get; set; }

        protected BackgroundJobCollection Jobs { get; }
        protected IServiceScopeFactory ServiceScopeFactory { get; }

        public BackgroundJobManager(
            BackgroundJobCollection jobs,
            IServiceScopeFactory serviceScopeFactory)
        {
            Logger = NullLogger<BackgroundJobManager>.Instance;

            ServiceScopeFactory = serviceScopeFactory;
            Jobs = jobs;
        }

        /// <inheritdoc />
        public Task<string> EnqueueAsync<TArgs>(TArgs args, TimeSpan? delay = null, DateTimeOffset? enqueueAt = null)
        {
            if (delay.HasValue && enqueueAt.HasValue)
            {
                throw new ArgumentException($"{nameof(delay)} and {nameof(enqueueAt)} can't have both values.");
            }

            using (var scope = ServiceScopeFactory.CreateScope())
            {
                string jobId;
                var jobType = Jobs.GetJob(typeof(TArgs)).JobType;
                var job = (IBackgroundJob<TArgs>)scope.ServiceProvider.GetService(jobType);
                if (job == null)
                {
                    throw new Exception("The job type is not registered to DI: " + jobType);
                }

                try
                {
                    if (delay.HasValue)
                    {
                        jobId = BackgroundJob.Schedule(() => job.Execute(args), delay.Value);
                    }
                    else if (enqueueAt.HasValue)
                    {
                        jobId = BackgroundJob.Schedule(() => job.Execute(args), enqueueAt.Value);
                    }
                    else
                    {
                        jobId = BackgroundJob.Enqueue(() => job.Execute(args));
                    }
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex, $"Failed executing job {GetType().Name}: {ex.Message}");
                    throw;
                }

                return Task.FromResult(jobId);
            }
        }
    }
}
