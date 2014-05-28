using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using D3apiData.API.Objects;
using D3apiData.JSON;
using D3apiData.Persistence;
using D3apiData.Helper;

namespace D3apiData.API
{
    public interface IFilePathProvider
    {
        void AppendFilePathBuilder(string url, StringBuilder builder);
    }

    public abstract class BasicFilePathProviderChainMember : IFilePathProvider
    {
        protected string Path = string.Empty;

        private IFilePathProvider _nextMember;

        public BasicFilePathProviderChainMember(IFilePathProvider nextMember)
        {
            if (nextMember == null) throw new ArgumentNullException("nextMember");
            _nextMember = nextMember;
        }

        public virtual void AppendFilePathBuilder(string url, StringBuilder builder)
        {
            if (!CanAppendFilePathBuilder(url))
            {
                _nextMember.AppendFilePathBuilder(url, builder);
                return;
            }
            DoAppendFilePathBuilder(url, builder);
        }

        protected virtual bool CanAppendFilePathBuilder(string url){
            return url.Contains(Path);
        }

        protected abstract void DoAppendFilePathBuilder(string url, StringBuilder builder);
    }

    public class HeroFilePathProvider : BasicFilePathProviderChainMember
    {
        public HeroFilePathProvider(IFilePathProvider nextMember) : base(nextMember) { base.Path = "/hero/"; }

        protected override void DoAppendFilePathBuilder(string url, StringBuilder builder)
        {
            var split = url.Split(new[] { Path }, StringSplitOptions.None);
            builder.Append(@"hero\");
            builder.Append(split[1].Replace("/", "\\"));
            builder.Append(".json");
        }
    }

    public class ProfileFilePathProvider : BasicFilePathProviderChainMember
    {
        public ProfileFilePathProvider(IFilePathProvider nextMember) : base(nextMember) { base.Path = "/profile/"; }

        protected override void DoAppendFilePathBuilder(string url, StringBuilder builder)
        {
            var split = url.Split(new[] { Path }, StringSplitOptions.None);
            builder.Append(@"profile\");
            builder.Append(split[1].Replace("/", ""));
            builder.Append(".json");
        }
    }

    public class ItemFilePathProvider : BasicFilePathProviderChainMember
    {
        public ItemFilePathProvider(IFilePathProvider nextMember) : base(nextMember) { base.Path = "/item/"; }

        protected override void DoAppendFilePathBuilder(string url, StringBuilder builder)
        {
            var split = url.Split(new[] { Path }, StringSplitOptions.None);
            builder.Append(@"item\");
            builder.Append(split[1].Length <= 32 ? split[1] : MD5Helper.GetMd5Hash(split[1]));
            builder.Append(".json");
        }
    }

    public class IconFilePathProvider : BasicFilePathProviderChainMember
    {
        public IconFilePathProvider(IFilePathProvider nextMember) : base(nextMember) { base.Path = "/icons/"; }

        protected override void DoAppendFilePathBuilder(string url, StringBuilder builder)
        {
            builder.Append(@"icons\");
            var split = url.Split(new[] { Path }, StringSplitOptions.None);
            builder.Append(split[1].Replace("/", "\\"));
        }
    }

    public class DefaultFilePathProvider : IFilePathProvider
    {
        public void AppendFilePathBuilder(string url, StringBuilder builder)
        {
            builder.Append(MD5Helper.GetMd5Hash(url));
            builder.Append(".json");
        }
    }


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
