using System;

namespace SimplCommerce.Infrastructure.Modules
{
    public class ModuleNotFoundException : Exception
    {
        public string ModuleName { get;}

        public ModuleNotFoundException()
        {

        }

        public ModuleNotFoundException(string message)
            : base(message)
        {

        }

        public ModuleNotFoundException(string message, string moduleName)
            :this(message)
        {
            ModuleName = moduleName;
        }
    }
}