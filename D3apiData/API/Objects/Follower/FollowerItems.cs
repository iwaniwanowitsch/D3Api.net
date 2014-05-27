using System.Runtime.Serialization;
using D3apiData.API.Objects.Item;

namespace D3apiData.API.Objects.Follower
{
    /// <summary>
    /// D3Api: FollowerItems
    /// </summary>
    [DataContract]
    public class FollowerItems : ErrorObject
    {
        /// <summary />
        [DataMember(Name = "special")]
        public ItemSummary Special;

        /// <summary />
        [DataMember(Name = "mainHand")]
        public ItemSummary MainHand;

        /// <summary />
        [DataMember(Name = "offHand")]
        public ItemSummary OffHand;

        /// <summary />
        [DataMember(Name = "rightFinger")]
        public ItemSummary RightFinger;

        /// <summary />
        [DataMember(Name = "leftFinger")]
        public ItemSummary LeftFinger;

        /// <summary />
        [DataMember(Name = "neck")]
        public ItemSummary Neck;
    }
}