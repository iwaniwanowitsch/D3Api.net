using System.Runtime.Serialization;

namespace D3apiData.API.Objects.Skill
{
    /// <summary>
    /// D3Api: HeroSkills
    /// </summary>
    [DataContract]
    public class HeroSkills : ErrorObject
    {
        /// <summary />
        [DataMember(Name = "active")]
        public ActiveSkill[] Active { get; set; }

        /// <summary />
        [DataMember(Name = "passive")]
        public PassiveSkill[] Passive { get; set; }
    }
}