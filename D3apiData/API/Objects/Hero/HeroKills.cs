using System.Runtime.Serialization;

namespace D3apiData.API.Objects.Hero
{
    /// <summary>
    /// D3Api: HeroKills
    /// </summary>
    [DataContract]
    public class HeroKills : ErrorObject
    {
        /// <summary />
        [DataMember(Name = "elites")]
        public int Elites { get; set; }
    }
}