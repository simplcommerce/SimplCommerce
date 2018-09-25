using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace SimplCommerce.MSBuildTasks
{
    public class CopyModules : Microsoft.Build.Utilities.Task
    {
        public override bool Execute()
        {
            var moduleString = "";
            var modules = new List<Module>();

            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(moduleString)))
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(modules.GetType());
                modules = ser.ReadObject(ms) as List<Module>;
            }

            return true;
        }
    }
}
