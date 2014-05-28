using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using D3apiData.API.FilepathProviders;
using D3apiData.API.Objects;
using D3apiData.JSON;
using D3apiData.Persistence;

namespace D3apiData.API
{
    class CacheCollector : ID3Collector
    {
        private readonly string _cachepath;
        private readonly ISerializer<Stream> _serializer;
        private readonly IFilePathProvider _filePathProvider;

        public CacheCollector(string cachepath, IFilePathProvider filePathProvider)
        {
            if (cachepath == null)
                throw new ArgumentNullException("cachepath");
            if (filePathProvider == null)
                throw new ArgumentNullException("filePathProvider");
            _filePathProvider = filePathProvider;
            _cachepath = cachepath;
            _serializer = new StreamSerializer();
        }

        public string GetFilepathFromUrl(string url)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(_cachepath);
            try
            {
                var uri = new Uri(url);
                stringBuilder.Append(uri.Host);
            }
            catch (UriFormatException)
            {
                // couldnt convert url to uri. no host.
            }
            _filePathProvider.AppendFilePathBuilder(url, stringBuilder);
            return stringBuilder.ToString();
        }

        

        public Stream CollectStreamFromUrl(string url)
        {
            var filePath = GetFilepathFromUrl(url);
            try
            {
                return _serializer.Deserialize(filePath);
            }
            catch (FileNotFoundException)
            {
                return null;
            }
        }

        public Task<Stream> CollectStreamFromUrlAsync(string url)
        {
            return new Task<Stream>(() => CollectStreamFromUrl(url));
        }

        public string CacheFileFromStream(Stream stream, string url)
        {
            string filePath;
            try
            {
                filePath = GetFilepathFromUrl(JsonUtility.ObjectFromJsonPersistentStream<ErrorObject>(stream).IsErrorObject() ? ErrorObject.FileName : url);
            }
            catch (Exception)
            {
                filePath = GetFilepathFromUrl(url);
            }
            stream.Position = 0;
            _serializer.Serialize(stream, filePath);
            if (!File.Exists(filePath))
                throw new FileNotFoundException();
            return filePath;
        }
    }
}
