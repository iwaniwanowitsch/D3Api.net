using System;
using System.Drawing;
using System.Net.Mime;
using System.Windows;
using D3ApiDotNet.Core.Objects.Images;
using D3ApiDotNet.Core.Objects.Item;
using D3ApiDotNet.DataAccess.Repositories;
using D3ApiDotNet.WpfUI.ViewModels;
using System.IO;
using D3ApiDotNet.WpfUI.Properties;

namespace D3ApiDotNet.WpfUI.SampleData
{
    public class ItemDetailViewModelSampleData : BaseItemDetailViewModel
    {
        public ItemDetailViewModelSampleData()
        {
            Icon = new D3Icon { Icon = Resources.unique_spiritstone_004_x1_demonhunter_male_small };
            Item = new Item { Name = "Shenlong's Relentless Assault", TypeName = "Set Fist Weapon", RequiredLevel = 70, DisplayColor = "green", Attributes = new ItemTextAttributes { Primary = new[] { new ItemTextAttribute { Text = "+1191–1450 Lightning Damage", Color = "green", AffixType = "default" }, new ItemTextAttribute { Text = "+714 Dexterity", Color = "blue", AffixType = "default" } } } };
            //Item.Attributes.Secondary = new[] { new ItemTextAttribute { Text = "blub", Color = "blue", AffixType = "default" } };
        }
    }
}
