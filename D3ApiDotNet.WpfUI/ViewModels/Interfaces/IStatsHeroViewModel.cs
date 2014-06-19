using D3ApiDotNet.Core.Calculation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D3ApiDotNet.WpfUI.ViewModels.Interfaces
{
    public interface IStatsHeroViewModel
    {
        IHeroViewModel HeroViewModel { get; set; }

        DamageTermComposite DamageTerms { get; set; }

        EhpTermComposite EhpTerms { get; set; }

        void Update();
    }
}
