using System;
using System.Text;

namespace D3apiData.API.FilepathProviders
{
    /// <summary>
    /// hero file path provider
    /// </summary>
    public class HeroFilePathProvider : BasicFilePathProviderChainMember
    {
        /// <summary />
        /// <param name="nextMember"></param>
        public HeroFilePathProvider(IFilePathProvider nextMember, string pathRoot) : base(nextMember, pathRoot) { base.Path = "/hero/"; }

        /// <summary />
        /// <param name="url"></param>
        protected override string DoBuildFilePath(string url)
        {
            var split = url.Split(new[] { Path }, StringSplitOptions.None);
            return @"hero\" + split[1].Replace("/", "\\") + ".json";
        }
    }
}