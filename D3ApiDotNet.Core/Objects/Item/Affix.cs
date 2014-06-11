using System.Runtime.Serialization;

namespace D3ApiDotNet.Core.Objects.Item
{
    /// <summary>
    /// D3ApiServiceExample: Affix
    /// </summary>
    [DataContract]
    public class Affix : ErrorObject
    {
        /// <summary />
        [DataMember(Name = "attributes")]
        public ItemTextAttributes Attributes { get; set; }

        /// <summary />
        [DataMember(Name = "attributesRaw")]
        public ItemAttributes AttributesRaw { get; set; }
    }
}