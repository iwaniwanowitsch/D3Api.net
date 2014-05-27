using System.Runtime.Serialization;

namespace D3apiData.API.Objects.Profile
{
    /// <summary>
    /// D3Api: ProfileProgress
    /// </summary>
    [DataContract]
    public class ProfileProgress : ErrorObject
    {
        /// <summary />
        [DataMember(Name = "act1")]
        public bool Act1 { get; set; }

        /// <summary />
        [DataMember(Name = "act2")]
        public bool Act2 { get; set; }

        /// <summary />
        [DataMember(Name = "act3")]
        public bool Act3 { get; set; }

        /// <summary />
        [DataMember(Name = "act4")]
        public bool Act4 { get; set; }

        /// <summary />
        [DataMember(Name = "act5")]
        public bool Act5 { get; set; }
    }
}