using System.Runtime.Serialization;

namespace D3apiData.API.Objects.Item
{
    /// <summary>
    /// D3ApiServiceExample: SetRank
    /// </summary>
    [DataContract]
    public class SetRank : ErrorObject
    {
        /// <summary />
        [DataMember(Name = "required")]
        public int Required;

        /// <summary />
        [DataMember(Name = "attributes")]
        public ItemTextAttributes Attributes;

        /// <summary />
        [DataMember(Name = "attributesRaw")]
        public ItemAttributes AttributesRaw;
    }
}