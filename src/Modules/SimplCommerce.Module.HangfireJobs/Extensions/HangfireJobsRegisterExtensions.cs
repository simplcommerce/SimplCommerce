using System;
using System.Linq;
using System.Reflection;
using Hangfire;
using Hangfire.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SimplCommerce.Infrastructure.Helpers;
using SimplCommerce.Module.HangfireJobs.Internal;
using SimplCommerce.Module.HangfireJobs.Models;

namespace SimplCommerce.Module.HangfireJobs.Extensions
{
    public static class HangfireJobsRegisterExtensions
    {
        private static readonly MethodInfo _executeMethod = typeof(ScheduledJob).GetMethod(nameof(ScheduledJob.ExecuteAsync));

        /// <summary>
        /// Initialize all registered jobs
        /// </summary>
        /// <param name="app"></param>
        public static void InitializeHangfireJobs(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var sp = scope.ServiceProvider;
                var backgroundJobTypes = sp.GetRequiredService<BackgroundJobCollection>();

                var services = sp.GetRequiredService<IServiceCollection>().Where(x => x.ImplementationType != null);
                foreach (var item in services)
                {
                    var jobType = item.ImplementationType;

                    // Register Background Jobs
                    if (ReflectionHelper.IsAssignableToGenericType(jobType, typeof(IBackgroundJob<>)))
                    {
                        backgroundJobTypes.AddJob(jobType);
                    }

                    // Register Scheduled Jobs
                    if (typeof(ScheduledJob).IsAssignableFrom(jobType))
                    {
                        var job = (ScheduledJob)sp.GetService(jobType);
                        if (job == null)
                        {
                            throw new Exception("The job type is not registered to DI: " + jobType);
                        }

                        try
                        {
                            if (!string.IsNullOrEmpty(job.Schedule))
                            {
                                var _recurringJobManager = sp.GetService<IRecurringJobManager>();
                                _recurringJobManager.AddOrUpdate(jobType.Name, new Job(jobType, _executeMethod, null, null), job.Schedule);
                            }
                        }
                        catch (Exception ex)
                        {
                            throw new InvalidOperationException($"Unable to activate job {jobType.Name}.", ex);
                        }
                    }
                }
            }
        }
    }
}
