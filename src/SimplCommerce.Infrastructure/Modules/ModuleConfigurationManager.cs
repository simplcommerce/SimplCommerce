using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace SimplCommerce.Infrastructure.Modules
{
    public class ModuleConfigurationManager : IModuleConfigurationManager
    {
        private static readonly string _installedModulesFilename = "modules.json";

        public IEnumerable<ModuleInfo> GetModules()
        {
            var installedModulesPath = Path.Combine(GlobalConfiguration.ContentRootPath, _installedModulesFilename);
            using (var reader = new StreamReader(installedModulesPath))
            {
                string content = reader.ReadToEnd();
                dynamic data = JsonConvert.DeserializeObject(content);
                foreach (dynamic module in data.modules)
                {
                    yield return new ModuleInfo
                    {
                        Id = module.id,
                        Version = Version.Parse(module.version.ToString())
                    };
                }
            }
        }
    }
}