using System.Runtime.Serialization;
using D3apiData.API.Objects.Item;

namespace D3apiData.API.Objects.Artisan
{
    /// <summary>
    /// D3ApiServiceExample: Recipe
    /// </summary>
    [DataContract]
    public class Recipe : ErrorObject
    {
        /// <summary />
        [DataMember(Name = "id")]
        public string Id { get; set; }

        /// <summary />
        [DataMember(Name = "slug")]
        public string Slug { get; set; }

        /// <summary />
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary />
        [DataMember(Name = "cost")]
        public int Cost { get; set; }

        /// <summary />
        [DataMember(Name = "reagents")]
        public Reagent[] Reagents { get; set; }

        /// <summary />
        [DataMember(Name = "itemProduced")]
        public ItemSummary ItemProduced { get; set; }
    }
}