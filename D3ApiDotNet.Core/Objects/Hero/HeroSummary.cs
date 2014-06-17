#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

#endregion

namespace D3ApiDotNet.Core.Objects.Hero
{
    /// <summary>
    /// D3ApiServiceExample: HeroSummary
    /// </summary>
    [DataContract]
    public class HeroSummary : ErrorObject
    {
        private readonly Dictionary<string, HeroClass> _heroLookup = new Dictionary<string, HeroClass>
        {
            {"barbarian", HeroClass.Barbarian},
            {"crusader", HeroClass.Crusader},
            {"demon-hunter", HeroClass.Demonhunter},
            {"monk", HeroClass.Monk},
            {"witch-doctor", HeroClass.Witchdoctor},
            {"wizard", HeroClass.Wizard}
        };

        /// <summary />
        [DataMember(Name = "paragonLevel")]
        public int ParagonLevel { get; set; }

        /// <summary />
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary />
        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary />
        [DataMember(Name = "level")]
        public int Level { get; set; }

        /// <summary />
        [DataMember(Name = "hardcore")]
        public bool Hardcore { get; set; }

        /// <summary />
        [DataMember(Name = "gender")]
        public int Gender { get; set; }

        /// <summary />
        [DataMember(Name = "dead")]
        public bool Dead { get; set; }

        /// <summary />
        [DataMember(Name = "class")]
        public string SHeroClass {
            get { return _heroLookup.FirstOrDefault(o => o.Value == HeroClass).Key; }
            set { if (_heroLookup.ContainsKey(value)) HeroClass = _heroLookup[value]; }
        }

        /// <summary>
        /// not actual in api, but easier to handle
        /// </summary>
        [IgnoreDataMember]
        public HeroClass HeroClass { get; set; }

        /// <summary />
        [DataMember(Name = "last-updated")]
        public long LLastUpdated
        {
            set { LastUpdated = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(value).ToLocalTime(); }
            get { return LastUpdated.Second - new DateTime(1970, 1, 1, 0, 0, 0, 0).Second; }
        }

        /// <summary>
        /// not actual in api, but easier to handle
        /// </summary>
        [IgnoreDataMember]
        public DateTime LastUpdated { get; set; }
    }
}