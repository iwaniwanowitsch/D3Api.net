﻿using System.Runtime.Serialization;
using D3apiData.API.Objects.Skill;

namespace D3apiData.API.Objects.Follower
{
    /// <summary>
    /// D3Api: Follower
    /// </summary>
    [DataContract]
    public class Follower : ErrorObject
    {
        /// <summary />
        [DataMember(Name = "slug")]
        public string Slug { get; set; }

        /// <summary />
        [DataMember(Name = "level")]
        public int Level { get; set; }

        /// <summary />
        [DataMember(Name = "items")]
        public FollowerItems Items { get; set; }

        /// <summary />
        [DataMember(Name = "stats")]
        public FollowerStats Stats { get; set; }

        /// <summary />
        [DataMember(Name = "skills")]
        public FollowerSkill[] Skills { get; set; }
    }
}