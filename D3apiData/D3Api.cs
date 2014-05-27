using System;
using D3apiData.API;
using D3apiData.Persistence;
using D3apiData.WebClient;
using System.ComponentModel;

namespace D3apiData
{
    class D3Api
    {
        private readonly ISerializer<Properties> _serializer = new SerializerXML<Properties>();
        private const string Configfile = @"config.xml";
        private D3Data _data;

        internal D3WebClient Webclient { get; set; }

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

        public D3Api()
        {
            LoadConfig();
            if (Config == null)
            {
                Config = new Properties(Locales.en_GB,CollectMode.TryCacheThenOnline);
                SaveConfig();
            }
            Config.PropertyChanged += new PropertyChangedEventHandler((o, args) => { if (args.PropertyName == "CollectMode") _data = new D3Data(Config); });
            Config.PropertyChanged += new PropertyChangedEventHandler((o, args) => { if (args.PropertyName == "PropertyChanged") SaveConfig(); });
            Webclient = new D3WebClient();
            _data = new D3Data(Config);
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
