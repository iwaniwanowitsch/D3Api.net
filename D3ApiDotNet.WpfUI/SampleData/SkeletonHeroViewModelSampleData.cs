using D3ApiDotNet.Core.Objects.Hero;
using D3ApiDotNet.WpfUI.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D3ApiDotNet.WpfUI.SampleData
{
    public class SkeletonHeroViewModelSampleData : ISkeletonHeroViewModel
    {

        public SkeletonHeroViewModelSampleData()
        {
            HeroViewModel = new HeroViewModelSampleData { SkeletonHeroViewModel = this };
        }

        public IHeroViewModel HeroViewModel { get; set; }
    }
}
