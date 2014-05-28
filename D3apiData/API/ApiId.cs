using System;

namespace D3apiData.API
{
    /// <summary>
    /// class to hold id data
    /// </summary>
    public class ApiId
    {
        /// <summary />
        /// <param name="id">id of param, can be battletag</param>
        /// <exception cref="ArgumentNullException"></exception>
        public ApiId(string id)
        {
            if (id == null) throw new ArgumentNullException("id");
            Id = id;
            Id2 = string.Empty;
        }

        /// <summary />
        /// <param name="id">battletag | icon type</param>
        /// <param name="id2">heroid | icon id</param>
        /// <exception cref="ArgumentNullException"></exception>
        public ApiId(string id, string id2)
        {
            if (id == null) throw new ArgumentNullException("id");
            if (id2 == null) throw new ArgumentNullException("id2");
            Id = id;
            Id2 = id2;
        }

        /// <summary>
        /// ID, can also be battletag or icon type
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// hero id oder icon id
        /// </summary>
        public string Id2 { get; set; }

        /// <summary>
        /// interpret id as battletag and format for url
        /// </summary>
        /// <returns></returns>
        public string GetFormattedBattletag()
        {
            return Id.Replace("#", "-");
        }
    }
}