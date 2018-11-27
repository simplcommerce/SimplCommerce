using System.Runtime.Serialization;

namespace SimplCommerce.MSBuildTasks
{
    [DataContract]
    public class Module
    {
        [DataMember(Name ="id")]
        public string Id { get; set; }

        [DataMember(Name = "version")]
        public string Version { get; set; }
    }
}
