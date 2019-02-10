using System;

namespace SimplCommerce.Module.HangfireJobs.Internal
{
    public class BackgroundJobDescriptor
    {
        public Type ArgsType { get; }

        public Type JobType { get; }

        public string JobName { get; }     //TODO: can custom job name

        public BackgroundJobDescriptor(Type jobType)
        {
            JobType = jobType;
            ArgsType = BackgroundJobArgsHelper.GetJobArgsType(jobType);
            JobName = JobType.FullName;
        }
    }
}
