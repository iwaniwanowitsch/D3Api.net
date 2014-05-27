using System;
using System.IO;
using System.Xml.Serialization;

namespace D3apiData.Persistence
{
    /// <summary>
    /// serializes to xml format
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SerializerXML<T> : ISerializer<T> where T : class
    {
        /// <summary>
        /// empty constructor
        /// </summary>
        public SerializerXML()
        {

        }

        /// <inheritdoc/>
        public T Deserialize(string filepath)
        {
            T serialized = null;
            try
            {
                using (Stream stream = File.Open(filepath, FileMode.OpenOrCreate))
                {
                    if (stream.Length != 0) {
                        XmlSerializer ser = new XmlSerializer(typeof(T));
                        serialized = (T)ser.Deserialize(stream);
                    }
                }
            }
            catch (InvalidOperationException e)
            {
                throw e;
            }
            return serialized;
        }

        /// <inheritdoc/>
        public void Serialize(T obj, string filepath)
        {
            try
            {
                using (Stream stream = File.Open(filepath, FileMode.Create))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(T));
                    ser.Serialize(stream, obj);
                }
            }
            catch (InvalidOperationException e)
            {
                throw e;
            }
        }
    }
}
