using System.Runtime.Serialization;

namespace D3apiData.API.Objects.Skill
{
    /// <summary>
    /// D3Api: PassiveSkill
    /// </summary>
    [DataContract]
    public class PassiveSkill : ErrorObject
    {
        /// <summary />
        [DataMember(Name = "skill")]
        public Skill Skill { get; set; }
    }
}