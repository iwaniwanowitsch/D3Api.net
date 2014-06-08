using System;
using System.Text;

namespace D3apiData.API.FilepathProviders
{
    /// <summary>
    /// profile file path provider
    /// </summary>
    public class ProfileFilePathProvider : BasicFilePathProviderChainMember
    {
        /// <summary />
        /// <param name="nextMember"></param>
        public ProfileFilePathProvider(IFilePathProvider nextMember, string pathRoot) : base(nextMember, pathRoot) { base.Path = "/profile/"; }

        /// <summary />
        /// <param name="url"></param>
        protected override string DoBuildFilePath(string url)
        {
            var split = url.Split(new[] { Path }, StringSplitOptions.None);
            return @"profile\" + split[1].Replace("/", "") + ".json";
        }
    }
}