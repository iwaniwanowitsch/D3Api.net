using System;
using System.IO;
using D3ApiDotNet.Core.Objects.Images;

namespace D3ApiDotNet.DataAccess.Repositories
{
    public class IconRepositoryDecorator : IReadonlyRepository<D3Icon, string>
    {
        protected readonly IReadonlyRepository<Stream, string> _readRepo;

        public IconRepositoryDecorator(IReadonlyRepository<Stream, string> readRepo)
        {
            if (readRepo == null) throw new ArgumentNullException("readRepo");
            _readRepo = readRepo;
        }

        public virtual D3Icon Retrieve(string url)
        {
            using(var dataStream = _readRepo.Retrieve(url))
                return new D3Icon(dataStream);
        }
    }
}