using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D3apiData.API.Objects
{

    public class Profile
    {
        public Hero[] heroes { get; set; }
        public int lastHeroPlayed { get; set; }
        public int lastUpdated { get; set; }
        public Kills kills { get; set; }
        public Timeplayed timePlayed { get; set; }
        public Hero[] fallenHeroes { get; set; }
        public int paragonLevel { get; set; }
        public int paragonLevelHardcore { get; set; }
        public string battleTag { get; set; }
        public Progression progression { get; set; }
    }

    public class Kills
    {
        public int monsters { get; set; }
        public int elites { get; set; }
        public int hardcoreMonsters { get; set; }
    }

    public class Timeplayed
    {
        public float barbarian { get; set; }
        public float crusader { get; set; }
        public float demonhunter { get; set; }
        public float monk { get; set; }
        public float witchdoctor { get; set; }
        public float wizard { get; set; }
    }

    public class Progression
    {
        public bool act1 { get; set; }
        public bool act2 { get; set; }
        public bool act3 { get; set; }
        public bool act4 { get; set; }
        public bool act5 { get; set; }
    }

    public class Hero
    {
        public int paragonLevel { get; set; }
        public string name { get; set; }
        public int id { get; set; }
        public int level { get; set; }
        public bool hardcore { get; set; }
        public int gender { get; set; }
        public bool dead { get; set; }
        public string _class { get; set; }
        public int lastupdated { get; set; }
    }
}