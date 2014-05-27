using System;
using System.Runtime.Serialization;

namespace D3apiData.API.Objects.Item
{
    /// <summary>
    /// D3Api: SocketEffect
    /// </summary>
    [DataContract]
    public class SocketEffect : ErrorObject
    {
        /// <summary />
        [DataMember(Name = "itemTypeId")]
        public String ItemTypeId;

        /// <summary />
        [DataMember(Name = "itemTypeName")]
        public String ItemTypeName;

        /// <summary />
        [DataMember(Name = "attributesRaw")]
        public ItemAttributes AttributesRaw;

        /// <summary />
        [DataMember(Name = "attributes")]
        public ItemTextAttributes Attributes;
    }
}