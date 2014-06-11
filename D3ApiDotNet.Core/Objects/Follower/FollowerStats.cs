using System.Runtime.Serialization;

namespace D3ApiDotNet.Core.Objects.Follower
{
    /// <summary>
    /// D3ApiServiceExample: FollowerStats
    /// </summary>
    [DataContract]
    public class FollowerStats : ErrorObject
    {
        /// <summary />
        [DataMember(Name = "goldFind")]
        public int GoldFind { get; set; }

        /// <summary />
        [DataMember(Name = "magicFind")]
        public int MagicFind { get; set; }

        /// <summary />
        [DataMember(Name = "experienceBonus")]
        public int ExperienceBonus { get; set; }
    }
}