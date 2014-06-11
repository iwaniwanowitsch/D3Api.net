using System.Runtime.Serialization;

namespace D3ApiDotNet.Core.Objects.Profile
{
    /// <summary>
    /// D3ApiServiceExample: ProfileTimeplayed, relative to absolute
    /// </summary>
    [DataContract]
    public class ProfileTimeplayed : ErrorObject
    {
        /// <summary />
        [DataMember(Name = "barbarian")]
        public float Barbarian { get; set; }

        /// <summary />
        [DataMember(Name = "crusader")]
        public float Crusader { get; set; }

        /// <summary />
        [DataMember(Name = "demon-hunter")]
        public float Demonhunter { get; set; }

        /// <summary />
        [DataMember(Name = "monk")]
        public float Monk { get; set; }

        /// <summary />
        [DataMember(Name = "witch-doctor")]
        public float Witchdoctor { get; set; }

        /// <summary />
        [DataMember(Name = "wizard")]
        public float Wizard { get; set; }
    }
}