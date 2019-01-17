using System;
using System.Threading.Tasks;

namespace SimplCommerce.Module.HangfireJobs.Services
{
    /// <summary>
    /// Defines interface of a job manager.
    /// </summary>
    public interface IBackgroundJobManager
    {
        /// <summary>
        /// Enqueues a job to be executed. 
        /// </summary>
        /// <typeparam name="TArgs">Type of the arguments of job.</typeparam>
        /// <param name="args">Job arguments.</param>
        /// <param name="delay">Job delay (wait duration before first try).</param>
        /// <param name="enqueueAt">Schedules job to be enqueued at the given moment of time.</param>
        /// <exception cref="ArgumentException">delay and enqueueAt have both values.</exception>
        /// <returns>Unique identifier of a background job.</returns>
        Task<string> EnqueueAsync<TArgs>(TArgs args, TimeSpan? delay = null, DateTimeOffset? enqueueAt = null);
    }
}
