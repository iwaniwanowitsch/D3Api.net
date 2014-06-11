using System;
using System.IO;
using D3ApiDotNet.DataAccess.API;
using D3ApiDotNet.DataAccess.API.FilepathProviders;
using D3ApiDotNet.DataAccess.API.FilepathProviders.Factories;
using System.Net;

namespace D3ApiDotNet.DataAccess.Repositories.Factories
{
    public interface IRepositoryFactory
    {
        IReadonlyRepository<Stream, string> CreateReadRepository(IFilePathProvider filepathprovider, CollectMode mode, WebProxy proxy);
    }
}
