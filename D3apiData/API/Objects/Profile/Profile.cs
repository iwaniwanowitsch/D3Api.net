using System;
using System.Runtime.Serialization;
using D3apiData.API.Objects.Hero;

namespace D3apiData.API.Objects.Profile
{

    /// <summary>
    /// D3Api: Profile
    /// </summary>
    [DataContract]
    public class Profile : ErrorObject
    {
        /// <summary />
        [DataMember(Name = "heroes")]
        public HeroSummary[] Heroes { get; set; }

        /// <summary />
        [DataMember(Name = "lastHeroPlayed")]
        public int LastHeroPlayed { get; set; }

        /// <summary />
        [DataMember(Name = "artisans")]
        public ProfileArtisan[] Artisans;

        /// <summary />
        [DataMember(Name = "hardcoreArtisans")]
        public ProfileArtisan[] HardcoreArtisans;

        /// <summary />
        [DataMember(Name = "lastUpdated")]
        public long LLastUpdated
        {
            set { LastUpdated = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(value).ToLocalTime(); }
            get { return LastUpdated.Second - new DateTime(1970, 1, 1, 0, 0, 0, 0).Second; }
        }

        /// <summary>
        /// not actual in api, but easier to handle
        /// </summary>
        [IgnoreDataMember]
        public DateTime LastUpdated;

        /// <summary />
        [DataMember(Name = "kills")]
        public ProfileKills Kills { get; set; }

        /// <summary />
        [DataMember(Name = "timePlayed")]
        public ProfileTimeplayed TimePlayed { get; set; }

        /// <summary />
        [DataMember(Name = "fallenHeroes")]
        public HeroSummary[] FallenHeroes { get; set; }

        /// <summary />
        [DataMember(Name = "paragonLevel")]
        public int ParagonLevel { get; set; }

        /// <summary />
        [DataMember(Name = "paragonLevelHardcore")]
        public int ParagonLevelHardcore { get; set; }

        /// <summary />
        [DataMember(Name = "battleTag")]
        public string BattleTag { get; set; }

        /// <summary />
        [DataMember(Name = "progression")]
        public ProfileProgress Progress { get; set; }
    }
}
