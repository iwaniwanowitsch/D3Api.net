using System;
using System.Text;

namespace D3apiData.API.FilepathProviders
{
    /// <summary>
    /// chain of responsibility design pattern base class
    /// </summary>
    public abstract class BasicFilePathProviderChainMember : IFilePathProvider
    {
        /// <summary />
        protected string Path = string.Empty;

        private readonly IFilePathProvider _nextMember;

        /// <summary />
        /// <param name="nextMember"></param>
        /// <exception cref="ArgumentNullException"></exception>
        protected BasicFilePathProviderChainMember(IFilePathProvider nextMember)
        {
            if (nextMember == null) throw new ArgumentNullException("nextMember");
            _nextMember = nextMember;
        }

        /// <summary />
        /// <param name="url"></param>
        /// <param name="builder"></param>
        public virtual void AppendFilePathBuilder(string url, StringBuilder builder)
        {
            if (!CanAppendFilePathBuilder(url))
            {
                _nextMember.AppendFilePathBuilder(url, builder);
                return;
            }
            DoAppendFilePathBuilder(url, builder);
        }

        /// <summary />
        /// <param name="url"></param>
        /// <returns></returns>
        protected virtual bool CanAppendFilePathBuilder(string url){
            return url.Contains(Path);
        }

        /// <summary />
        /// <param name="url"></param>
        /// <param name="builder"></param>
        protected abstract void DoAppendFilePathBuilder(string url, StringBuilder builder);
    }
}