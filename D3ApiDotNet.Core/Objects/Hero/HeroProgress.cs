using System.Runtime.Serialization;

namespace D3ApiDotNet.Core.Objects.Hero
{
    /// <summary>
    /// D3ApiServiceExample: HeroProgress
    /// </summary>
    [DataContract]
    public class HeroProgress : ErrorObject
    {
        /// <summary />
        [DataMember(Name = "act1")]
        public ActProgress Act1 { get; set; }

        /// <summary />
        [DataMember(Name = "act2")]
        public ActProgress Act2 { get; set; }

        /// <summary />
        [DataMember(Name = "act3")]
        public ActProgress Act3 { get; set; }

        /// <summary />
        [DataMember(Name = "act4")]
        public ActProgress Act4 { get; set; }

        /// <summary />
        [DataMember(Name = "act5")]
        public ActProgress Act5 { get; set; }
    }
}