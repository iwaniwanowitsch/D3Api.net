using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using D3apiData.API.Objects.Hero;
using D3apiData.API.Objects.Item;

namespace D3Calculation.CalculatorStats
{
    class DamageStats
    {
        private float _profileDmg;
        private Dictionary<DamageTypes, int> _percentageElementalDmg;
        private int _percentageElitesDmg;

        private Hero _hero;

        public DamageStats(Hero hero, Dictionary<DamageTypes, int> percentageElementalDmg, int percentageElitesDmg)
        {
            if (hero == null) throw new ArgumentNullException("hero");
            _hero = hero;
            PercentageElementalDmg = percentageElementalDmg;
            PercentageElitesDmg = percentageElitesDmg;
            ProfileDmg = _hero.Stats.Damage;
        }

        public float ProfileDmg
        {
            get { return _profileDmg; }
            set { _profileDmg = value; }
        }

        public Dictionary<DamageTypes, int> PercentageElementalDmg
        {
            get { return _percentageElementalDmg; }
            set { _percentageElementalDmg = value; }
        }

        public int PercentageElitesDmg
        {
            get { return _percentageElitesDmg; }
            set { _percentageElitesDmg = value; }
        }
    }
}
