using System.Runtime.Serialization;

namespace D3ApiDotNet.Core.Objects.Hero
{
    /// <summary>
    /// D3ApiServiceExample: ActProgress
    /// </summary>
    [DataContract]
    public class ActProgress : ErrorObject
    {
        /// <summary />
        [DataMember(Name = "completed")]
        public bool Completed { get; set; }

        /// <summary />
        [DataMember(Name = "completedQuests")]
        public Quest[] CompletedQuests { get; set; }
    }
}