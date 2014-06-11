#region

using System.Runtime.Serialization;
using D3ApiDotNet.Core.Objects.Item;

#endregion

namespace D3ApiDotNet.Core.Objects.Hero
{
    /// <summary>
    /// D3ApiServiceExample: HeroItems
    /// </summary>
    [DataContract]
    public class HeroItems : ErrorObject
    {
        /// <summary />
        [DataMember(Name = "head")]
        public ItemSummary Head { get; set; }

        /// <summary />
        [DataMember(Name = "torso")]
        public ItemSummary Torso { get; set; }

        /// <summary />
        [DataMember(Name = "feet")]
        public ItemSummary Feet { get; set; }

        /// <summary />
        [DataMember(Name = "hands")]
        public ItemSummary Hands { get; set; }

        /// <summary />
        [DataMember(Name = "shoulders")]
        public ItemSummary Shoulders { get; set; }

        /// <summary />
        [DataMember(Name = "legs")]
        public ItemSummary Legs { get; set; }

        /// <summary />
        [DataMember(Name = "bracers")]
        public ItemSummary Bracers { get; set; }

        /// <summary />
        [DataMember(Name = "mainHand")]
        public ItemSummary MainHand { get; set; }

        /// <summary />
        [DataMember(Name = "offHand")]
        public ItemSummary OffHand { get; set; }

        /// <summary />
        [DataMember(Name = "waist")]
        public ItemSummary Waist { get; set; }

        /// <summary />
        [DataMember(Name = "rightFinger")]
        public ItemSummary RightFinger { get; set; }

        /// <summary />
        [DataMember(Name = "leftFinger")]
        public ItemSummary LeftFinger { get; set; }

        /// <summary />
        [DataMember(Name = "neck")]
        public ItemSummary Neck { get; set; }
    }
}