﻿using System.Runtime.Serialization;

namespace D3apiData.API.Objects.Skill
{
    /// <summary>
    /// D3ApiServiceExample: FollowerSkill
    /// </summary>
    [DataContract]
    public class FollowerSkill : ErrorObject
    {
        /// <summary />
        [DataMember(Name = "skill")]
        public Skill Skill { get; set; }
    }
}