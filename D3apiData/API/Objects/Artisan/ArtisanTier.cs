using System.Runtime.Serialization;

namespace D3apiData.API.Objects.Artisan
{
    /// <summary>
    /// D3ApiServiceExample: ArtisanTier
    /// </summary>
    [DataContract]
    public class ArtisanTier : ErrorObject
    {
        /// <summary />
        [DataMember(Name = "tier")]
        public int Tier { get; set; }

        /// <summary />
        [DataMember(Name = "levels")]
        public ArtisanLevel[] Levels { get; set; }
    }
}