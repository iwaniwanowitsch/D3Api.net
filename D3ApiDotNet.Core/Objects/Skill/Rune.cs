#region

using System.Runtime.Serialization;

#endregion

namespace D3ApiDotNet.Core.Objects.Skill
{
    /// <summary>
    /// D3ApiServiceExample: Rune
    /// </summary>
    [DataContract]
    public class Rune : ErrorObject
    {
        /// <summary />
        [DataMember(Name = "slug")]
        public string Slug { get; set; }

        /// <summary />
        [DataMember(Name = "type")]
        public string Type { get; set; }

        /// <summary />
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary />
        [DataMember(Name = "level")]
        public int Level { get; set; }

        /// <summary />
        [DataMember(Name = "description")]
        public string Description { get; set; }

        /// <summary />
        [DataMember(Name = "simpleDescription")]
        public string SimpleDescription { get; set; }

        /// <summary />
        [DataMember(Name = "tooltipParams")]
        public string TooltipParams { get; set; }

        /// <summary />
        [DataMember(Name = "skillCalcId")]
        public string SkillCalcId { get; set; }

        /// <summary />
        [DataMember(Name = "order")]
        public int Order { get; set; }
    }
}