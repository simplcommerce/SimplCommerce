using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using SimplCommerce.Infrastructure.Extensions;

namespace SimplCommerce.Module.HangfireJobs.Internal
{
    public class BackgroundJobCollection
    {
        private readonly Dictionary<Type, BackgroundJobDescriptor> _jobDescriptorsByArgsType;
        private readonly Dictionary<string, BackgroundJobDescriptor> _jobDescriptorsByName;

        public BackgroundJobCollection()
        {
            _jobDescriptorsByArgsType = new Dictionary<Type, BackgroundJobDescriptor>();
            _jobDescriptorsByName = new Dictionary<string, BackgroundJobDescriptor>();
        }

        public BackgroundJobDescriptor GetJob<TArgs>()
        {
            return GetJob(typeof(TArgs));
        }

        public BackgroundJobDescriptor GetJob(Type argsType)
        {
            var jobDescriptor = _jobDescriptorsByArgsType.GetOrDefault(argsType);

            if (jobDescriptor == null)
            {
                throw new Exception("Undefined background job for the job args type: " + argsType.AssemblyQualifiedName);
            }

            return jobDescriptor;
        }

        public BackgroundJobDescriptor GetJob(string name)
        {
            var jobDescriptor = _jobDescriptorsByName.GetOrDefault(name);

            if (jobDescriptor == null)
            {
                throw new Exception("Undefined background job for the job name: " + name);
            }

            return jobDescriptor;
        }

        public IReadOnlyList<BackgroundJobDescriptor> GetJobs()
        {
            return _jobDescriptorsByArgsType.Values.ToImmutableList();
        }

        public void AddJob<TJob>()
        {
            AddJob(typeof(TJob));
        }

        public void AddJob(Type jobType)
        {
            AddJob(new BackgroundJobDescriptor(jobType));
        }

        public void AddJob(BackgroundJobDescriptor jobDescriptor)
        {
            _jobDescriptorsByArgsType[jobDescriptor.ArgsType] = jobDescriptor;
            _jobDescriptorsByName[jobDescriptor.JobName] = jobDescriptor;
        }
    }
}
