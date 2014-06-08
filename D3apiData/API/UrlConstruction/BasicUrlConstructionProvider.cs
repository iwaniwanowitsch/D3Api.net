using System.Collections.Generic;

namespace D3apiData.API.UrlConstruction
{
    /// <summary>
    /// holds constants for url construction. like hosts and locales.
    /// </summary>
    public abstract class BasicUrlConstructionProvider
    {
        public Locales Locale { get; set; }

        protected BasicUrlConstructionProvider(Locales locale)
        {
            Locale = locale;
        }

        /// <summary />
        protected readonly Dictionary<Locales, string> HostLookup = new Dictionary<Locales, string>
        {
            { Locales.en_US, "us" },
            { Locales.en_GB, "eu" },
            { Locales.es_MX, "us" },
            { Locales.es_ES, "eu" },
            { Locales.it_IT, "eu" },
            { Locales.pt_PT, "eu" },
            { Locales.pt_BR, "us" },
            { Locales.fr_FR, "eu" },
            { Locales.ru_RU, "eu" },
            { Locales.pl_PL, "eu" },
            { Locales.de_DE, "eu" },
            { Locales.ko_KR, "kr" },
            { Locales.zh_TW, "tw" }
        };

        /// <summary />
        protected const string Mediahost = ".media.blizzard.com/d3/";

        /// <summary />
        protected const string Apihost = ".battle.net";

        /// <summary />
        protected const string Apipath = "/api/d3/";
    }
}