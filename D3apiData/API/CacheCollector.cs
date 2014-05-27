using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using D3apiData.API.Objects;
using D3apiData.JSON;
using D3apiData.Persistence;

namespace D3apiData.API
{
    class CacheCollector : ID3Collector
    {
        private readonly string _cachepath;
        private readonly ISerializer<Stream> _serializer;

        public CacheCollector(string cachepath)
        {
            if (cachepath == null)
                throw new ArgumentNullException("cachepath");
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

            if (url.Contains("/hero/"))
            {
                var split = url.Split(new[] { "/hero/" }, StringSplitOptions.None);
                stringBuilder.Append(@"hero\");
                stringBuilder.Append(split[1].Replace("/", "\\"));
                stringBuilder.Append(".json");
            }
            else if (url.Contains("/profile/"))
            {
                var split = url.Split(new[] { "/profile/" }, StringSplitOptions.None);
                stringBuilder.Append(@"profile\");
                stringBuilder.Append(split[1].Replace("/", ""));
                stringBuilder.Append(".json");
            }
            else if (url.Contains("/item/"))
            {
                var split = url.Split(new[] { "/item/" }, StringSplitOptions.None);
                stringBuilder.Append(@"item\");
                stringBuilder.Append(split[1].Length <= 32 ? split[1] : GetMd5Hash(split[1]));
                stringBuilder.Append(".json");
            }
            else if (url.Contains("/icons/"))
            {
                stringBuilder.Append(@"icons\");
                var split = url.Split(new[] { "/icons/" }, StringSplitOptions.None);
                stringBuilder.Append(split[1].Replace("/", "\\"));
            }
            else
            {
                stringBuilder.Append(GetMd5Hash(url));
                stringBuilder.Append(".json");
            }
            return stringBuilder.ToString();
        }

        public string GetMd5Hash(string textToHash)
        {
            if (textToHash == null) 
                throw new ArgumentNullException("textToHash");
            //Prüfen ob Daten übergeben wurden.
            if (string.IsNullOrEmpty(textToHash))
            {
                return string.Empty;
            }

            //MD5 Hash aus dem String berechnen. Dazu muss der string in ein Byte[]
            //zerlegt werden. Danach muss das Resultat wieder zurück in ein string.
            MD5 md5 = new MD5CryptoServiceProvider();
            var tToHash = Encoding.Default.GetBytes(textToHash);
            var result = md5.ComputeHash(tToHash);

            return BitConverter.ToString(result).Replace("-", "").ToLower();
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
                _serializer.Serialize(stream, filePath);
            }
            catch (Exception)
            {
                filePath = url;
            }
            if (!File.Exists(filePath))
                throw new FileNotFoundException();
            return filePath;
        }
    }
}
