using System.Runtime.Serialization;

namespace D3apiData.API.Objects.Skill
{
    /// <summary>
    /// D3Api: Skill
    /// </summary>
    [DataContract]
    public class Skill : ErrorObject
    {
        /// <summary />
        [DataMember(Name = "slug")]
        public string Slug { get; set; }

        /// <summary />
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary />
        [DataMember(Name = "icon")]
        public string Icon { get; set; }

        /// <summary />
        [DataMember(Name = "level")]
        public int Level { get; set; }

        /// <summary />
        [DataMember(Name = "categorySlug")]
        public string CategorySlug { get; set; }

        /// <summary />
        [DataMember(Name = "tooltipUrl")]
        public string TooltipUrl { get; set; }

        /// <summary />
        [DataMember(Name = "description")]
        public string Description { get; set; }

        /// <summary />
        [DataMember(Name = "simpleDescription")]
        public string SimpleDescription { get; set; }

        /// <summary />
        [DataMember(Name = "skillCalcId")]
        public string SkillCalcId { get; set; }
    }
}