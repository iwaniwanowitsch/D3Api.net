using System;
using System.Text;
using D3apiData.Helper;

namespace D3apiData.API.FilepathProviders
{
    /// <summary>
    /// item file path provider
    /// </summary>
    public class ItemFilePathProvider : BasicFilePathProviderChainMember
    {
        /// <summary />
        /// <param name="nextMember"></param>
        public ItemFilePathProvider(IFilePathProvider nextMember) : base(nextMember) { base.Path = "/item/"; }

        /// <summary />
        /// <param name="url"></param>
        /// <param name="builder"></param>
        protected override void DoAppendFilePathBuilder(string url, StringBuilder builder)
        {
            var split = url.Split(new[] { Path }, StringSplitOptions.None);
            builder.Append(@"item\");
            builder.Append(split[1].Length <= 32 ? split[1] : MD5Helper.GetMd5Hash(split[1]));
            builder.Append(".json");
        }
    }
}