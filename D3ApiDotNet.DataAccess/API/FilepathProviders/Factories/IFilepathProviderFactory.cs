using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D3ApiDotNet.DataAccess.API.FilepathProviders.Factories
{
    public interface IFilePathProviderFactory
    {
        IFilePathProvider CreateFilePathProvider(string rootPath);
    }
}
