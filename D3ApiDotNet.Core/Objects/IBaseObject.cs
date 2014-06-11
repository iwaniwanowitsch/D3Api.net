namespace D3ApiDotNet.Core.Objects
{
    /// <summary>
    /// D3ApiServiceExample: basic interface of all api objects
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
