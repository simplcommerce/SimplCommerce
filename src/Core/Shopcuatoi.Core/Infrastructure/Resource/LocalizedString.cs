using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shopcuatoi.Core.Infrastructure.Resource;
    
namespace Shopcuatoi.Core.Infrastructure.Resource {
        public class LocalizeString {
            private static IResourceProvider resourceProvider = new DbResourceProvider();

                
        /// <summary>Home Page</summary>
        public static string HomePage {
               get {
                   return resourceProvider.GetResource("HomePage", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Administration</summary>
        public static string Administration {
               get {
                   return resourceProvider.GetResource("Administration", CultureInfo.CurrentUICulture.Name) as string;
               }
            }

        }        
}
