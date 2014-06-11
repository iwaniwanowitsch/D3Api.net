using System.IO;
using Newtonsoft.Json;

namespace D3apiData.Helper
{
    public static class JsonUtility
    {
        public static T ObjectFromJsonStream<T>(Stream stream) where T : class
        {
            
            T data;
            using (var streamReader = new StreamReader(stream))
            {
                var serializer = new JsonSerializer {TypeNameHandling = TypeNameHandling.Auto};
                data = (T)serializer.Deserialize(streamReader, typeof(T));
            }
            return data;
        }

        public static T ObjectFromJsonPersistentStream<T>(Stream stream) where T : class
        {
            var streamReader = new StreamReader(stream);
            var serializer = new JsonSerializer { TypeNameHandling = TypeNameHandling.Auto };
            var data = (T)serializer.Deserialize(streamReader, typeof(T));
            stream.Position = 0;
            return data;
        }
    }
}
