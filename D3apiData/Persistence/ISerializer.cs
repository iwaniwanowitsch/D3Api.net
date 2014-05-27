namespace D3apiData.Persistence
{
    /// <summary>
    /// interface for local persistent classes
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISerializer<T>
     where T : class
    {
        /// <summary>
        /// deserializes T from filepath
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        T Deserialize(string filepath);

        /// <summary>
        /// serializes T obj to filepath
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="filepath"></param>
        void Serialize(T obj, string filepath);
    }
}
