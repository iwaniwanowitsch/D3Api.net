using System.Runtime.Serialization;

namespace D3apiData.API.Objects.Artisan
{
    /// <summary>
    /// D3ApiServiceExample: ArtisanTraining
    /// </summary>
    [DataContract]
    public class ArtisanTraining : ErrorObject
    {
        /// <summary />
        [DataMember(Name = "tiers")]
        public ArtisanTier[] Tiers { get; set; }
    }
}