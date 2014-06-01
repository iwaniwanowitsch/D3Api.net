using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D3Calculation
{
    class HeroDamageData
    {
        private double _profileDps;
        private double _correctedDps;
        private double _elementalDmgPercent;
        private string _elementalType;
        private double _vsElitesDmgPercent;
        private double _passiveSkillsDmgPercent;
        private double _cooldownReduction;
        private double _resourceCostReduction;

        public HeroDamageData(double profileDps, double correctedDps, double elementalDmgPercent, string elementalType, double vsElitesDmgPercent, double passiveSkillsDmgPercent, double cooldownReduction, double resourceCostReduction)
        {
            ProfileDps = profileDps;
            CorrectedDps = correctedDps;
            ElementalDmgPercent = elementalDmgPercent;
            ElementalType = elementalType;
            _vsElitesDmgPercent = vsElitesDmgPercent;
            _passiveSkillsDmgPercent = passiveSkillsDmgPercent;
            _cooldownReduction = cooldownReduction;
            _resourceCostReduction = resourceCostReduction;
        }

        public double ProfileDps
        {
            get { return _profileDps; }
            set { _profileDps = value; }
        }

        public double CorrectedDps
        {
            get { return _correctedDps; }
            set { _correctedDps = value; }
        }

        public double ElementalDmgPercent
        {
            get { return _elementalDmgPercent; }
            set { _elementalDmgPercent = value; }
        }

        public string ElementalType
        {
            get { return _elementalType; }
            set { _elementalType = value; }
        }

        public double VsElitesDmgPercent
        {
            get { return _vsElitesDmgPercent; }
            set { _vsElitesDmgPercent = value; }
        }

        public double CooldownReduction
        {
            get { return _cooldownReduction; }
            set { _cooldownReduction = value; }
        }

        public double ResourceCostReduction
        {
            get { return _resourceCostReduction; }
            set { _resourceCostReduction = value; }
        }

        public double DpsWithBoni(bool includingPassives, bool includingElemental, bool includingVsElites)
        {
            return _correctedDps*
                   (includingPassives ? (1 + _passiveSkillsDmgPercent) : 1)*
                   (includingElemental ? (1 + _elementalDmgPercent) : 1)*
                   (includingVsElites ? (1 + _vsElitesDmgPercent) : 1);
        }
    }
}
