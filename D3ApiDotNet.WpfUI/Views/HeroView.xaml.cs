using System.Windows;
using System.Windows.Controls;

namespace D3ApiDotNet.WpfUI.Views
{
    /// <summary>
    /// Interaktionslogik für HeroView.xaml
    /// </summary>
    public partial class HeroView : UserControl
    {
        public HeroView()
        {
            InitializeComponent();
            SetSampleData();
        }

        private void SetSampleData()
        {
            var noitem = this.FindResource("NoItemBorderStyle") as Style;
            var leg = this.FindResource("OrangeItemBorderStyle") as Style;
            var setitem = this.FindResource("GreenItemBorderStyle") as Style;
            var blue = this.FindResource("BlueItemBorderStyle") as Style;
            var white = this.FindResource("WhiteItemBorderStyle") as Style;
            var gray = this.FindResource("GrayItemBorderStyle") as Style;

            // For Layout Testing:
            HeadItemView.ImagePathForTesting = "http://media.blizzard.com/d3/icons/items/large/helm_002_demonhunter_male.png";
            HeadItemView.ColorForTesting = noitem;
            ShoulderItemView.ImagePathForTesting = "http://media.blizzard.com/d3/icons/items/large/unique_shoulder_001_x1_demonhunter_male.png";
            ShoulderItemView.ColorForTesting = leg;
            AmuletItemView.ImagePathForTesting = "http://media.blizzard.com/d3/icons/items/large/unique_amulet_003_x1_demonhunter_male.png";
            AmuletItemView.ColorForTesting = setitem;

            HandItemView.ImagePathForTesting = "http://media.blizzard.com/d3/icons/items/large/gloves_003_demonhunter_male.png";
            ChestItemView.ImagePathForTesting = "http://media.blizzard.com/d3/icons/items/large/chestarmor_002_demonhunter_male.png";
            BracerItemView.ImagePathForTesting = "http://media.blizzard.com/d3/icons/items/large/bracers_001_demonhunter_male.png";
            BracerItemView.ColorForTesting = gray;

            LeftRingItemView.ImagePathForTesting = "http://media.blizzard.com/d3/icons/items/large/unique_ring_024_104_demonhunter_male.png";
            WaistItemView.ImagePathForTesting = "http://media.blizzard.com/d3/icons/items/large/belt_003_demonhunter_male.png";
            WaistItemView.ColorForTesting = white;
            RightRingItemView.ImagePathForTesting = "http://media.blizzard.com/d3/icons/items/large/ring_02_demonhunter_male.png";
            RightRingItemView.ColorForTesting = blue;

            MainHandItemView.ImagePathForTesting = "http://media.blizzard.com/d3/icons/items/large/axe_1h_003_demonhunter_male.png";
            PantsItemView.ImagePathForTesting = "http://media.blizzard.com/d3/icons/items/large/pants_002_demonhunter_male.png";
            OffHandItemView.ImagePathForTesting = "http://media.blizzard.com/d3/icons/items/large/unique_shield_007_x1_demonhunter_male.png";

            BootsItemView.ImagePathForTesting = "http://media.blizzard.com/d3/icons/items/large/boots_001_demonhunter_male.png";
        }
    }
}
