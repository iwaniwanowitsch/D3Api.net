using D3apiData.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D3Calculation
{
    public class EhpCalculator
    {
        public readonly D3Data _data;

        public EhpCalculator(D3Data data)
        {
            if (data == null) throw new ArgumentNullException("data");
            _data = data;
        }

        public double GetEhp(double herolvl, double hp, double hpPercent, double armor, double dodgePercent, double physResist, double coldResist, double fireResist, double lightResist, double poisonResist, double arcaneResist, double meleeReductionPercent, double rangedReductionPercent, double vsEliteReductionPercent) {
            // damage reduction armor
            var dra = 1 - armor / (50*herolvl + armor);
            // damage reduction ressistances
            var resistAvg = (physResist + coldResist + fireResist + lightResist + poisonResist + arcaneResist) / 6;
            var drr = 1 - resistAvg / (5*herolvl + resistAvg);
            // damage reduction dodge
            var drd = 1 - dodgePercent;
            // damage reduction other factors
            var dro = 1 - (meleeReductionPercent + rangedReductionPercent + vsEliteReductionPercent) / 3;
            // actual hp
            var ahp = hp * (1 + hpPercent);
            return ahp / (dra * drr * drd * dro);
        }
    }
}
