using System.Runtime.Serialization;

namespace D3apiData.API.Objects.Item
{
    /// <summary>
    /// D3ApiServiceExample: ItemSalvageComponent
    /// </summary>
    [DataContract]
    public class ItemSalvageComponent : ErrorObject
    {
        /// <summary />
        [DataMember(Name = "chance")]
        public double Chance;

        /// <summary />
        [DataMember(Name = "item")]
        public ItemSummary Item;

        /// <summary />
        [DataMember(Name = "quantity")]
        public int Quantity;
    }
}