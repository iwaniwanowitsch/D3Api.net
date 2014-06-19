using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using D3ApiDotNet.Core.Calculation;
using D3ApiDotNet.WpfUI.ViewModels.Interfaces;

namespace D3ApiDotNet.WpfUI.SampleData
{
    public class StatsHeroViewModelSampleData : IStatsHeroViewModel
    {

        public StatsHeroViewModelSampleData()
        {
            HeroViewModel = new HeroViewModelSampleData() { StatsViewModel = this };
            DamageTerms = HeroViewModel.StatsViewModel.DamageTerms;
            EhpTerms = HeroViewModel.StatsViewModel.EhpTerms;
        }

        public IHeroViewModel HeroViewModel { get; set; }
        public DamageTermComposite DamageTerms { get; set; }
        public EhpTermComposite EhpTerms { get; set; }

        public void Update()
        {
            
        }
    }
}
