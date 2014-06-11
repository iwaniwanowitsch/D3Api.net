namespace D3ApiDotNet.Core.Calculation
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
        private double _ccPercent;
        private double _cdPercent;
        private double _atkSpdPercent;
        private double _mainStats;

        public HeroDamageData(double profileDps, double correctedDps, double elementalDmgPercent, string elementalType, double vsElitesDmgPercent, double passiveSkillsDmgPercent, double cooldownReduction, double resourceCostReduction, double ccPercent, double cdPercent, double atkSpdPercent, double mainStats)
        {
            ProfileDps = profileDps;
            CorrectedDps = correctedDps;
            ElementalDmgPercent = elementalDmgPercent;
            ElementalType = elementalType;
            VsElitesDmgPercent = vsElitesDmgPercent;
            PassiveSkillsDmgPercent = passiveSkillsDmgPercent;
            CooldownReduction = cooldownReduction;
            ResourceCostReduction = resourceCostReduction;
            CcPercent = ccPercent;
            CdPercent = cdPercent;
            AtkSpdPercent = atkSpdPercent;
            MainStats = mainStats;
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

        public double PassiveSkillsDmgPercent
        {
            get { return _passiveSkillsDmgPercent; }
            set { _passiveSkillsDmgPercent = value; }
        }

        public double CcPercent
        {
            get { return _ccPercent; }
            set { _ccPercent = value; }
        }

        public double CdPercent
        {
            get { return _cdPercent; }
            set { _cdPercent = value; }
        }

        public double AtkSpdPercent
        {
            get { return _atkSpdPercent; }
            set { _atkSpdPercent = value; }
        }

        public double MainStats
        {
            get { return _mainStats; }
            set { _mainStats = value; }
        }

        public double DpsWithBoni(bool includingPassives, bool includingElemental, bool includingVsElites)
        {
            return _correctedDps*
                   (includingPassives ? (1 + PassiveSkillsDmgPercent) : 1)*
                   (includingElemental ? (1 + _elementalDmgPercent) : 1)*
                   (includingVsElites ? (1 + _vsElitesDmgPercent) : 1);
        }
    }
}
