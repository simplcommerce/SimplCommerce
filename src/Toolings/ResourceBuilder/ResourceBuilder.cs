using System;
using System.IO;
using System.Linq;
using System.Text;
using SimplCommerce.Core.Infrastructure.Localization;

namespace ResourceBuilder
{
    public class ResourceBuilder
    {
        /// <summary>
        ///     Generates a class with properties for each resource key
        /// </summary>
        /// <param name="provider">Resource provider instance</param>
        /// <param name="namespaceName">Name of namespace containing the resource class</param>
        /// <param name="className">Name of the class</param>
        /// <param name="summaryCulture">If not null, adds a &lt;summary&gt; tag to each property using the specified culture.</param>
        /// <returns>Generated class file full path</returns>
        public string GenerateStrongTypeResource(ResourceProviderBase provider, string namespaceName, string className,
            string filePath, string summaryCulture = null)
        {
            var resources = provider.ReadResources();

            if (resources == null || resources.Count == 0)
                throw new Exception($"No resources were found in {provider.GetType().Name}");

            // Get a unique list of resource names (keys)
            var keys = resources.Select(r => r.Key).Distinct();

            const string headerTemplate =
                @"using System.Globalization;

namespace {0}
{{
    public class {1}
    {{
        private static ResourceProviderBase resourceProvider = new {2}();
{3}
    }}
}}"; // {0}: namespace, {1}:class name, {2}:provider, {3}: body

            const string propertyTemplate =
                @"{1}
        public static string {0}
        {{
            get
            {{
                return resourceProvider.GetResource(""{0}"", CultureInfo.CurrentUICulture.Name);
            }}
        }}";

            var sbKeys = new StringBuilder();

            foreach (var key in keys)
            {
                var resourceForSumaryDoc =
                    resources.FirstOrDefault(
                        r =>
                            (summaryCulture == null ||
                             string.Equals(r.Culture, summaryCulture, StringComparison.InvariantCultureIgnoreCase)) &&
                            r.Key == key);
                if (resourceForSumaryDoc == null)
                {
                    throw new Exception($"Could not find resource {key}");
                }

                sbKeys.AppendLine();
                sbKeys.AppendLine();
                sbKeys.Append(new string(' ', 8)); // indentation
                sbKeys.AppendFormat(
                    propertyTemplate,
                    key,
                    summaryCulture == null ? string.Empty : $"/// <summary>{resourceForSumaryDoc.Value}</summary>"
                    );
            }

            using (var writer = File.CreateText(filePath))
            {
                writer.WriteLine(
                    headerTemplate,
                    namespaceName,
                    className,
                    provider.GetType().Name,
                    sbKeys);

                writer.Flush();
                writer.Close();
            }

            return filePath;
        }
    }
}