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
        public ProfileFilePathProvider(IFilePathProvider nextMember) : base(nextMember) { base.Path = "/profile/"; }

        /// <summary />
        /// <param name="url"></param>
        /// <param name="builder"></param>
        protected override void DoAppendFilePathBuilder(string url, StringBuilder builder)
        {
            var split = url.Split(new[] { Path }, StringSplitOptions.None);
            builder.Append(@"profile\");
            builder.Append(split[1].Replace("/", ""));
            builder.Append(".json");
        }
    }
}