using System;
using System.Collections.Generic;
using D3apiData.API;
using D3apiData.API.Objects.Hero;
using D3apiData.API.Objects.Item;

namespace D3Calculation
{
    public class HeroItemsFetcher
    {
        private readonly D3Data _data;

        public HeroItemsFetcher(D3Data data)
        {
            if (data == null) throw new ArgumentNullException("data");
            _data = data;
        }

        public List<Item> GetItemsList(Hero hero)
        {
            var returnList = new List<Item>();
            var items = hero.Items;
            // god of object orientated programming - forgive me :D
            if (items.Bracers != null)
                returnList.Add(_data.GetItemByTooltipParams(items.Bracers.TooltipParams));
            if (items.Feet != null)
                returnList.Add(_data.GetItemByTooltipParams(items.Feet.TooltipParams));
            if (items.Hands != null)
                returnList.Add(_data.GetItemByTooltipParams(items.Hands.TooltipParams));
            if (items.Head != null)
                returnList.Add(_data.GetItemByTooltipParams(items.Head.TooltipParams));
            if (items.LeftFinger != null)
                returnList.Add(_data.GetItemByTooltipParams(items.LeftFinger.TooltipParams));
            if (items.Legs != null)
                returnList.Add(_data.GetItemByTooltipParams(items.Legs.TooltipParams));
            if (items.MainHand != null)
                returnList.Add(_data.GetItemByTooltipParams(items.MainHand.TooltipParams));
            if (items.Neck != null)
                returnList.Add(_data.GetItemByTooltipParams(items.Neck.TooltipParams));
            if (items.OffHand != null)
                returnList.Add(_data.GetItemByTooltipParams(items.OffHand.TooltipParams));
            if (items.RightFinger != null)
                returnList.Add(_data.GetItemByTooltipParams(items.RightFinger.TooltipParams));
            if (items.Shoulders != null)
                returnList.Add(_data.GetItemByTooltipParams(items.Shoulders.TooltipParams));
            if (items.Torso != null)
                returnList.Add(_data.GetItemByTooltipParams(items.Torso.TooltipParams));
            if (items.Waist != null)
                returnList.Add(_data.GetItemByTooltipParams(items.Waist.TooltipParams));
            return returnList;
        }
    }
}
