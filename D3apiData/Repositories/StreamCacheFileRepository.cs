using System;
using System.IO;

namespace D3apiData.Repositories
{
    public class StreamCacheFileRepository : ICacheRepository<Stream, string>
    {
        private readonly TimeSpan _cacheDuration;

        public StreamCacheFileRepository(TimeSpan cacheDuration)
        {
            _cacheDuration = cacheDuration;
        }

        public virtual Stream Retrieve(string filepath)
        {
            if (IsValid(filepath))
                return File.OpenRead(filepath);
            else
                throw new RepositoryEntityNotFoundException();
        }

        public virtual void Save(Stream entity, string filepath)
        {
            var directoryName = Path.GetDirectoryName(filepath);
            if (!string.IsNullOrWhiteSpace(directoryName))
                Directory.CreateDirectory(directoryName);
            using (var fileStream = File.Create(filepath, (int)entity.Length))
            {
                var bytesInStream = new byte[entity.Length];
                entity.Read(bytesInStream, 0, bytesInStream.Length);
                entity.Position = 0;
                // Use write method to write to the file specified above
                fileStream.Write(bytesInStream, 0, bytesInStream.Length);
            }
        }

        public virtual void Delete(string filepath)
        {
            if (File.Exists(filepath))
                File.Delete(filepath);
        }

        public virtual bool IsValid(string filepath)
        {
            if (File.Exists(filepath) && (DateTime.Now - File.GetCreationTime(filepath)) < _cacheDuration)
                return true;
            if(File.Exists(filepath))
                Delete(filepath);
            return false;
        }
    }
}