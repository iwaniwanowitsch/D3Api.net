using System.Text;
using D3apiData.Helper;

namespace D3apiData.API.FilepathProviders
{
    /// <summary>
    /// default file path provider, end of chain of responsibility
    /// </summary>
    public class DefaultFilePathProvider : IFilePathProvider
    {
        /// <summary />
        /// <param name="url"></param>
        public string BuildFilePath(string url)
        {
            return MD5Helper.GetMd5Hash(url) + ".json";
        }
    }
}