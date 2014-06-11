using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D3ApiDotNet.DataAccess.Helper
{
    public static class UrlHelper
    {
        /// <summary>
        /// checks url for validity (only formal)
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static Uri CheckUrl(this string url)
        {
            if (!url.StartsWith("http://") && !url.StartsWith("https://"))
                url = "http://" + url;
            Uri result;
            if (Uri.TryCreate(url, UriKind.Absolute, out result) && result.Scheme == Uri.UriSchemeHttp)
                return result;
            else
                throw new ArgumentException("not a valid url");
        }
    }
}
