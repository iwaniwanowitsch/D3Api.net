using System.Runtime.Serialization;

namespace D3apiData.API.Objects.Profile
{
    /// <summary>
    /// D3ApiServiceExample: ProfileArtisan
    /// </summary>
    [DataContract]
    public class ProfileArtisan
    {
        /// <summary />
        [DataMember(Name = "slug")]
        public string Slug;

        /// <summary />
        [DataMember(Name = "level")]
        public int Level;

        /// <summary />
        [DataMember(Name = "stepCurrent")]
        public int StepCurrent;

        /// <summary />
        [DataMember(Name = "stepMax")]
        public int StepMax;
    }
}