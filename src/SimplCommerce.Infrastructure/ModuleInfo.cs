using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SimplCommerce.Infrastructure
{
    public class ModuleInfo
    {
        public string Name { get; set; }

        public Assembly Assembly { get; set; }

        public string ShortName
        {
            get
            {
                return Name.Split('.').Last();
            }
        }

        public string Path { get; set; }

        public IList<string> Dependencies { get; set; } = new List<string>();

        public ModuleUI UI { get; set; } = new ModuleUI();
    }
}
