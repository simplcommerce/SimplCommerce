using System.Runtime.Serialization;

namespace SimplCommerce.MSBuildTasks
{
    [DataContract]
    public class ModuleManifest
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "isBundledWithHost")]
        public bool IsBundledWithHost { get; set; }

        [DataMember(Name = "version")]
        public string Version { get; set; }
    }
}
