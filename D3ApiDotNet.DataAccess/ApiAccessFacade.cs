using System;
using System.IO;
using D3ApiDotNet.Core.Objects.Artisan;
using D3ApiDotNet.Core.Objects.Follower;
using D3ApiDotNet.Core.Objects.Hero;
using D3ApiDotNet.Core.Objects.Images;
using D3ApiDotNet.Core.Objects.Item;
using D3ApiDotNet.Core.Objects.Profile;
using D3ApiDotNet.DataAccess.API;
using D3ApiDotNet.DataAccess.API.FilepathProviders;
using D3ApiDotNet.DataAccess.API.FilepathProviders.Factories;
using D3ApiDotNet.DataAccess.API.UrlConstruction.Factories;
using D3ApiDotNet.DataAccess.Repositories;
using D3ApiDotNet.DataAccess.Repositories.Factories;
using System.Net;

namespace D3ApiDotNet.DataAccess
{
    public class ApiAccessFacade : IApiAccessFacade
    {

        private readonly IFilePathProvider _filepathprovider;
        private readonly IRepositoryFactory _repositoryFactory;
        private CollectMode _collectMode;

        private IReadonlyRepository<Stream, string> _readRepo;
        private readonly IReadonlyRepository<Stream,string> _webRepo;
        private readonly ICacheRepository<Stream,string> _cacheRepo;

        public ApiAccessFacade(CollectMode mode, Locales locale, WebProxy proxy, TimeSpan cacheTime)
        {

            var filepathproviderFactory = new FilePathProviderChainFactory();
            IUrlConstructionProviderFactory urlcontructionproviderFactory = new UrlConstructionProviderFactory();
            _repositoryFactory = new RepositoryFactory();
            _collectMode = mode;
            _filepathprovider = filepathproviderFactory.CreateFilePathProvider("");
            _webRepo = new StreamWebRepository(proxy);
            _cacheRepo = new StreamCacheFileFromUrlRepository(cacheTime, _filepathprovider);
            _readRepo = _repositoryFactory.CreateReadRepository(_filepathprovider, _collectMode, _webRepo, _cacheRepo);

            ProfileRepository = new ProfileRepository(_readRepo,urlcontructionproviderFactory.CreateUrlConstructionProvider(locale,typeof(Profile)));
            HeroRepository = new HeroRepository(_readRepo, urlcontructionproviderFactory.CreateUrlConstructionProvider(locale, typeof(Hero)));
            ItemRepository = new ItemRepository(_readRepo, urlcontructionproviderFactory.CreateUrlConstructionProvider(locale, typeof(Item)));
            FollowerRepository = new FollowerRepository(_readRepo, urlcontructionproviderFactory.CreateUrlConstructionProvider(locale, typeof(Follower)));
            ArtisanRepository = new ArtisanRepository(_readRepo, urlcontructionproviderFactory.CreateUrlConstructionProvider(locale, typeof(Artisan)));
            SkillIconRepository = new SkillIconRepository(_readRepo, urlcontructionproviderFactory.CreateUrlConstructionProvider(locale, typeof(D3Icon)));
            ItemIconRepository = new ItemIconRepository(_readRepo, urlcontructionproviderFactory.CreateUrlConstructionProvider(locale, typeof(D3Icon)));
        }

        public CollectMode CollectMode
        {
            get { return _collectMode; }
            set
            {
                if (value != _collectMode) { 
                    _collectMode = value;
                    _readRepo = _repositoryFactory.CreateReadRepository(_filepathprovider, _collectMode, _webRepo, _cacheRepo);
                }
            }
        }

        public ProfileRepository ProfileRepository { get; private set; }
        public HeroRepository HeroRepository { get; private set; }
        public ItemRepository ItemRepository { get; private set; }
        public FollowerRepository FollowerRepository { get; private set; }
        public ArtisanRepository ArtisanRepository { get; private set; }
        public SkillIconRepository SkillIconRepository { get; private set; }
        public ItemIconRepository ItemIconRepository { get; private set; }

        public IReadonlyRepository<Stream, string> ReadRepo
        {
            get { return _readRepo; }
            set { if (value != null) _readRepo = value; }
        }
    }
}
