using System.IO;
using System.Threading.Tasks;

namespace D3apiData.API
{
    public interface ID3Collector
    {
        Stream CollectStreamFromUrl(string url);

        Task<Stream> CollectStreamFromUrlAsync(string url);
    }
}
