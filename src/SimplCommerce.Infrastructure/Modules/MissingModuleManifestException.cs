using System;

namespace SimplCommerce.Infrastructure.Modules
{
    public class MissingModuleManifestException : Exception
    {
        public string ModuleName { get;}

        public MissingModuleManifestException()
        {

        }

        public MissingModuleManifestException(string message)
            : base(message)
        {

        }

        public MissingModuleManifestException(string message, string moduleName)
            :this(message)
        {
            ModuleName = moduleName;
        }
    }
}