using System.Runtime.Serialization;
using D3apiData.API.Objects.Skill;

namespace D3apiData.API.Objects.Hero
{
    /// <summary>
    /// D3Api: Hero
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
        public Follower.Followers Followers { get; set; }

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
