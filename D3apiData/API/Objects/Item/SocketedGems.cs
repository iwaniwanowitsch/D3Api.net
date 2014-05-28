using System.Runtime.Serialization;

namespace D3apiData.API.Objects.Item
{
    /// <summary>
    /// D3ApiServiceExample: SocketedGems
    /// </summary>
    [DataContract]
    public class SocketedGems : ErrorObject
    {
        /// <summary />
        [DataMember(Name = "item")]
        public ItemSummary Item { get; set; }

        /// <summary />
        [DataMember(Name = "attributesRaw")]
        public ItemAttributes AttributesRaw { get; set; }

        /// <summary />
        [DataMember(Name = "attributes")]
        public ItemTextAttributes Attributes { get; set; }
    }
}