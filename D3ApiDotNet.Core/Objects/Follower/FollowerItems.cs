#region

using System.Runtime.Serialization;
using D3ApiDotNet.Core.Objects.Item;

#endregion

namespace D3ApiDotNet.Core.Objects.Follower
{
    /// <summary>
    /// D3ApiServiceExample: FollowerItems
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