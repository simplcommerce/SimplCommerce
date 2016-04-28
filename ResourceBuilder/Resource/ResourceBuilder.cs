using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Shopcuatoi.Core.Domain.Models;

namespace ResourceBuilder.Resource
{
    public class ResourceBuilder
    {
        /// <summary>
        /// Generates a class with properties for each resource key
        /// </summary>
        /// <param name="provider">Resource provider instance</param>
        /// <param name="namespaceName">Name of namespace containing the resource class</param>
        /// <param name="className">Name of the class</param>
        /// <param name="filePath">Where to generate the source file</param>
        /// <param name="summaryCulture">If not null, adds a &lt;summary&gt; tag to each property using the specified culture.</param>
        /// <returns>Generated class file full path</returns>
        public string Create(ResourceProvider provider, string namespaceName = "Resources", string className = "Resources", string filePath = null, string summaryCulture = null)
        {
            // Retrieve all resources           
            MethodInfo method = provider.GetType().GetMethod("ReadResources", BindingFlags.Instance | BindingFlags.NonPublic);

            IList<ResourceEntry> resources = method.Invoke(provider, null) as List<ResourceEntry>;

            if (resources == null || resources.Count == 0)
                throw new Exception($"No resources were found in {provider.GetType().Name}");

            // Get a unique list of resource names (keys)
            var keys = resources.Select(r => r.Name).Distinct();

            #region Templates
            const string header =
@"using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resources.Abstract;
using Resources.Concrete;
    
namespace {0} {{
        public class {1} {{
            private static IResourceProvider resourceProvider = new {2}();

    {3}
        }}        
}}"; // {0}: namespace {1}:class name   {2}:provider class name   {3}: body  

            const string property =
@"
        {1}
        public static {2} {0} {{
               get {{
                   return resourceProvider.GetResource(""{0}"", CultureInfo.CurrentUICulture.Name) as {2};
               }}
            }}"; // {0}: key
            #endregion


            // store keys in a string builder
            var sbKeys = new StringBuilder();

            foreach (string key in keys)
            {
                var resource = resources.FirstOrDefault(r => (summaryCulture == null || r.Culture.ToLowerInvariant() == summaryCulture.ToLowerInvariant()) && r.Name == key);
                if (resource == null)
                {
                    throw new Exception($"Could not find resource {key}");
                }

                sbKeys.Append(new String(' ', 12)); // indentation
                sbKeys.AppendFormat(property, key,
                    summaryCulture == null ? string.Empty : string.Format("/// <summary>{0}</summary>", resource.Value),
                    resource.Type);
                sbKeys.AppendLine();
            }

            if (filePath == null)
                filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Resources.cs");
            // write to file
            using (var writer = File.CreateText(filePath))
            {

                // write header along with keys
                writer.WriteLine(header, namespaceName, className, provider.GetType().Name, sbKeys.ToString());

                writer.Flush();
                writer.Close();
            }

            return filePath;
        }


    }
}
