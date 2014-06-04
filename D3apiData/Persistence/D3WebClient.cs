using D3apiData.Persistence;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace D3apiData.Persistence
{
    /// <summary>
    /// class to capsule http access
    /// </summary>
    public class D3WebClient : ISerializer<Stream>
    {

        /// <summary>
        /// provide some basic methods to get data from http
        /// </summary>
        public D3WebClient()
        {
        }

        /// <summary>
        /// saves data from url in file via httprequest
        /// </summary>
        /// <param name="url"></param>
        /// <param name="filepath"></param>
        public void SaveIconSync(string url, string filepath)
        {
            // Construct HTTP request to get the logo
            var httpRequest = (HttpWebRequest)WebRequest.Create(checkURL(url));
            httpRequest.Method = WebRequestMethods.Http.Get;
            // Get back the HTTP response for web server
            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var httpResponseStream = httpResponse.GetResponseStream())
            {
                // Define buffer and buffer size
                var bufferSize = 1024;
                var buffer = new byte[bufferSize];
                var bytesRead = 0;

                // Read from response and write to file
                using (var fileStream = File.Create(filepath))
                {
                    while ((bytesRead = httpResponseStream.Read(buffer, 0, bufferSize)) != 0)
                    {
                        fileStream.Write(buffer, 0, bytesRead);
                    }
                }
            }
        }

        /// <summary>
        /// async <see cref="SaveIconSync"/>
        /// </summary>
        /// <param name="url"></param>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public Task SaveIconAsync(string url, string filepath)
        {
            return new Task(() => SaveIconSync(url, filepath));
        }

        /// <summary>
        /// checks url for validity (only formal)
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private Uri checkURL(string url) {
            if (!url.StartsWith("http://") && !url.StartsWith("https://"))
                url = "http://" + url;
            Uri result;
            if (Uri.TryCreate(url, UriKind.Absolute, out result) && result.Scheme == Uri.UriSchemeHttp)
                return result;
            else
                throw new ArgumentException("not a valid url");
        }

        /// <summary>
        /// gets stream from url via httprequest
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public Stream Deserialize(string url)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(checkURL(url));
            httpWebRequest.Credentials = CredentialCache.DefaultCredentials;
            //httpWebRequest.Proxy = new WebProxy("127.0.0.1:3128");
            var httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            if (httpWebResponse.StatusCode != HttpStatusCode.OK)
                throw new HttpListenerException();
            using (var responseStream = httpWebResponse.GetResponseStream())
            {
                var memStream = new MemoryStream();
                if (responseStream != null) responseStream.CopyTo(memStream);
                memStream.Position = 0;
                return memStream;
            }
        }

        /// <summary>
        /// not supported, one way serialization
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="url"></param>
        public void Serialize(Stream obj, string url)
        {
            throw new NotSupportedException();
        }
    }
}
