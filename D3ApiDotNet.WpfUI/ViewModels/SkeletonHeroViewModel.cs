using D3ApiDotNet.Core.NotifyPropertyChanged;
using D3ApiDotNet.WpfUI.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D3ApiDotNet.WpfUI.ViewModels
{
    public class SkeletonHeroViewModel : BaseNotifyPropertyChanged, ISkeletonHeroViewModel
    {
        private IHeroViewModel _heroViewModel;

        public SkeletonHeroViewModel(IHeroViewModel heroViewModel)
        {
            HeroViewModel = heroViewModel;
        }

        public IHeroViewModel HeroViewModel
        {
            get
            {
                return _heroViewModel;
            }
            set
            {
                this.SetValueIfChanged(ref _heroViewModel, value);
            }
        }
    }
}
