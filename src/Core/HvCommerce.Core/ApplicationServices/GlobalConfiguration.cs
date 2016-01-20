using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HvCommerce.Core.ApplicationServices
{
    public static class GlobalConfiguration
    {
        static GlobalConfiguration()
        {
            Modules = new List<HvModule>();
        }

        public static string ConnectionString { get; set; }

        public static IList<HvModule> Modules { get; set; }
    }
}
