using System;
using System.Text;

namespace D3ApiDotNet.DataAccess.API.FilepathProviders
{
    /// <summary>
    /// icon file path provider
    /// </summary>
    public class IconFilePathProvider : BasicFilePathProviderChainMember
    {
        /// <summary />
        /// <param name="nextMember"></param>
        public IconFilePathProvider(IFilePathProvider nextMember,string pathRoot) : base(nextMember,pathRoot) { base.Path = "/icons/"; }

        /// <summary />
        /// <param name="url"></param>
        protected override string DoBuildFilePath(string url)
        {
            var split = url.Split(new[] { Path }, StringSplitOptions.None);
            return @"icons\" + split[1].Replace("/", "\\");
        }
    }
}