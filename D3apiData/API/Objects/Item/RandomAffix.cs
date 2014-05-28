using System.Runtime.Serialization;

namespace D3apiData.API.Objects.Item
{
    /// <summary>
    /// D3ApiServiceExample: RandomAffix
    /// </summary>
    [DataContract]
    public class RandomAffix : ErrorObject
    {
        /// <summary />
        [DataMember(Name = "oneOf")]
        public Affix[] OneOf { get; set; }
    }
}