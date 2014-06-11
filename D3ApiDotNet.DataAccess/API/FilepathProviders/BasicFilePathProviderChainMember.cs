using System;
using System.Text;

namespace D3ApiDotNet.DataAccess.API.FilepathProviders
{
    /// <summary>
    /// chain of responsibility design pattern base class
    /// </summary>
    public abstract class BasicFilePathProviderChainMember : IFilePathProvider
    {
        /// <summary />
        protected string Path = string.Empty;

        private readonly IFilePathProvider _nextMember;
        private readonly string _pathRoot;

        /// <summary />
        /// <param name="nextMember"></param>
        /// <param name="pathRoot"></param>
        /// <exception cref="ArgumentNullException"></exception>
        protected BasicFilePathProviderChainMember(IFilePathProvider nextMember, string pathRoot)
        {
            if (nextMember == null) throw new ArgumentNullException("nextMember");
            if (pathRoot == null) throw new ArgumentNullException("pathRoot");
            _nextMember = nextMember;
            _pathRoot = pathRoot;
        }

        /// <summary />
        /// <param name="url"></param>
        public virtual string BuildFilePath(string url)
        {
            if (!CanBuildFilePath(url))
            {
                return _nextMember.BuildFilePath(url);
            }
            var filepath = _pathRoot;
            try
            {
                var uri = new Uri(url);
                filepath += uri.Host;
            }
            catch (UriFormatException)
            {
                // couldnt convert url to uri. no host.
            }
            return filepath + DoBuildFilePath(url);
        }

        /// <summary />
        /// <param name="url"></param>
        /// <returns></returns>
        protected virtual bool CanBuildFilePath(string url){
            return url.Contains(Path);
        }

        /// <summary />
        /// <param name="url"></param>
        protected abstract string DoBuildFilePath(string url);
    }
}