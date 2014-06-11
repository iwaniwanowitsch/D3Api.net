#region

using System.Runtime.Serialization;
using D3ApiDotNet.Core.Objects.Follower;
using D3ApiDotNet.Core.Objects.Skill;

#endregion

namespace D3ApiDotNet.Core.Objects.Hero
{
    /// <summary>
    /// D3ApiServiceExample: Hero
    /// </summary>
    [DataContract]
    public class Hero : HeroSummary
    {
        /// <summary />
        [DataMember(Name = "skills")]
        public HeroSkills Skills { get; set; }

        /// <summary />
        [DataMember(Name = "items")]
        public HeroItems Items { get; set; }

        /// <summary />
        [DataMember(Name = "followers")]
        public Followers Followers { get; set; }

        /// <summary />
        [DataMember(Name = "stats")]
        public HeroStats Stats { get; set; }

        /// <summary />
        [DataMember(Name = "kills")]
        public HeroKills Kills { get; set; }

        /// <summary />
        [DataMember(Name = "progression")]
        public HeroProgress Progress { get; set; }
    }
}
