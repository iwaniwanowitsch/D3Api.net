using System.Runtime.Serialization;

namespace D3apiData.API.Objects.Item
{
    /// <summary>
    /// D3Api: RandomAffix
    /// </summary>
    [DataContract]
    public class RandomAffix : ErrorObject
    {
        /// <summary />
        [DataMember(Name = "oneOf")]
        public Affix[] OneOf { get; set; }
    }
}