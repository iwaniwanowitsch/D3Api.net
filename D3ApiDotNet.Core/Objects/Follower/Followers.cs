using System.Runtime.Serialization;

namespace D3ApiDotNet.Core.Objects.Follower
{
    /// <summary>
    /// D3ApiServiceExample: Followers
    /// </summary>
    [DataContract]
    public class Followers : ErrorObject
    {
        /// <summary />
        [DataMember(Name = "templar")]
        public Follower Templar { get; set; }

        /// <summary />
        [DataMember(Name = "scoundrel")]
        public Follower Scoundrel { get; set; }

        /// <summary />
        [DataMember(Name = "enchantress")]
        public Follower Enchantress { get; set; }
    }
}