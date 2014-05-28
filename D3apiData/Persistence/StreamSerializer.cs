using System.IO;

namespace D3apiData.Persistence
{
    /// <summary>
    /// Serializes streams
    /// </summary>
    public class StreamSerializer : ISerializer<Stream>
    {
        /// <inheritdoc/>
        public Stream Deserialize(string filepath)
        {
            if (File.Exists(filepath))
                return File.OpenRead(filepath);
            else
                throw new FileNotFoundException();
        }

        /// <inheritdoc/>
        public void Serialize(Stream obj, string filepath)
        {
            var directoryName = Path.GetDirectoryName(filepath);
            if (!string.IsNullOrWhiteSpace(directoryName))
                Directory.CreateDirectory(directoryName);
            using (var fileStream = File.Create(filepath, (int)obj.Length))
            {
                var bytesInStream = new byte[obj.Length];
                obj.Read(bytesInStream, 0, bytesInStream.Length);
                // Use write method to write to the file specified above
                fileStream.Write(bytesInStream, 0, bytesInStream.Length);
            }
        }
    }
}
