using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D3apiData.API.FilepathProviders.Factories
{
    public interface IFilePathProviderFactory
    {
        IFilePathProvider CreateFilePathProvider(string rootPath);
    }
}
