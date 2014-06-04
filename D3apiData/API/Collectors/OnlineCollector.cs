using System;
using System.IO;
using System.Threading.Tasks;
using D3apiData.Persistence;

namespace D3apiData.API.Collectors
{
    class OnlineCollector : ID3Collector
    {
        private readonly ISerializer<Stream> _client;

        public OnlineCollector(ISerializer<Stream> client)
        {
            if (client == null)
                throw new ArgumentNullException("client");
            _client = client;
        }


        public Stream CollectStreamFromUrl(string url)
        {
            if(url == null)
                throw new ArgumentNullException("url");
            return _client.Deserialize(url);
        }

        public Task<Stream> CollectStreamFromUrlAsync(string url)
        {
            if (url == null)
                throw new ArgumentNullException("url");
            return Task.Factory.StartNew(() => _client.Deserialize(url));
        }
    }
}
