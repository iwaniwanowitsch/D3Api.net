using System;
using System.Text;
using D3ApiDotNet.DataAccess.Helper;

namespace D3ApiDotNet.DataAccess.API.FilepathProviders
{
    /// <summary>
    /// item file path provider
    /// </summary>
    public class ItemFilePathProvider : BasicFilePathProviderChainMember
    {
        /// <summary />
        /// <param name="nextMember"></param>
        public ItemFilePathProvider(IFilePathProvider nextMember, string pathRoot) : base(nextMember, pathRoot) { base.Path = "/item/"; }

        /// <summary />
        /// <param name="url"></param>
        protected override string DoBuildFilePath(string url)
        {
            var split = url.Split(new[] { Path }, StringSplitOptions.None);
            return @"item\" + (split[1].Length <= 32 ? split[1] : MD5Helper.GetMd5Hash(split[1])) + ".json";
        }
    }
}