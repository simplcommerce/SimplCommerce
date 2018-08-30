using System.Collections.Generic;

namespace SimplCommerce.Infrastructure
{
    public class AdminUI
    {
        public IList<string> Stylesheets { get; set; } = new List<string>();

        public IList<string> Scripts { get; set; } = new List<string>();

        public string FrontendModuleName { get; set; }

        public IList<MenuItem> MenuItems { get; set; } = new List<MenuItem>();
    }
}
