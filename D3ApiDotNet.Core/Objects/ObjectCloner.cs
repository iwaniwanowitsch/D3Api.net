using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace D3ApiDotNet.Core.Objects
{
    public class ObjectCloner
    {
        public T DeepCopy<T>(T obj) where T : IBaseObject
        {
            using (var stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, obj);
                stream.Position = 0;

                return (T)formatter.Deserialize(stream);
            }
        }
    }
}
