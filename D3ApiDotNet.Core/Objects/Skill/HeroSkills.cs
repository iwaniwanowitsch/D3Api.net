using System.Runtime.Serialization;

namespace D3ApiDotNet.Core.Objects.Skill
{
    /// <summary>
    /// D3ApiServiceExample: HeroSkills
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