using System.Runtime.Serialization;

namespace D3apiData.API.Objects.Hero
{
    /// <summary>
    /// D3Api: HeroStats
    /// </summary>
    [DataContract]
    public class HeroStats : ErrorObject
    {
        /// <summary />
        [DataMember(Name = "life")]
        public int Life { get; set; }

        /// <summary />
        [DataMember(Name = "damage")]
        public float Damage { get; set; }

        /// <summary />
        [DataMember(Name = "attackSpeed")]
        public float AttackSpeed { get; set; }

        /// <summary />
        [DataMember(Name = "armor")]
        public int Armor { get; set; }

        /// <summary />
        [DataMember(Name = "strength")]
        public int Strength { get; set; }

        /// <summary />
        [DataMember(Name = "dexterity")]
        public int Dexterity { get; set; }

        /// <summary />
        [DataMember(Name = "vitality")]
        public int Vitality { get; set; }

        /// <summary />
        [DataMember(Name = "intelligence")]
        public int Intelligence { get; set; }

        /// <summary />
        [DataMember(Name = "physicalResist")]
        public int PhysicalResist { get; set; }

        /// <summary />
        [DataMember(Name = "fireResist")]
        public int FireResist { get; set; }

        /// <summary />
        [DataMember(Name = "coldResist")]
        public int ColdResist { get; set; }

        /// <summary />
        [DataMember(Name = "lightningResist")]
        public int LightningResist { get; set; }

        /// <summary />
        [DataMember(Name = "poisonResist")]
        public int PoisonResist { get; set; }

        /// <summary />
        [DataMember(Name = "arcaneResist")]
        public int ArcaneResist { get; set; }

        /// <summary />
        [DataMember(Name = "critDamage")]
        public float CritDamage { get; set; }

        /// <summary />
        [DataMember(Name = "blockChance")]
        public float BlockChance { get; set; }

        /// <summary />
        [DataMember(Name = "blockAmountMin")]
        public int BlockAmountMin { get; set; }

        /// <summary />
        [DataMember(Name = "blockAmountMax")]
        public int BlockAmountMax { get; set; }

        /// <summary />
        [DataMember(Name = "damageIncrease")]
        public float DamageIncrease { get; set; }

        /// <summary />
        [DataMember(Name = "critChance")]
        public float CritChance { get; set; }

        /// <summary />
        [DataMember(Name = "damageReduction")]
        public float DamageReduction { get; set; }

        /// <summary />
        [DataMember(Name = "thorns")]
        public float Thorns { get; set; }

        /// <summary />
        [DataMember(Name = "lifeSteal")]
        public float LifeSteal { get; set; }

        /// <summary />
        [DataMember(Name = "lifePerKill")]
        public float LifePerKill { get; set; }

        /// <summary />
        [DataMember(Name = "goldFind")]
        public float GoldFind { get; set; }

        /// <summary />
        [DataMember(Name = "magicFind")]
        public float MagicFind { get; set; }

        /// <summary />
        [DataMember(Name = "lifeOnHit")]
        public float LifeOnHit { get; set; }

        /// <summary />
        [DataMember(Name = "primaryResource")]
        public int PrimaryResource { get; set; }

        /// <summary />
        [DataMember(Name = "secondaryResource")]
        public int SecondaryResource { get; set; }
    }
}