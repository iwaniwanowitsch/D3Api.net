using System.Collections.Generic;
using System.Linq;
using D3ApiDotNet.Core.Objects.Images;
using D3ApiDotNet.Core.Objects.Item;
using D3ApiDotNet.WpfUI.ViewModels.Interfaces;

namespace D3ApiDotNet.WpfUI.ViewModels
{
    public abstract class BaseItemDetailViewModel : BaseViewModel, IItemDetailViewModel
    {
        private Item _item;
        private D3Icon _icon;

        public virtual Item Item
        {
            get
            {
                return _item;
            }
            set
            {
                this.SetValueIfChanged(ref _item, value);
            }
        }

        public virtual D3Icon Icon
        {
            get
            {
                return _icon;
            }
            protected set
            {
                this.SetValueIfChanged(ref _icon, value);
            }
        }

        public virtual IList<ItemTextAttribute> PrimaryAttributes
        {
            get
            {
                if (Item == null) return null;
                var primary = Item.Attributes.Primary ?? new ItemTextAttribute[0];
                return primary.ToList();
            }
        }

        public virtual IList<ItemTextAttribute> SecondaryAttributes
        {
            get
            {
                if (Item == null) return null;
                var secondary = Item.Attributes.Secondary ?? new ItemTextAttribute[0];
                var passive = Item.Attributes.Passive ?? new ItemTextAttribute[0];
                return secondary.Concat(passive).ToList();
            }
        }

        public virtual IList<ItemTextAttribute> Gems
        {
            get
            {
                if (Item == null) return null;
                var gems = Item.Gems ?? new SocketedGems[0];
                var primary = gems.SelectMany(o => o.Attributes.Primary ?? new ItemTextAttribute[0]);
                var secondary = gems.SelectMany(o => o.Attributes.Secondary ?? new ItemTextAttribute[0]);
                var passive = gems.SelectMany(o => o.Attributes.Passive ?? new ItemTextAttribute[0]);
                return primary.Concat(secondary).Concat(passive).ToList();
            }
        } 
    }
}