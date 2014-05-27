using System.Runtime.Serialization;

namespace D3apiData.API.Objects.Item
{
    /// <summary>
    /// D3Api: ItemType
    /// </summary>
    [DataContract]
    public class ItemType : ErrorObject
    {
        /// <summary />
        [DataMember(Name = "twoHanded")]
        public bool TwoHanded { get; set; }

        /// <summary />
        [DataMember(Name = "id")]
        public string Id { get; set; }
    }
}