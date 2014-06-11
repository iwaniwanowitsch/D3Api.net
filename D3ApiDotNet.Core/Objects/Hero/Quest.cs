using System.Runtime.Serialization;

namespace D3ApiDotNet.Core.Objects.Hero
{
    /// <summary>
    /// D3ApiServiceExample: Quest
    /// </summary>
    [DataContract]
    public class Quest : ErrorObject
    {
        /// <summary />
        [DataMember(Name = "slug")]
        public string Slug { get; set; }

        /// <summary />
        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}