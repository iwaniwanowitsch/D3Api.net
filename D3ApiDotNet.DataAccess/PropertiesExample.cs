using System.ComponentModel;
using D3ApiDotNet.DataAccess;
using D3ApiDotNet.DataAccess.API;

namespace D3ApiDotNet.DataAccess
{
    /// <summary>
    /// structure to take Config data
    /// </summary>
    public class PropertiesExample : INotifyPropertyChanged
    {
        private CollectMode _collectMode;
        private Locales _locale;
        private string _cachePath;

        /// <summary>
        ///  path to cache file
        /// </summary>
        public string CachePath
        {
            get
            {
                return _cachePath;
            }
            set
            {
                if (value == null)
                    return;
                _cachePath = value;
                OnPropertyChanged("PropertyChanged");
            }
        }

        /// <summary>
        /// localization of user
        /// </summary>
        public Locales Locale
        {
            get
            {
                return _locale;
            }
            set
            {
                _locale = value;
                OnPropertyChanged("PropertyChanged");
            }
        }

        /// <summary />
        /// <param name="e"></param>
        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, e);
        }
        
        /// <summary />
        /// <param name="propertyName"></param>
        protected void OnPropertyChanged(string propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }


        /// <summary>
        /// mode of collector to be chosen
        /// </summary>
        public CollectMode CollectMode
        {
            get
            {
                return _collectMode;
            }
            set
            {
                _collectMode = value;
                OnPropertyChanged("CollectMode");
                OnPropertyChanged("PropertyChanged");
            }
        }

        /// <summary>
        /// constructor with default values
        /// </summary>
        public PropertiesExample()
        {
            _cachePath = @"cache\";
            _locale = Locales.en_GB;
            _collectMode = CollectMode.TryCacheThenOnline;
        }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="locale"></param>
        /// <param name="collectMode"></param>
        public PropertiesExample(Locales locale, CollectMode collectMode)
            : this()
        {
            _locale = locale;
            _collectMode = collectMode;
        }

        /// <summary />
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
