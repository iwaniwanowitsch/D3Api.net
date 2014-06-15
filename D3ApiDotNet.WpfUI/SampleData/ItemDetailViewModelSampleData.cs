using System;
using System.Drawing;
using System.Net.Mime;
using System.Windows;
using D3ApiDotNet.Core.Objects.Images;
using D3ApiDotNet.Core.Objects.Item;
using D3ApiDotNet.DataAccess.Repositories;
using D3ApiDotNet.WpfUI.ViewModels;

namespace D3ApiDotNet.WpfUI.SampleData
{
    public class ItemDetailViewModelSampleData : BaseItemDetailViewModel
    {
        public ItemDetailViewModelSampleData()
        {
            Icon = new D3Icon { Icon = Image.FromStream(new StreamWebRepository(null).Retrieve("http://eu.media.blizzard.com/d3/icons/items/small/unique_spiritstone_004_x1_demonhunter_male.png")) };
            Item = new Item { Name = "Shenlong's Relentless Assault", TypeName = "Set Fist Weapon", RequiredLevel = 70, DisplayColor = "green", Attributes = new ItemTextAttributes { Primary = new[] { new ItemTextAttribute { Text = "+1191–1450 Lightning Damage", Color = "green", AffixType = "default" }, new ItemTextAttribute { Text = "+714 Dexterity", Color = "blue", AffixType = "default" } } } };
        }
    }
}
