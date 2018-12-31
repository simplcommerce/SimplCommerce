using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace SimplCommerce.MSBuildTasks
{
    public class CopyModuleTask : Task
    {
        [Required]
        public string ProjectDir { get; set; }

        [Required]
        public string BuildConfiguration { get; set; }

        [Required]
        public string TargetFramework { get; set; }

        public override bool Execute()
        {
            var modulesFileName = "modules.json";
            var moduleFileName = "module.json";
            var modulesFilePath = Path.Combine(ProjectDir, modulesFileName);
            if (!File.Exists(modulesFilePath))
            {
                Log.LogError($"{modulesFileName} is not fould");
                return false;
            }

            var modules = new List<Module>();
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(File.ReadAllText(modulesFileName))))
            {
                var ser = new DataContractJsonSerializer(modules.GetType());
                modules = ser.ReadObject(ms) as List<Module>;
            }

            foreach (var module in modules)
            {
                var sourceRoot = Path.Combine(new DirectoryInfo(ProjectDir).Parent.FullName, "Modules", module.Id);
                var moduleManifestFile = Path.Combine(sourceRoot, moduleFileName);
                if (!File.Exists(moduleManifestFile))
                {
                    Log.LogError($"{moduleFileName} is not fould for {module.Id}");
                    return false;
                }

                ModuleManifest moduleManifest = null;
                using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(File.ReadAllText(moduleManifestFile))))
                {
                    var ser = new DataContractJsonSerializer(typeof(ModuleManifest));
                    moduleManifest = ser.ReadObject(ms) as ModuleManifest;
                }

                var destination = Path.Combine(ProjectDir, "Modules", module.Id);
                var destinationWwwroot = Path.Combine(ProjectDir, "wwwroot", "modules", module.Id.Split('.').Last().ToLower());

                CreateOrCleanDirectory(destinationWwwroot);
                CreateOrCleanDirectory(destination);

                File.Copy(Path.Combine(sourceRoot, moduleFileName),
                    Path.Combine(destination, moduleFileName), true);
                CopyDirectory(Path.Combine(sourceRoot, "wwwroot"), destinationWwwroot);
                if (!moduleManifest.IsBundledWithHost)
                {
                    CopyDirectory(Path.Combine(sourceRoot, "bin", BuildConfiguration, TargetFramework), Path.Combine(destination, "bin"));
                }

                if (module.Id == "SimplCommerce.Module.SampleData")
                {
                    CopyDirectory(Path.Combine(sourceRoot, "SampleContent"), Path.Combine(destination, "SampleContent"));
                }

                Log.LogMessage(MessageImportance.High, $"Copied module {module.Id}");
            }

            return true;
        }

        private void CreateOrCleanDirectory(string path)
        {
            if (Directory.Exists(path))
            {
                var di = new DirectoryInfo(path);
                foreach (var file in di.GetFiles())
                {
                    file.Delete();
                }
                foreach (var dir in di.GetDirectories())
                {
                    dir.Delete(true);
                }
            }
            else
            {
                Directory.CreateDirectory(path);
            }
        }

        private void CopyDirectory(string sourcePath, string targetPath)
        {
            if (!Directory.Exists(sourcePath))
            {
                return;
            }

            CopyAll(new DirectoryInfo(sourcePath), new DirectoryInfo(targetPath));
        }

        private void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            Directory.CreateDirectory(target.FullName);

            foreach (var file in source.GetFiles())
            {
                file.CopyTo(Path.Combine(target.FullName, file.Name), true);
            }

            foreach (var subDirectory in source.GetDirectories())
            {
                var nextTargetSubDir = target.CreateSubdirectory(subDirectory.Name);
                CopyAll(subDirectory, nextTargetSubDir);
            }
        }
    }
}
