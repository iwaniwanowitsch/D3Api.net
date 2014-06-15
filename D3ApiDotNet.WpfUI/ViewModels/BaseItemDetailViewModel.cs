using System.Collections.Generic;
using System.Linq;
using D3ApiDotNet.Core.Objects.Images;
using D3ApiDotNet.Core.Objects.Item;

namespace D3ApiDotNet.WpfUI.ViewModels
{
    public abstract class BaseItemDetailViewModel : IItemDetailViewModel
    {
        public virtual Item Item { get; set; }
        public virtual D3Icon Icon { get; protected set; }
        public virtual IItemViewModel ItemViewModel { get; protected set; }
        public virtual IList<string> Attributes
        {
            get
            {
                var primary = Item.Attributes.Primary ?? new ItemTextAttribute[0];
                var secondary = Item.Attributes.Secondary ?? new ItemTextAttribute[0];
                var passive = Item.Attributes.Passive ?? new ItemTextAttribute[0];
                return primary.Concat(secondary).Concat(passive).Select(o => o.Text).ToList();
            }
        }

        public virtual IList<string> Gems
        {
            get
            {
                var gems = Item.Gems ?? new SocketedGems[0];
                var primary = gems.SelectMany(o => o.Attributes.Primary ?? new ItemTextAttribute[0]);
                var secondary = gems.SelectMany(o => o.Attributes.Secondary ?? new ItemTextAttribute[0]);
                var passive = gems.SelectMany(o => o.Attributes.Passive ?? new ItemTextAttribute[0]);
                return primary.Concat(secondary).Concat(passive).Select(o => o.Text).ToList();
            }
        } 
    }
}