using System;
using System.Threading.Tasks;
using Hangfire;
using Hangfire.Server;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace SimplCommerce.Module.HangfireJobs.Models
{
    /// <summary>
    /// Base class for Hangfire jobs which provides auto-scheduling and logging.
    /// </summary>
    public abstract class ScheduledJob
    {
        /// <summary>
        /// Gets the <see cref="ILogger"/> instance for this job.
        /// </summary>
        public ILogger<ScheduledJob> Logger { get; set; }

        /// <summary>
        /// Gets the schedule for automatically scheduled jobs.
        /// Default is null which means that the job is not automatically scheduled.
        /// </summary>
        public virtual string Schedule => null;

        /// <summary>
        /// Initializes the <see cref="ScheduledJob"/>.
        /// </summary>
        protected ScheduledJob()
        {
            Logger = NullLogger<ScheduledJob>.Instance;
        }

        /// <summary>
        /// Executes the job.
        /// </summary>
        /// <param name="performContext">
        /// The context in which the job is performed. Populated by Hangfire.
        /// It is safe to pass <c>null</c> in unit tests or other manual scenarios.
        /// </param>
        /// <param name="cancellationToken">
        /// The <see cref="IJobCancellationToken"/>. Populated by Hangfire.
        /// It is safe to pass <c>null</c> in unit tests or other manual scenarios,
        /// a new instance of <see cref="JobCancellationToken"/> will be created in that case.
        /// </param>
        public async Task ExecuteAsync(PerformContext performContext, IJobCancellationToken cancellationToken)
        {
            var jobId = performContext?.BackgroundJob?.Id;

            cancellationToken?.ThrowIfCancellationRequested();

            Logger.LogDebug($"Starting job {jobId}");
            try
            {
                await ExecuteAsync(cancellationToken ?? new JobCancellationToken(false));
                Logger.LogDebug($"Finished job {jobId}");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Failed executing job {jobId}/{GetType().Name}: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Executes the inner logic of the job.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="IJobCancellationToken"/>.</param>
        protected abstract Task ExecuteAsync(IJobCancellationToken cancellationToken);

    }
}
