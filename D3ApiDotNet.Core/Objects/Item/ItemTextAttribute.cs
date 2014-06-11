using System.Runtime.Serialization;

namespace D3ApiDotNet.Core.Objects.Item
{
    /// <summary>
    /// D3ApiServiceExample: ItemTextAttribute
    /// </summary>
    [DataContract]
    public class ItemTextAttribute : ErrorObject
    {
        /// <summary />
        [DataMember(Name = "text")]
        public string Text { get; set; }

        /// <summary />
        [DataMember(Name = "affixType")]
        public string AffixType { get; set; }

        /// <summary />
        [DataMember(Name = "color")]
        public string Color { get; set; }
    }
}