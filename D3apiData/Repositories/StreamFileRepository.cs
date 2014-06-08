using System.IO;

namespace D3apiData.Repositories
{
    public class StreamFileRepository : IRepository<Stream, string>
    {
        public virtual Stream Retrieve(string filepath)
        {
            if (File.Exists(filepath))
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
    }
}