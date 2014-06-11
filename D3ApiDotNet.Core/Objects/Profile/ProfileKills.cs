using System.Runtime.Serialization;

namespace D3ApiDotNet.Core.Objects.Profile
{
    /// <summary>
    /// D3ApiServiceExample: ProfileKills
    /// </summary>
    [DataContract]
    public class ProfileKills : ErrorObject
    {
        /// <summary />
        [DataMember(Name = "monsters")]
        public int Monsters { get; set; }

        /// <summary />
        [DataMember(Name = "elites")]
        public int Elites { get; set; }

        /// <summary />
        [DataMember(Name = "hardcoreMonsters")]
        public int HardcoreMonsters { get; set; }
    }
}