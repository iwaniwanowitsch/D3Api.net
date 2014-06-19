using D3ApiDotNet.Core.Calculation;
using D3ApiDotNet.Core.NotifyPropertyChanged;
using D3ApiDotNet.WpfUI.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D3ApiDotNet.WpfUI.ViewModels
{
    public class StatsHeroViewModel : BaseNotifyPropertyChanged, IStatsHeroViewModel
    {
        private IHeroViewModel _heroViewModel;
        private DamageTermComposite _damageTerms;
        private EhpTermComposite _ehpTerms;

        public StatsHeroViewModel(DamageTermComposite damageTerms, EhpTermComposite ehpTerms, IHeroViewModel heroViewModel)
        {
            DamageTerms = damageTerms;
            EhpTerms = ehpTerms;
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

        public DamageTermComposite DamageTerms
        {
            get { return _damageTerms; }
            set { this.SetValueIfChanged(ref _damageTerms, value); }
        }

        public EhpTermComposite EhpTerms
        {
            get { return _ehpTerms; }
            set { this.SetValueIfChanged(ref _ehpTerms, value); }
        }

        public void Update()
        {
            RaisePropertyChanged("DamageTerms");
            RaisePropertyChanged("EhpTerms");
        }
    }
}
