using System.Runtime.Serialization;

namespace D3apiData.API.Objects.Hero
{
    /// <summary>
    /// D3ApiServiceExample: HeroKills
    /// </summary>
    [DataContract]
    public class HeroKills : ErrorObject
    {
        /// <summary />
        [DataMember(Name = "elites")]
        public int Elites { get; set; }
    }
}