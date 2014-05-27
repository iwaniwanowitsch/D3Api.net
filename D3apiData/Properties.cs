
using D3apiData.API;
using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace D3apiData
{
    /// <summary>
    /// structure to take Config data
    /// </summary>
    public class Properties : INotifyPropertyChanged
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
                OnPropertyChanged("Save");
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
                OnPropertyChanged("Save");
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
                OnPropertyChanged("Save");
            }
        }

        /// <summary>
        /// constructor with default values
        /// </summary>
        public Properties()
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
        public Properties(Locales locale, CollectMode collectMode)
            : this()
        {
            _locale = locale;
            _collectMode = collectMode;
        }

        /// <summary />
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
