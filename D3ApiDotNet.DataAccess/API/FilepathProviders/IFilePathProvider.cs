using System.Text;

namespace D3ApiDotNet.DataAccess.API.FilepathProviders
{
    /// <summary>
    /// interface for filepathproviders:
    /// map url to an unique filepath
    /// </summary>
    public interface IFilePathProvider
    {
        /// <summary>
        /// appends unique filepath from url to stringbuilder
        /// </summary>
        /// <param name="url"></param>
        string BuildFilePath(string url);
    }
}