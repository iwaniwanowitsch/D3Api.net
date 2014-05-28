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
        public HeroFilePathProvider(IFilePathProvider nextMember) : base(nextMember) { base.Path = "/hero/"; }

        /// <summary />
        /// <param name="url"></param>
        /// <param name="builder"></param>
        protected override void DoAppendFilePathBuilder(string url, StringBuilder builder)
        {
            var split = url.Split(new[] { Path }, StringSplitOptions.None);
            builder.Append(@"hero\");
            builder.Append(split[1].Replace("/", "\\"));
            builder.Append(".json");
        }
    }
}