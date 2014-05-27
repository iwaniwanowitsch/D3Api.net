using System.Runtime.Serialization;

namespace D3apiData.API.Objects.Item
{
    /// <summary>
    /// D3Api: ItemTextAttributes
    /// </summary>
    [DataContract]
    public class ItemTextAttributes : ErrorObject
    {
        /// <summary />
        [DataMember(Name = "primary")]
        public ItemTextAttribute[] Primary { get; set; }

        /// <summary />
        [DataMember(Name = "secondary")]
        public ItemTextAttribute[] Secondary { get; set; }

        /// <summary />
        [DataMember(Name = "passive")]
        public ItemTextAttribute[] Passive { get; set; }
    }
}