using System;
using SimplCommerce.Module.HangfireJobs.Models;

namespace SimplCommerce.Module.HangfireJobs.Internal
{
    public static class BackgroundJobArgsHelper
    {
        public static Type GetJobArgsType(Type jobType)
        {
            foreach (var @interface in jobType.GetInterfaces())
            {
                if (!@interface.IsGenericType)
                {
                    continue;
                }

                if (@interface.GetGenericTypeDefinition() != typeof(IBackgroundJob<>))
                {
                    continue;
                }

                var genericArgs = @interface.GetGenericArguments();
                if (genericArgs.Length != 1)
                {
                    continue;
                }

                return genericArgs[0];
            }

            throw new Exception($"Could not find type of the job args. Ensure that given type implements the {typeof(IBackgroundJob<>).AssemblyQualifiedName} interface. Given job type: {jobType.AssemblyQualifiedName}");
        }
    }
}
