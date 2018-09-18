using System.IO;
using System.IO.Compression;
using System.Linq;

namespace SimplCommerce.Infrastructure.Modules
{
    public sealed class ModuleManager
    {
        private const string _installedModulesFile = "modules.json";

        public static IModuleConfigurationManager Configuration => new ModuleConfigurationManager();

        public static void Install(string moduleName)
        {
            EnsureModuleDependencies(moduleName);
            ExtractModuleFiles(moduleName);
        }

        public static void Uninstall(string moduleName)
        {
            var moduleFolder = Path.Combine(GlobalConfiguration.ContentRootPath, "Modules", moduleName);
            //TODO: Unload module assembly
            Directory.Delete(moduleFolder);
        }

        private static void ExtractModuleFiles(string moduleName)
        {
            var modulePackageName = $"{moduleName}.zip";
            var modulePackagePath = Path.Combine(GlobalConfiguration.ContentRootPath, "Temps", modulePackageName);
            var moduleFolder = Path.Combine(GlobalConfiguration.ContentRootPath, "Modules", moduleName);
            if (File.Exists(modulePackagePath))
            {
                ZipFile.ExtractToDirectory(modulePackagePath, moduleFolder);
                Directory.Delete(modulePackagePath);
            }
            else
            {
                throw new FileNotFoundException($"The package file for the module '{moduleName}' is not found.", modulePackageName);
            }
        }

        private static void EnsureModuleDependencies(string moduleId)
        {
            var modules = Configuration.GetModules();
            var module = modules.Single(m => m.Id == moduleId);
            foreach (var dependency in module.Dependencies)
            {
                if (!modules.Select(m => m.Id).Contains(dependency))
                {
                    throw new ModuleNotFoundException(dependency);
                }
            }
        }
    }
}