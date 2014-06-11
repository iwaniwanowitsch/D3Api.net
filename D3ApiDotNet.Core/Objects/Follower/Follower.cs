#region

using System.Runtime.Serialization;
using D3ApiDotNet.Core.Objects.Skill;

#endregion

namespace D3ApiDotNet.Core.Objects.Follower
{
    /// <summary>
    /// D3ApiServiceExample: Follower
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