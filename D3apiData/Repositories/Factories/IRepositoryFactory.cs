using System;
using System.IO;
using D3apiData.API;
using D3apiData.API.FilepathProviders;
using D3apiData.API.FilepathProviders.Factories;
using D3apiData.API.Objects;
using System.Net;

namespace D3apiData.Repositories.Factories
{
    public interface IRepositoryFactory
    {
        IReadonlyRepository<Stream, string> CreateReadRepository(IFilePathProvider filepathprovider, CollectMode mode, WebProxy proxy);
    }
}
