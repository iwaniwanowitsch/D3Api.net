using System.Runtime.Serialization;

namespace D3apiData.API.Objects.Item
{
    /// <summary>
    /// D3Api: ItemTextAttribute
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