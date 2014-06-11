#region

using System.Runtime.Serialization;
using D3ApiDotNet.Core.Objects.Item;

#endregion

namespace D3ApiDotNet.Core.Objects.Artisan
{
    /// <summary>
    /// D3ApiServiceExample: Reagant
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