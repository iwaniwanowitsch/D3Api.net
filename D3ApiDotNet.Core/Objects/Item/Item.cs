using System.Runtime.Serialization;

namespace D3ApiDotNet.Core.Objects.Item
{

    /// <summary>
    /// D3ApiServiceExample: Item
    /// </summary>
    [DataContract]
    public class Item : ItemSummary
    {
        /// <summary />
        [DataMember(Name = "requiredLevel")]
        public int RequiredLevel { get; set; }

        /// <summary />
        [DataMember(Name = "itemLevel")]
        public int ItemLevel { get; set; }

        /// <summary />
        [DataMember(Name = "bonusAffixes")]
        public int BonusAffixes { get; set; }

        /// <summary />
        [DataMember(Name = "bonusAffixesMax")]
        public int BonusAffixesMax { get; set; }

        /// <summary />
        [DataMember(Name = "accountBound")]
        public bool AccountBound { get; set; }

        /// <summary />
        [DataMember(Name = "flavorText")]
        public string FlavorText { get; set; }

        /// <summary />
        [DataMember(Name = "typeName")]
        public string TypeName { get; set; }

        /// <summary />
        [DataMember(Name = "dps", EmitDefaultValue = false)]
        public ItemValueRange Dps { get; set; }

        /// <summary />
        [DataMember(Name = "attacksPerSecond", EmitDefaultValue = false)]
        public ItemValueRange AttacksPerSecond { get; set; }

        /// <summary />
        [DataMember(Name = "minDamage", EmitDefaultValue = false)]
        public ItemValueRange MinDamage { get; set; }

        /// <summary />
        [DataMember(Name = "maxDamage", EmitDefaultValue = false)]
        public ItemValueRange MaxDamage { get; set; }

        /// <summary />
        [DataMember(Name = "armor", EmitDefaultValue = false)]
        public ItemValueRange Armor { get; set; }

        /// <summary />
        [DataMember(Name = "type")]
        public ItemType Type { get; set; }

        /// <summary />
        [DataMember(Name = "attributes")]
        public ItemTextAttributes Attributes { get; set; }

        /// <summary />
        [DataMember(Name = "attributesRaw")]
        public ItemAttributes AttributesRaw { get; set; }

        /// <summary />
        [DataMember(Name = "gems")]
        public SocketedGems[] Gems { get; set; }

        /// <summary />
        [DataMember(Name = "socketEffects")]
        public SocketEffect[] SocketEffects { get; set; }

        /// <summary />
        [DataMember(Name = "salvage")]
        public ItemSalvageComponent[] Salvage { get; set; }

        /// <summary />
        [DataMember(Name = "set", EmitDefaultValue = false)]
        public Set Set { get; set; }
    }
}
