namespace D3apiData.API.Objects
{
    /// <summary>
    /// D3Api: basic interface of all api objects
    /// </summary>
    public interface IBaseObject
    {
        /// <summary>
        /// determines wheter an object contains error
        /// </summary>
        /// <returns></returns>
        bool IsErrorObject();
    }
}
