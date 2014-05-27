using System.Runtime.Serialization;

namespace D3apiData.API.Objects.Artisan
{

    /// <summary>
    /// D3Api: ArtisanLevel
    /// </summary>
    [DataContract]
    public class ArtisanLevel : ErrorObject
    {
        /// <summary />
        [DataMember(Name = "tier")]
        public int Tier { get; set; }

        /// <summary />
        [DataMember(Name = "tierLevel")]
        public int TierLevel { get; set; }

        /// <summary />
        [DataMember(Name = "percent")]
        public int Percent { get; set; }

        /// <summary />
        [DataMember(Name = "trainedRecipes")]
        public Recipe[] TrainedRecipes { get; set; }

        /// <summary />
        [DataMember(Name = "taughtRecipes")]
        public Recipe[] TaughtRecipes { get; set; }

        /// <summary />
        [DataMember(Name = "upgradeCost")]
        public int UpgradeCost { get; set; }

        /// <summary />
        [DataMember(Name = "upgradeItems")]
        public Reagent[] UpgradeItems { get; set; }
    }
}