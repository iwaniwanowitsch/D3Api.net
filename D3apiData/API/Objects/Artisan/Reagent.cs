using System.Runtime.Serialization;
using D3apiData.API.Objects.Item;

namespace D3apiData.API.Objects.Artisan
{
    /// <summary>
    /// D3Api: Reagant
    /// </summary>
    [DataContract]
    public class Reagent : ErrorObject
    {
        /// <summary />
        [DataMember(Name = "quantity")]
        public int Quantity { get; set; }

        /// <summary />
        [DataMember(Name = "item")]
        public ItemSummary Item { get; set; }
    }
}