namespace D3ApiDotNet.DataAccess.API 
{
    /// <summary>
    /// collect modes for api data collection
    /// </summary>
    public enum CollectMode
    {
        /// <summary>
        /// from internet
        /// </summary>
        Online,
        /// <summary>
        /// from local cache
        /// </summary>
        Offline,
        /// <summary>
        /// try get from local cache, then from internet
        /// </summary>
        TryCacheThenOnline,
        /// <summary>
        /// from internet, but save to local cache
        /// </summary>
        OnlineWithCache
    };
}