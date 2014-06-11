using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D3apiData.API.FilepathProviders.Factories
{
    public class FilePathProviderChainFactory : IFilePathProviderFactory
    {
        public IFilePathProvider CreateFilePathProvider(string rootPath)
        {
            // chain in reversed order
            var defaultFilePathProvider = new DefaultFilePathProvider(); // end of chain
            var iconFilePathProvider = new IconFilePathProvider(defaultFilePathProvider, rootPath);
            var itemFilePathProvider = new ItemFilePathProvider(iconFilePathProvider, rootPath);
            var profileFilePathProvider = new ProfileFilePathProvider(itemFilePathProvider, rootPath);
            return new HeroFilePathProvider(profileFilePathProvider, rootPath); // begin of chain
        }
    }
}
