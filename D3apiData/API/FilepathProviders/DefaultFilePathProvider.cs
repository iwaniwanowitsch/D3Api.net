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
        /// <param name="builder"></param>
        public void AppendFilePathBuilder(string url, StringBuilder builder)
        {
            builder.Append(MD5Helper.GetMd5Hash(url));
            builder.Append(".json");
        }
    }
}