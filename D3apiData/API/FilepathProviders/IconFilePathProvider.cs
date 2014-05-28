using System;
using System.Text;

namespace D3apiData.API.FilepathProviders
{
    /// <summary>
    /// icon file path provider
    /// </summary>
    public class IconFilePathProvider : BasicFilePathProviderChainMember
    {
        /// <summary />
        /// <param name="nextMember"></param>
        public IconFilePathProvider(IFilePathProvider nextMember) : base(nextMember) { base.Path = "/icons/"; }

        /// <summary />
        /// <param name="url"></param>
        /// <param name="builder"></param>
        protected override void DoAppendFilePathBuilder(string url, StringBuilder builder)
        {
            builder.Append(@"icons\");
            var split = url.Split(new[] { Path }, StringSplitOptions.None);
            builder.Append(split[1].Replace("/", "\\"));
        }
    }
}