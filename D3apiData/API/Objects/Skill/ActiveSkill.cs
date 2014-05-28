using System.Runtime.Serialization;

namespace D3apiData.API.Objects.Skill
{
    /// <summary>
    /// D3ApiServiceExample: ActiveSkill
    /// </summary>
    [DataContract]
    public class ActiveSkill : ErrorObject
    {
        /// <summary />
        [DataMember(Name = "skill")]
        public Skill Skill { get; set; }

        /// <summary />
        [DataMember(Name = "rune")]
        public Rune Rune { get; set; }
    }
}