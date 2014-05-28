using System.Runtime.Serialization;

namespace D3apiData.API.Objects.Hero
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