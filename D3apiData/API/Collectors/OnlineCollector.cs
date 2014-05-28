using System;
using System.IO;
using System.Threading.Tasks;
using D3apiData.WebClient;

namespace D3apiData.API.Collectors
{
    class OnlineCollector : ID3Collector
    {
        private readonly D3WebClient _client;

        public OnlineCollector(D3WebClient client)
        {
            if (client == null)
                throw new ArgumentNullException("client");
            _client = client;
        }


        public Stream CollectStreamFromUrl(string url)
        {
            if(url == null)
                throw new ArgumentNullException("url");
            return _client.GetStreamSync(url);
        }

        public Task<Stream> CollectStreamFromUrlAsync(string url)
        {
            if (url == null)
                throw new ArgumentNullException("url");
            return _client.GetStreamAsync(url);
        }
    }
}
