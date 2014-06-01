/*
 * taken from https://github.com/zetoken/D3-API-by-ZTn/blob/master/D3%20API%20by%20ZTn/Items/ItemAttributes.cs
 */

using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace D3apiData.API.Objects.Item
{
    /// <summary>
    /// D3ApiServiceExample: ItemAttributes, all attributes!
    /// </summary>
    [DataContract]
    public class ItemAttributes : ErrorObject
    {
        /// <summary />
        [JsonExtensionData]
        public IDictionary<string, JToken> UnmanagedAttributes;

        #region >> Fields

        // Find how it's used ?
        /// <summary />
        [DataMember(Name = "Amplify_Damage_Type_Percent", EmitDefaultValue = false)]
        public ItemValueRange amplifyDamageTypePercent;

        /// <summary />
        [DataMember(Name = "Armor_Item", EmitDefaultValue = false)]
        public ItemValueRange armorItem;

        /// <summary />
        [DataMember(Name = "Armor_Bonus_Item", EmitDefaultValue = false)]
        public ItemValueRange armorBonusItem;

        // Find how it's used ?
        /// <summary />
        [DataMember(Name = "Attack", EmitDefaultValue = false)]
        public ItemValueRange attack;

        // Attack Per Second (weapon only)
        /// <summary />
        [DataMember(Name = "Attacks_Per_Second_Item", EmitDefaultValue = false)]
        public ItemValueRange attacksPerSecondItem;

        // Attack Speed bonus only for the item (weapon only)
        /// <summary />
        [DataMember(Name = "Attacks_Per_Second_Item_Percent", EmitDefaultValue = false)]
        public ItemValueRange attacksPerSecondItemPercent;

        // Attack Speed bonus
        /// <summary />
        [DataMember(Name = "Attacks_Per_Second_Percent", EmitDefaultValue = false)]
        public ItemValueRange attacksPerSecondPercent;

        // "Ring of Royal Grandeur" like (+1 to bonus set with a minimum of 2)
        /// <summary />
        [DataMember(Name = "Attribute_Set_Item_Discount", EmitDefaultValue = false)]
        public ItemValueRange AttributeSetItemDiscount;

        /// <summary />
        [DataMember(Name = "Block_Amount_Item_Delta", EmitDefaultValue = false)]
        public ItemValueRange blockAmountItemDelta;

        /// <summary />
        [DataMember(Name = "Block_Amount_Item_Min", EmitDefaultValue = false)]
        public ItemValueRange blockAmountItemMin;

        /// <summary />
        [DataMember(Name = "Block_Chance_Bonus_Item", EmitDefaultValue = false)]
        public ItemValueRange blockChanceBonusItem;

        /// <summary />
        [DataMember(Name = "Block_Chance_Item", EmitDefaultValue = false)]
        public ItemValueRange blockChanceItem;

        /// <summary />
        [DataMember(Name = "Bow", EmitDefaultValue = false)]
        public ItemValueRange bow;

        /// <summary />
        [DataMember(Name = "Crit_Damage_Percent", EmitDefaultValue = false)]
        public ItemValueRange critDamagePercent;

        /// <summary />
        [DataMember(Name = "Crit_Percent_Bonus_Capped", EmitDefaultValue = false)]
        public ItemValueRange critPercentBonusCapped;

        // Find how it's used ?
        /// <summary />
        [DataMember(Name = "Crit_Percent_Bonus_Uncapped", EmitDefaultValue = false)]
        public ItemValueRange critPercentBonusUncapped;

        /// <summary />
        [DataMember(Name = "Crossbow", EmitDefaultValue = false)]
        public ItemValueRange crossbow;

        /// <summary />
        [DataMember(Name = "CrowdControl_Reduction", EmitDefaultValue = false)]
        public ItemValueRange crowdControlReduction;

        #region >> Damage_Bonus_Min

        /// <summary />
        [DataMember(Name = "Damage_Bonus_Min#Arcane", EmitDefaultValue = false)]
        public ItemValueRange damageBonusMin_Arcane;

        /// <summary />
        [DataMember(Name = "Damage_Bonus_Min#Cold", EmitDefaultValue = false)]
        public ItemValueRange damageBonusMin_Cold;

        /// <summary />
        [DataMember(Name = "Damage_Bonus_Min#Fire", EmitDefaultValue = false)]
        public ItemValueRange damageBonusMin_Fire;

        /// <summary />
        [DataMember(Name = "Damage_Bonus_Min#Holy", EmitDefaultValue = false)]
        public ItemValueRange damageBonusMin_Holy;

        /// <summary />
        [DataMember(Name = "Damage_Bonus_Min#Lightning", EmitDefaultValue = false)]
        public ItemValueRange damageBonusMin_Lightning;

        /// <summary />
        [DataMember(Name = "Damage_Bonus_Min#Physical", EmitDefaultValue = false)]
        public ItemValueRange damageBonusMin_Physical;

        /// <summary />
        [DataMember(Name = "Damage_Bonus_Min#Poison", EmitDefaultValue = false)]
        public ItemValueRange damageBonusMin_Poison;

        #endregion

        #region >> Damage_Dealt_Percent_Bonus

        /// <summary />
        [DataMember(Name = "Damage_Dealt_Percent_Bonus#Arcane", EmitDefaultValue = false)]
        public ItemValueRange damageDealtPercentBonusArcane;

        /// <summary />
        [DataMember(Name = "Damage_Dealt_Percent_Bonus#Cold", EmitDefaultValue = false)]
        public ItemValueRange damageDealtPercentBonusCold;

        /// <summary />
        [DataMember(Name = "Damage_Dealt_Percent_Bonus#Fire", EmitDefaultValue = false)]
        public ItemValueRange damageDealtPercentBonusFire;

        /// <summary />
        [DataMember(Name = "Damage_Dealt_Percent_Bonus#Holy", EmitDefaultValue = false)]
        public ItemValueRange damageDealtPercentBonusHoly;

        /// <summary />
        [DataMember(Name = "Damage_Dealt_Percent_Bonus#Lightning", EmitDefaultValue = false)]
        public ItemValueRange damageDealtPercentBonusLightning;

        /// <summary />
        [DataMember(Name = "Damage_Dealt_Percent_Bonus#Physical", EmitDefaultValue = false)]
        public ItemValueRange damageDealtPercentBonusPhysical;

        /// <summary />
        [DataMember(Name = "Damage_Dealt_Percent_Bonus#Poison", EmitDefaultValue = false)]
        public ItemValueRange damageDealtPercentBonusPoison;

        #endregion

        #region >> Damage_Delta

        /// <summary />
        [DataMember(Name = "Damage_Delta#Arcane", EmitDefaultValue = false)]
        public ItemValueRange damageDelta_Arcane;

        /// <summary />
        [DataMember(Name = "Damage_Delta#Cold", EmitDefaultValue = false)]
        public ItemValueRange damageDelta_Cold;

        /// <summary />
        [DataMember(Name = "Damage_Delta#Fire", EmitDefaultValue = false)]
        public ItemValueRange damageDelta_Fire;

        /// <summary />
        [DataMember(Name = "Damage_Delta#Holy", EmitDefaultValue = false)]
        public ItemValueRange damageDelta_Holy;

        /// <summary />
        [DataMember(Name = "Damage_Delta#Lightning", EmitDefaultValue = false)]
        public ItemValueRange damageDelta_Lightning;

        /// <summary />
        [DataMember(Name = "Damage_Delta#Physical", EmitDefaultValue = false)]
        public ItemValueRange damageDelta_Physical;

        /// <summary />
        [DataMember(Name = "Damage_Delta#Poison", EmitDefaultValue = false)]
        public ItemValueRange damageDelta_Poison;

        #endregion

        #region >> Damage_Min

        /// <summary />
        [DataMember(Name = "Damage_Min#Arcane", EmitDefaultValue = false)]
        public ItemValueRange damageMin_Arcane;

        /// <summary />
        [DataMember(Name = "Damage_Min#Cold", EmitDefaultValue = false)]
        public ItemValueRange damageMin_Cold;

        /// <summary />
        [DataMember(Name = "Damage_Min#Fire", EmitDefaultValue = false)]
        public ItemValueRange damageMin_Fire;

        /// <summary />
        [DataMember(Name = "Damage_Min#Holy", EmitDefaultValue = false)]
        public ItemValueRange damageMin_Holy;

        /// <summary />
        [DataMember(Name = "Damage_Min#Lightning", EmitDefaultValue = false)]
        public ItemValueRange damageMin_Lightning;

        /// <summary />
        [DataMember(Name = "Damage_Min#Physical", EmitDefaultValue = false)]
        public ItemValueRange damageMin_Physical;

        /// <summary />
        [DataMember(Name = "Damage_Min#Poison", EmitDefaultValue = false)]
        public ItemValueRange damageMin_Poison;

        #endregion

        /// <summary />
        [DataMember(Name = "Damage_Percent_Bonus_Vs_Elites", EmitDefaultValue = false)]
        public ItemValueRange damagePercentBonusVsElites;

        /// <summary />
        [DataMember(Name = "Damage_Percent_Bonus_Vs_Monster_Type", EmitDefaultValue = false)]
        public ItemValueRange damagePercentBonusVsMonsterType;

        /// <summary />
        [DataMember(Name = "Damage_Percent_Reduction_From_Elites", EmitDefaultValue = false)]
        public ItemValueRange damagePercentReductionFromElites;

        /// <summary />
        [DataMember(Name = "Damage_Percent_Reduction_From_Melee", EmitDefaultValue = false)]
        public ItemValueRange damagePercentReductionFromMelee;

        /// <summary />
        [DataMember(Name = "Damage_Percent_Reduction_From_Ranged", EmitDefaultValue = false)]
        public ItemValueRange damagePercentReductionFromRanged;

        /// <summary />
        [DataMember(Name = "Damage_Percent_Reduction_From_Type", EmitDefaultValue = false)]
        public ItemValueRange damagePercentReductionFromType;

        /// <summary />
        [DataMember(Name = "Damage_Percent_Reduction_Turns_Into_Heal", EmitDefaultValue = false)]
        public ItemValueRange damagePercentReductionTurnsIntoHeal;

        #region >> Damage_Type_Percent_Bonus

        /// <summary />
        [DataMember(Name = "Damage_Type_Percent_Bonus#Arcane", EmitDefaultValue = false)]
        public ItemValueRange damageTypePercentBonus_Arcane;

        /// <summary />
        [DataMember(Name = "Damage_Type_Percent_Bonus#Cold", EmitDefaultValue = false)]
        public ItemValueRange damageTypePercentBonus_Cold;

        /// <summary />
        [DataMember(Name = "Damage_Type_Percent_Bonus#Fire", EmitDefaultValue = false)]
        public ItemValueRange damageTypePercentBonus_Fire;

        /// <summary />
        [DataMember(Name = "Damage_Type_Percent_Bonus#Holy", EmitDefaultValue = false)]
        public ItemValueRange damageTypePercentBonus_Holy;

        /// <summary />
        [DataMember(Name = "Damage_Type_Percent_Bonus#Lightning", EmitDefaultValue = false)]
        public ItemValueRange damageTypePercentBonus_Lightning;

        /// <summary />
        [DataMember(Name = "Damage_Type_Percent_Bonus#Physical", EmitDefaultValue = false)]
        public ItemValueRange damageTypePercentBonus_Physical;

        /// <summary />
        [DataMember(Name = "Damage_Type_Percent_Bonus#Poison", EmitDefaultValue = false)]
        public ItemValueRange damageTypePercentBonus_Poison;

        #endregion

        #region >> Damage_Weapon_Bonus_Delta

        /// <summary />
        [DataMember(Name = "Damage_Weapon_Bonus_Delta#Arcane", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponBonusDelta_Arcane;

        /// <summary />
        [DataMember(Name = "Damage_Weapon_Bonus_Delta#Cold", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponBonusDelta_Cold;

        /// <summary />
        [DataMember(Name = "Damage_Weapon_Bonus_Delta#Fire", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponBonusDelta_Fire;

        /// <summary />
        [DataMember(Name = "Damage_Weapon_Bonus_Delta#Holy", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponBonusDelta_Holy;

        /// <summary />
        [DataMember(Name = "Damage_Weapon_Bonus_Delta#Lightning", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponBonusDelta_Lightning;

        /// <summary />
        [DataMember(Name = "Damage_Weapon_Bonus_Delta#Physical", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponBonusDelta_Physical;

        /// <summary />
        [DataMember(Name = "Damage_Weapon_Bonus_Delta#Poison", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponBonusDelta_Poison;

        #endregion

        #region >> Damage_Weapon_Bonus_Delta_X1

        /// <summary />
        [DataMember(Name = "Damage_Weapon_Bonus_Delta_X1#Arcane", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponBonusDeltaX1_Arcane;

        /// <summary />
        [DataMember(Name = "Damage_Weapon_Bonus_Delta_X1#Cold", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponBonusDeltaX1_Cold;

        /// <summary />
        [DataMember(Name = "Damage_Weapon_Bonus_Delta_X1#Fire", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponBonusDeltaX1_Fire;

        /// <summary />
        [DataMember(Name = "Damage_Weapon_Bonus_Delta_X1#Holy", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponBonusDeltaX1_Holy;

        /// <summary />
        [DataMember(Name = "Damage_Weapon_Bonus_Delta_X1#Lightning", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponBonusDeltaX1_Lightning;

        /// <summary />
        [DataMember(Name = "Damage_Weapon_Bonus_Delta_X1#Physical", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponBonusDeltaX1_Physical;

        /// <summary />
        [DataMember(Name = "Damage_Weapon_Bonus_Delta_X1#Poison", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponBonusDeltaX1_Poison;

        #endregion

        #region >> Damage_Weapon_Bonus_Min

        /// <summary />
        [DataMember(Name = "Damage_Weapon_Bonus_Min#Arcane", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponBonusMin_Arcane;

        /// <summary />
        [DataMember(Name = "Damage_Weapon_Bonus_Min#Cold", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponBonusMin_Cold;

        /// <summary />
        [DataMember(Name = "Damage_Weapon_Bonus_Min#Fire", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponBonusMin_Fire;

        /// <summary />
        [DataMember(Name = "Damage_Weapon_Bonus_Min#Holy", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponBonusMin_Holy;

        /// <summary />
        [DataMember(Name = "Damage_Weapon_Bonus_Min#Lightning", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponBonusMin_Lightning;

        /// <summary />
        [DataMember(Name = "Damage_Weapon_Bonus_Min#Physical", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponBonusMin_Physical;

        /// <summary />
        [DataMember(Name = "Damage_Weapon_Bonus_Min#Poison", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponBonusMin_Poison;

        #endregion

        #region >> Damage_Weapon_Bonus_Min_X1

        /// <summary />
        [DataMember(Name = "Damage_Weapon_Bonus_Min_X1#Arcane", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponBonusMinX1_Arcane;

        /// <summary />
        [DataMember(Name = "Damage_Weapon_Bonus_Min_X1#Cold", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponBonusMinX1_Cold;

        /// <summary />
        [DataMember(Name = "Damage_Weapon_Bonus_Min_X1#Fire", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponBonusMinX1_Fire;

        /// <summary />
        [DataMember(Name = "Damage_Weapon_Bonus_Min_X1#Holy", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponBonusMinX1_Holy;

        /// <summary />
        [DataMember(Name = "Damage_Weapon_Bonus_Min_X1#Lightning", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponBonusMinX1_Lightning;

        /// <summary />
        [DataMember(Name = "Damage_Weapon_Bonus_Min_X1#Physical", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponBonusMinX1_Physical;

        /// <summary />
        [DataMember(Name = "Damage_Weapon_Bonus_Min_X1#Poison", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponBonusMinX1_Poison;

        #endregion

        #region >> Damage_Weapon_Bonus_Flat

        /// <summary />
        [DataMember(Name = "Damage_Weapon_Bonus_Flat#Arcane", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponBonusFlat_Arcane;

        /// <summary />
        [DataMember(Name = "Damage_Weapon_Bonus_Flat#Cold", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponBonusFlat_Cold;

        /// <summary />
        [DataMember(Name = "Damage_Weapon_Bonus_Flat#Fire", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponBonusFlat_Fire;

        /// <summary />
        [DataMember(Name = "Damage_Weapon_Bonus_Flat#Holy", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponBonusFlat_Holy;

        /// <summary />
        [DataMember(Name = "Damage_Weapon_Bonus_Flat#Lightning", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponBonusFlat_Lightning;

        /// <summary />
        [DataMember(Name = "Damage_Weapon_Bonus_Flat#Physical", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponBonusFlat_Physical;

        /// <summary />
        [DataMember(Name = "Damage_Weapon_Bonus_Flat#Poison", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponBonusFlat_Poison;

        #endregion

        #region >> Damage_Weapon_Delta

        /// <summary />
        [DataMember(Name = "Damage_Weapon_Delta#Arcane", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponDelta_Arcane;

        /// <summary />
        [DataMember(Name = "Damage_Weapon_Delta#Cold", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponDelta_Cold;

        /// <summary />
        [DataMember(Name = "Damage_Weapon_Delta#Fire", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponDelta_Fire;

        /// <summary />
        [DataMember(Name = "Damage_Weapon_Delta#Holy", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponDelta_Holy;

        /// <summary />
        [DataMember(Name = "Damage_Weapon_Delta#Lightning", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponDelta_Lightning;

        /// <summary />
        [DataMember(Name = "Damage_Weapon_Delta#Physical", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponDelta_Physical;

        /// <summary />
        [DataMember(Name = "Damage_Weapon_Delta#Poison", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponDelta_Poison;

        #endregion

        #region >> Damage_Weapon_Min

        /// <summary />
        [DataMember(Name = "Damage_Weapon_Min#Arcane", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponMin_Arcane;

        /// <summary />
        [DataMember(Name = "Damage_Weapon_Min#Cold", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponMin_Cold;

        /// <summary />
        [DataMember(Name = "Damage_Weapon_Min#Fire", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponMin_Fire;

        /// <summary />
        [DataMember(Name = "Damage_Weapon_Min#Holy", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponMin_Holy;

        /// <summary />
        [DataMember(Name = "Damage_Weapon_Min#Lightning", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponMin_Lightning;

        /// <summary />
        [DataMember(Name = "Damage_Weapon_Min#Physical", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponMin_Physical;

        /// <summary />
        [DataMember(Name = "Damage_Weapon_Min#Poison", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponMin_Poison;

        #endregion

        #region >> Damage_Weapon_Percent_Bonus

        /// <summary />
        [DataMember(Name = "Damage_Weapon_Percent_Bonus#Arcane", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponPercentBonus_Arcane;

        /// <summary />
        [DataMember(Name = "Damage_Weapon_Percent_Bonus#Cold", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponPercentBonus_Cold;

        /// <summary />
        [DataMember(Name = "Damage_Weapon_Percent_Bonus#Fire", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponPercentBonus_Fire;

        /// <summary />
        [DataMember(Name = "Damage_Weapon_Percent_Bonus#Holy", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponPercentBonus_Holy;

        /// <summary />
        [DataMember(Name = "Damage_Weapon_Percent_Bonus#Lightning", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponPercentBonus_Lightning;

        /// <summary />
        [DataMember(Name = "Damage_Weapon_Percent_Bonus#Physical", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponPercentBonus_Physical;

        /// <summary />
        [DataMember(Name = "Damage_Weapon_Percent_Bonus#Poison", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponPercentBonus_Poison;

        #endregion

        // Find how it's used ?
        /// <summary />
        [DataMember(Name = "Defense", EmitDefaultValue = false)]
        public ItemValueRange defense;

        /// <summary />
        [DataMember(Name = "Dexterity_Item", EmitDefaultValue = false)]
        public ItemValueRange dexterityItem;

        //"DyeType"

        #region >> Experience_Bonus

        /// <summary />
        [DataMember(Name = "Experience_Bonus", EmitDefaultValue = false)]
        public ItemValueRange experienceBonus;

        /// <summary />
        [DataMember(Name = "Experience_Bonus_Percent", EmitDefaultValue = false)]
        public ItemValueRange experienceBonusPercent;

        #endregion

        //"GemQuality"

        #region >> Gold

        /// <summary />
        [DataMember(Name = "Gold_Find", EmitDefaultValue = false)]
        public ItemValueRange goldFind;

        /// <summary />
        [DataMember(Name = "Gold_PickUp_Radius", EmitDefaultValue = false)]
        public ItemValueRange goldPickUpRadius;

        #endregion

        #region >> Health_Globe

        /// <summary />
        [DataMember(Name = "Health_Globe_Bonus_Chance", EmitDefaultValue = false)]
        public ItemValueRange healthGlobeBonusChance;

        /// <summary />
        [DataMember(Name = "Health_Globe_Bonus_Health", EmitDefaultValue = false)]
        public ItemValueRange healthGlobeBonusHealth;

        #endregion

        #region >> Hitpoints

        /// <summary />
        [DataMember(Name = "Hitpoints_Granted", EmitDefaultValue = false)]
        public ItemValueRange hitpointsGranted;

        /// <summary />
        [DataMember(Name = "Hitpoints_Granted_Duration", EmitDefaultValue = false)]
        public ItemValueRange hitpointsGrantedDuration;

        /// <summary />
        [DataMember(Name = "Hitpoints_Max_Percent_Bonus_Item", EmitDefaultValue = false)]
        public ItemValueRange hitpointsMaxPercentBonusItem;

        /// <summary />
        [DataMember(Name = "Hitpoints_On_Hit", EmitDefaultValue = false)]
        public ItemValueRange hitpointsOnHit;

        /// <summary />
        [DataMember(Name = "Hitpoints_On_Kill", EmitDefaultValue = false)]
        public ItemValueRange hitpointsOnKill;

        /// <summary />
        [DataMember(Name = "Hitpoints_Percent", EmitDefaultValue = false)]
        public ItemValueRange hitpointsPercent;

        /// <summary />
        [DataMember(Name = "Hitpoints_Regen_Per_Second", EmitDefaultValue = false)]
        public ItemValueRange hitpointsRegenPerSecond;

        #endregion

        #region >> Intelligence

        // Blizzard workaround bug for some cases where Blizzard API uses Intelligence instead of Intelligence_Item attribute
        /// <summary />
        [DataMember(Name = "Intelligence", EmitDefaultValue = false),]
        private ItemValueRange intelligence
        {
            get { return intelligenceItem; }
            set { intelligenceItem = value; }
        }

        /// <summary />
        [DataMember(Name = "Intelligence_Item", EmitDefaultValue = false)]
        public ItemValueRange intelligenceItem;

        #endregion

        /// <summary />
        [DataMember(Name = "Item_Indestructible", EmitDefaultValue = false)]
        public ItemValueRange itemIndestructible;

        /// <summary />
        [DataMember(Name = "Item_Level_Requirement_Reduction", EmitDefaultValue = false)]
        public ItemValueRange itemLevelRequirementReduction;

        //"Item_Power_Passive"

        /// <summary />
        [DataMember(Name = "Magic_Find", EmitDefaultValue = false)]
        public ItemValueRange magicFind;

        /// <summary />
        [DataMember(Name = "Movement_Scalar", EmitDefaultValue = false)]
        public ItemValueRange movementScalar;

        //"On_Hit_Blind_Proc_Chance"
        //"On_Hit_Chill_Proc_Chance"
        //"On_Hit_Fear_Proc_Chance"
        //"On_Hit_Freeze_Proc_Chance"
        //"On_Hit_Immobilize_Proc_Chance"
        //"On_Hit_Knockback_Proc_Chance"
        //"On_Hit_Slow_Proc_Chance"
        //"On_Hit_Stun_Proc_Chance"
        //"Power_Cooldown_Reduction"
        //"Power_Crit_Percent_Bonus"
        //"Power_Damage_Percent_Bonus"
        //"Power_Duration_Increase"

        /// <summary>
        /// cooldown reduction
        /// </summary>
        [DataMember(Name = "Power_Cooldown_Reduction_Percent_All", EmitDefaultValue = false)] 
        public ItemValueRange PowerCooldownReductionPercentAll;

        /// <summary>
        /// resource cost reduction
        /// </summary>
        [DataMember(Name = "Resource_Cost_Reduction_Percent_All", EmitDefaultValue = false)]
        public ItemValueRange ResourceCostReductionPercentAll;

        /// <summary />
        [DataMember(Name = "Power_Resource_Reduction#Monk_SweepingWind", EmitDefaultValue = false)]
        public ItemValueRange PowerResourceReductionMonkSweepingWind;

        //"Power_Resource_Reduction"
        //"Precision"

        /// <summary />
        [DataMember(Name = "Quiver", EmitDefaultValue = false)]
        public ItemValueRange quiver;

        //Requirement_When_Equipped"

        /// <summary />
        [DataMember(Name = "Resistance_All", EmitDefaultValue = false)]
        public ItemValueRange resistance_All;

        #region >> Resistance

        /// <summary />
        [DataMember(Name = "Resistance#Arcane", EmitDefaultValue = false)]
        public ItemValueRange resistance_Arcane;

        /// <summary />
        [DataMember(Name = "Resistance#Cold", EmitDefaultValue = false)]
        public ItemValueRange resistance_Cold;

        /// <summary />
        [DataMember(Name = "Resistance#Fire", EmitDefaultValue = false)]
        public ItemValueRange resistance_Fire;

        /// <summary />
        [DataMember(Name = "Resistance#Lightning", EmitDefaultValue = false)]
        public ItemValueRange resistance_Lightning;

        /// <summary />
        [DataMember(Name = "Resistance#Physical", EmitDefaultValue = false)]
        public ItemValueRange resistance_Physical;

        /// <summary />
        [DataMember(Name = "Resistance#Poison", EmitDefaultValue = false)]
        public ItemValueRange resistance_Poison;

        #endregion

        //"Resistance_Freeze"
        //"Resistance_Root"
        //"Resistance_Stun"
        //"Resistance_StunRootFreeze"
        //"Resource_Max_Bonus"
        //"Resource_On_Crit"
        //"Resource_On_Hit"
        //"Resource_On_Kill#Mana"

        #region >> "Resource_Regen_Per_Second

        /// <summary />
        [DataMember(Name = "Resource_Regen_Per_Second#Mana", EmitDefaultValue = false)]
        public ItemValueRange Resource_Regen_Per_Second_Mana;

        /// <summary />
        [DataMember(Name = "Resource_Regen_Per_Second#Spirit", EmitDefaultValue = false)]
        public ItemValueRange Resource_Regen_Per_Second_Spirit;

        #endregion

        /// <summary />
        [DataMember(Name = "Season")]
        public ItemValueRange Season;

        //"Resource_Set_Point_Bonus"
        //"ScrollDuration"

        /// <summary />
        [DataMember(Name = "Sockets", EmitDefaultValue = false)]
        public ItemValueRange sockets;

        //"Spending_Resource_Heals_Percent#Spirit"
        //"Stats_All_Bonus"

        /// <summary />
        [DataMember(Name = "Steal_Health_Percent", EmitDefaultValue = false)]
        public ItemValueRange stealHealthPercent;

        /// <summary />
        [DataMember(Name = "Strength_Item", EmitDefaultValue = false)]
        public ItemValueRange strengthItem;

        #region >> Thorns_Fixed

        /// <summary />
        [DataMember(Name = "Thorns_Fixed#Arcane", EmitDefaultValue = false)]
        public ItemValueRange thornsFixed_Arcane;

        /// <summary />
        [DataMember(Name = "Thorns_Fixed#Cold", EmitDefaultValue = false)]
        public ItemValueRange thornsFixed_Cold;

        /// <summary />
        [DataMember(Name = "Thorns_Fixed#Fire", EmitDefaultValue = false)]
        public ItemValueRange thornsFixed_Fire;

        /// <summary />
        [DataMember(Name = "Thorns_Fixed#Holy", EmitDefaultValue = false)]
        public ItemValueRange thornsFixed_Holy;

        /// <summary />
        [DataMember(Name = "Thorns_Fixed#Lightning", EmitDefaultValue = false)]
        public ItemValueRange thornsFixed_Lightning;

        /// <summary />
        [DataMember(Name = "Thorns_Fixed#Physical", EmitDefaultValue = false)]
        public ItemValueRange thornsFixed_Physical;

        /// <summary />
        [DataMember(Name = "Thorns_Fixed#Poison", EmitDefaultValue = false)]
        public ItemValueRange thornsFixed_Poison;

        #endregion

        #region >> Vitality

        // Blizzard workaround bug for some cases where Blizzard API uses Vitality instead of Vitality_Item attribute
        /// <summary />
        [DataMember(Name = "Vitality", EmitDefaultValue = false)]
        public ItemValueRange vitality
        {
            get { return vitalityItem; }
            set { vitalityItem = value; }
        }

        /// <summary />
        [DataMember(Name = "Vitality_Item", EmitDefaultValue = false)]
        public ItemValueRange vitalityItem;

        #endregion

        //"Weapon_On_Hit_Bleed_Proc_Chance"
        //"Weapon_On_Hit_Bleed_Proc_Damage_Base"
        //"Weapon_On_Hit_Bleed_Proc_Damage_Delta"
        //"Weapon_On_Hit_Blind_Proc_Chance"
        //"Weapon_On_Hit_Chill_Proc_Chance"
        //"Weapon_On_Hit_Fear_Proc_Chance"
        //"Weapon_On_Hit_Freeze_Proc_Chance"
        //"Weapon_On_Hit_Immobilize_Proc_Chance"
        //"Weapon_On_Hit_Knockback_Proc_Chance"
        //"Weapon_On_Hit_Slow_Proc_Chance"
        //"Weapon_On_Hit_Stun_Proc_Chance"

        #endregion

        #region >> Constructors

        /// <summary />
        public ItemAttributes()
        {
        }

        /// <summary>
        /// Creates a new instance by copying fields of <paramref name="itemAttributes"/> (deep copy).
        /// </summary>
        /// <param name="itemAttributes"></param>
        public ItemAttributes(ItemAttributes itemAttributes)
        {
            var type = GetType();

            foreach (var fieldInfo in type.GetTypeInfo().DeclaredFields)
            {
                var valueRange = fieldInfo.GetValue(itemAttributes) as ItemValueRange;
                if (valueRange != null)
                {
                    fieldInfo.SetValue(this, new ItemValueRange(valueRange));
                }
            }
        }

        #endregion

        #region >> Operators

        /// <summary />
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static ItemAttributes operator +(ItemAttributes left, ItemAttributes right)
        {
            var target = new ItemAttributes(left);

            var type = target.GetType();

            foreach (var fieldInfo in type.GetTypeInfo().DeclaredFields)
            {
                if (fieldInfo.Name != "UnmanagedAttributes" && fieldInfo.GetValue(right) != null)
                {
                    var targetValueRange = (ItemValueRange)fieldInfo.GetValue(target);
                    var rightValueRange = (ItemValueRange)fieldInfo.GetValue(right);
                    if (targetValueRange == null)
                    {
                        targetValueRange = new ItemValueRange();
                    }
                    fieldInfo.SetValue(target, targetValueRange + rightValueRange);
                }
            }

            return target;
        }

        /// <summary />
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static ItemAttributes operator -(ItemAttributes left, ItemAttributes right)
        {
            var target = new ItemAttributes(left);

            var type = target.GetType();
            foreach (var fieldInfo in type.GetTypeInfo().DeclaredFields)
            {
                if (fieldInfo.Name != "UnmanagedAttributes" && fieldInfo.GetValue(right) != null)
                {
                    var targetValueRange = (ItemValueRange)fieldInfo.GetValue(target);
                    var rightValueRange = (ItemValueRange)fieldInfo.GetValue(right);
                    if (targetValueRange == null)
                    {
                        targetValueRange = new ItemValueRange();
                    }
                    targetValueRange -= rightValueRange;
                    if (targetValueRange.Min == 0 && targetValueRange.Max == 0)
                    {
                        targetValueRange = null;
                    }
                    fieldInfo.SetValue(target, targetValueRange - rightValueRange);
                }
            }

            return target;
        }

        /// <summary />
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static ItemAttributes operator *(ItemAttributes left, ItemAttributes right)
        {
            var target = new ItemAttributes(left);

            var type = target.GetType();

            foreach (var fieldInfo in type.GetTypeInfo().DeclaredFields)
            {
                if (fieldInfo.Name != "UnmanagedAttributes" && fieldInfo.GetValue(right) != null)
                {
                    var targetValueRange = (ItemValueRange)fieldInfo.GetValue(target);
                    var rightValueRange = (ItemValueRange)fieldInfo.GetValue(right);
                    if (targetValueRange == null)
                    {
                        targetValueRange = new ItemValueRange(1);
                    }
                    fieldInfo.SetValue(target, targetValueRange * rightValueRange);
                }
            }

            return target;
        }

        #endregion
    }
}