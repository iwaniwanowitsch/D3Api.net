using System.IO;
using System.Threading.Tasks;

namespace D3apiData.API
{
    /// <summary />
    public interface ID3Collector
    {
        /// <summary />
        /// <param name="url"></param>
        /// <returns></returns>
        Stream CollectStreamFromUrl(string url);

        /// <summary />
        /// <param name="url"></param>
        /// <returns></returns>
        Task<Stream> CollectStreamFromUrlAsync(string url);
    }
}
