using System;
using System.IO;
using System.Threading.Tasks;

namespace D3apiData.API
{
    class OnlineWithCacheCollector : ID3Collector
    {
        private readonly CacheCollector _cacheCollector;
        private readonly OnlineCollector _onlineCollector;

        public OnlineWithCacheCollector(CacheCollector cacheCollector, OnlineCollector onlineCollector)
        {
            if (cacheCollector == null)
                throw new ArgumentNullException("cacheCollector");
            if (onlineCollector == null)
                throw new ArgumentNullException("onlineCollector");
            _cacheCollector = cacheCollector;
            _onlineCollector = onlineCollector;
        }


        public Stream CollectStreamFromUrl(string url)
        {
            using (var onlineStream = _onlineCollector.CollectStreamFromUrl(url))
            {
                return File.Open(_cacheCollector.CacheFileFromStream(onlineStream, url), FileMode.Open);
            }
        }

        public Task<Stream> CollectStreamFromUrlAsync(string url)
        {
            return new Task<Stream>(() => CollectStreamFromUrl(url));
        }
    }
}
