using System.Runtime.Serialization;

namespace D3apiData.API.Objects.Artisan
{
    /// <summary>
    /// D3ApiServiceExample: Artisan
    /// </summary>
    [DataContract]
    public class Artisan : ErrorObject
    {
        /// <summary />
        [DataMember(Name = "slug")]
        public string Slug { get; set; }

        /// <summary />
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary />
        [DataMember(Name = "portrait")]
        public string Portrait { get; set; }

        /// <summary />
        [DataMember(Name = "training")]
        public ArtisanTraining Training { get; set; }
    }
}
