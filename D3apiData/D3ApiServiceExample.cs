using System;
using D3apiData.API;
using D3apiData.Persistence;
using D3apiData.WebClient;
using System.ComponentModel;

namespace D3apiData
{
    class D3ApiServiceExample
    {
        private readonly ISerializer<Properties> _serializer = new SerializerXML<Properties>();
        private const string Configfile = @"config.xml";
        private D3Data _data;
        private ID3Collector _collector;

        public D3WebClient Webclient { get; set; }

        /// <summary>
        /// change properties in this object
        /// </summary>
        public Properties Config { get; set; }

        /// <summary>
        /// all data fetching goes through this object
        /// </summary>
        public D3Data Data
        {
            get { return _data; }
        }

        public D3ApiServiceExample()
        {
            LoadConfig();
            if (Config == null)
            {
                Config = new Properties(Locales.en_GB,CollectMode.TryCacheThenOnline);
                SaveConfig();
            }
            Config.PropertyChanged += new PropertyChangedEventHandler((o, args) => { if (args.PropertyName == "CollectMode") _data = new D3Data(Config, _collector); });
            Config.PropertyChanged += new PropertyChangedEventHandler((o, args) => { if (args.PropertyName == "PropertyChanged") SaveConfig(); });
            Webclient = new D3WebClient();

            var mode = Config.CollectMode;
            var cacheCollector = new CacheCollector(Config.CachePath,
                new HeroFilePathProvider(
                    new ProfileFilePathProvider(
                        new ItemFilePathProvider(
                            new IconFilePathProvider(
                                new DefaultFilePathProvider())))));
            var onlineCollector = new OnlineCollector(Webclient);
            switch (mode)
            {
                case CollectMode.Online:
                    _collector = onlineCollector;
                    break;
                case CollectMode.Offline:
                    _collector = cacheCollector;
                    break;
                case CollectMode.TryCacheThenOnline:
                    _collector = new TryCacheThenOnlineCollector(cacheCollector, onlineCollector);
                    break;
                case CollectMode.OnlineWithCache:
                    _collector = new OnlineWithCacheCollector(cacheCollector, onlineCollector);
                    break;
            }

            _data = new D3Data(Config, _collector);
        }

        /// <summary>
        /// explicitely save config to file
        /// </summary>
        public void SaveConfig() {
            _serializer.Serialize(Config,Configfile);
        }

        /// <summary>
        /// explicitely load config from file
        /// </summary>
        public void LoadConfig()
        {
            try { 
                Config = _serializer.Deserialize(Configfile);
            }
            catch (InvalidOperationException)
            {
                Config = null;
            }
        }
    }
}
