using System.ComponentModel;
using System.IO;
using D3apiData.API;
using D3apiData.API.FilepathProviders;
using D3apiData.API.UrlConstruction;
using D3apiData.Repositories;

namespace D3apiData
{
    public class D3ApiService
    {
        private readonly ProfileRepository _profileRepository;
        private readonly HeroRepository _heroRepository;
        private readonly ItemRepository _itemRepository;
        private readonly FollowerRepository _followerRepository;
        private readonly ArtisanRepository _artisanRepository;
        private readonly SkillIconRepository _skillIconRepository;
        private readonly ItemIconRepository _itemIconRepository;

        private IReadonlyRepository<Stream, string> _readRepo;
        private IReadonlyRepository<Stream, string> _webRepo;
        private IRepository<Stream, string> _fileRepo; 

        private const string Configfile = @"config.xml";
        private readonly XmlFileRepository<PropertiesExample> _configFileRepository = new XmlFileRepository<PropertiesExample>();

        public D3ApiService()
        {
            LoadConfig();
            if (Config == null)
            {
                Config = new PropertiesExample(Locales.en_GB, CollectMode.TryCacheThenOnline);
                SaveConfig();
            }

            var locale = Config.Locale;
            var cachepath = Config.CachePath;

            Config.PropertyChanged += new PropertyChangedEventHandler((o, args) =>
            {
                if (args.PropertyName !=
                    "CollectMode") return;
                SetRepository(Config.CollectMode);
            });
            Config.PropertyChanged += new PropertyChangedEventHandler((o, args) => { if (args.PropertyName == "PropertyChanged") SaveConfig(); });

            var profileUrlConstructor = new ProfileUrlConstructionProvider(locale);
            var heroUrlConstructor = new HeroUrlConstructionProvider(locale);
            var itemUrlConstructor = new ItemUrlConstructionProvider(locale);
            var followerUrlConstructor = new FollowerUrlConstructionProvider(locale);
            var artisanUrlConstructor = new ArtisanUrlConstructionProvider(locale);
            var iconUrlConstructor = new IconUrlConstructionProvider(locale);

            var defaultFilePathProvider = new DefaultFilePathProvider(); // end of chain
            var iconFilePathProvider = new IconFilePathProvider(defaultFilePathProvider, cachepath);
            var itemFilePathProvider = new ItemFilePathProvider(iconFilePathProvider, cachepath);
            var profileFilePathProvider = new ProfileFilePathProvider(itemFilePathProvider, cachepath);
            var heroFilePathProvider = new HeroFilePathProvider(profileFilePathProvider, cachepath); // begin of chain

            _webRepo = new StreamWebRepository(null);
            _fileRepo = new StreamFileFromUrlRepository(heroFilePathProvider);
            SetRepository(Config.CollectMode);

            _profileRepository = new ProfileRepository(ReadRepo, profileUrlConstructor);
            _heroRepository = new HeroRepository(ReadRepo, heroUrlConstructor);
            _itemRepository = new ItemRepository(ReadRepo, itemUrlConstructor);
            _followerRepository = new FollowerRepository(ReadRepo, followerUrlConstructor);
            _artisanRepository = new ArtisanRepository(ReadRepo, artisanUrlConstructor);
            _skillIconRepository = new SkillIconRepository(ReadRepo, iconUrlConstructor);
            _itemIconRepository = new ItemIconRepository(ReadRepo, iconUrlConstructor);
        }

        private void SetRepository(CollectMode collectMode)
        {
            switch (collectMode)
            {
                case CollectMode.Offline:
                    ReadRepo = _fileRepo;
                    break;
                case CollectMode.Online:
                    ReadRepo = _webRepo;
                    break;
                case CollectMode.TryCacheThenOnline:
                    ReadRepo = new TryCacheRepositoryDecorator<Stream, string>(_webRepo, _fileRepo);
                    break;
                case CollectMode.OnlineWithCache:
                    ReadRepo = new CacheRepositoryDecorator<Stream, string>(_webRepo,_fileRepo);
                    break;
            }
        }

        public void LoadConfig()
        {
            try
            {
                Config = _configFileRepository.Retrieve(Configfile);
            }
            catch (RepositoryEntityNotFoundException)
            {
                Config = null;
            }
        }

        public IReadonlyRepository<Stream, string> ReadRepo
        {
            get { return _readRepo; }
            set { if (value != null) _readRepo = value; }
        } 

        public void SaveConfig()
        {
            _configFileRepository.Save(Config,Configfile);
        }

        public PropertiesExample Config { get; set; }

        public ProfileRepository ProfileRepository
        {
            get { return _profileRepository; }
        }

        public HeroRepository HeroRepository
        {
            get { return _heroRepository; }
        }

        public ItemRepository ItemRepository
        {
            get { return _itemRepository; }
        }

        public FollowerRepository FollowerRepository
        {
            get { return _followerRepository; }
        }

        public ArtisanRepository ArtisanRepository
        {
            get { return _artisanRepository; }
        }

        public SkillIconRepository SkillIconRepository
        {
            get { return _skillIconRepository; }
        }

        public ItemIconRepository ItemIconRepository
        {
            get { return _itemIconRepository; }
        }
    }
}
