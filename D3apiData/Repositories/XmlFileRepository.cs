using System;
using System.IO;
using System.Xml.Serialization;

namespace D3apiData.Repositories
{
    public class XmlFileRepository<T> : IRepository<T, string> where T : class
    {
        public T Retrieve(string filepath)
        {
            T serialized = null;
            try
            {
                using (Stream stream = File.Open(filepath, FileMode.OpenOrCreate))
                {
                    if (stream.Length != 0)
                    {
                        var ser = new XmlSerializer(typeof(T));
                        serialized = (T)ser.Deserialize(stream);
                    }
                }
            }
            catch (InvalidOperationException e)
            {
                throw new RepositoryEntityNotFoundException();
            }
            return serialized;
        }

        public void Save(T entity, string filepath)
        {
            try
            {
                using (Stream stream = File.Open(filepath, FileMode.Create))
                {
                    var ser = new XmlSerializer(typeof(T));
                    ser.Serialize(stream, entity);
                }
            }
            catch (InvalidOperationException e)
            {
                throw e;
            }
        }
    }
}