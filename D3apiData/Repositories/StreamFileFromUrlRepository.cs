using System;
using System.IO;
using D3apiData.API.FilepathProviders;

namespace D3apiData.Repositories
{
    public class StreamFileFromUrlRepository : StreamFileRepository
    {
        private readonly IFilePathProvider _filePathProvider;

        public StreamFileFromUrlRepository(IFilePathProvider filePathProvider)
        {
            if (filePathProvider == null) throw new ArgumentNullException("filePathProvider");
            _filePathProvider = filePathProvider;
        }

        public override Stream Retrieve(string url)
        {
            return base.Retrieve(_filePathProvider.BuildFilePath(url));
        }

        public override void Save(Stream entity, string url)
        {
            base.Save(entity, _filePathProvider.BuildFilePath(url));
        }
    }
}