using System.Runtime.Serialization;
using D3apiData.API.Objects.Artisan;

namespace D3apiData.API.Objects.Item
{
    /// <summary>
    /// D3Api: ItemSummary
    /// </summary>
    [DataContract]
    public class ItemSummary : ErrorObject
    {
        /// <summary />
        [DataMember(Name = "id")]
        public string Id { get; set; }

        /// <summary />
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary />
        [DataMember(Name = "icon")]
        public string Icon { get; set; }

        /// <summary />
        [DataMember(Name = "displayColor")]
        public string DisplayColor { get; set; }

        /// <summary />
        [DataMember(Name = "tooltipParams")]
        public string TooltipParams { get; set; }

        /// <summary />
        [DataMember(Name = "randomAffixes")]
        public RandomAffix[] RandomAffixes { get; set; }

        /// <summary />
        [DataMember(Name = "recipe")]
        public Recipe Recipe { get; set; }

        /// <summary />
        [DataMember(Name = "craftedBy")]
        public Recipe[] CraftedBy { get; set; }
    }
}