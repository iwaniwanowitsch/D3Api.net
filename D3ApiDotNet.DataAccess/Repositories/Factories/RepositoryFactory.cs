using System;
using System.IO;
using D3ApiDotNet.DataAccess.API;
using D3ApiDotNet.DataAccess.API.FilepathProviders;
using D3ApiDotNet.DataAccess.API.FilepathProviders.Factories;
using System.Net;

namespace D3ApiDotNet.DataAccess.Repositories.Factories
{
    public class RepositoryFactory : IRepositoryFactory
    {

        public IReadonlyRepository<Stream, string> CreateReadRepository(IFilePathProvider filepathprovider, CollectMode mode, WebProxy proxy)
        {
            if (filepathprovider == null) throw new ArgumentNullException("filepathprovider");
            IReadonlyRepository<Stream, string> readRepo = null;
            ICacheRepository<Stream, string> cacheRepo = new StreamCacheFileFromUrlRepository(new TimeSpan(0, 0, 15, 0), filepathprovider);
            IReadonlyRepository<Stream, string> webRepo = new StreamWebRepository(proxy);
            switch (mode)
            {
                case CollectMode.Offline:
                    readRepo = new StreamCacheFileFromUrlRepository(TimeSpan.MaxValue, filepathprovider);
                    break;
                case CollectMode.Online:
                    readRepo = webRepo;
                    break;
                case CollectMode.OnlineWithCache:
                    readRepo = new CacheRepositoryDecorator<Stream, string>(webRepo,cacheRepo);
                    break;
                case CollectMode.TryCacheThenOnline:
                    readRepo = new TryCacheRepositoryDecorator<Stream, string>(webRepo,cacheRepo);
                    break;
            }
            return readRepo;
        }
    }
}
