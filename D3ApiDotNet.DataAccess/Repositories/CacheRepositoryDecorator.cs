using System;

namespace D3ApiDotNet.DataAccess.Repositories
{
    public class CacheRepositoryDecorator<TEntity, TKey> : IReadonlyRepository<TEntity, TKey> where TEntity : class
    {
        private IReadonlyRepository<TEntity, TKey> _readRepo;
        private IRepository<TEntity, TKey> _writeRepo;

        public CacheRepositoryDecorator(IReadonlyRepository<TEntity, TKey> readRepo, IRepository<TEntity, TKey> writeRepo)
        {
            if (readRepo == null) throw new ArgumentNullException("readRepo");
            if (writeRepo == null) throw new ArgumentNullException("writeRepo");
            _readRepo = readRepo;
            _writeRepo = writeRepo;
        }

        public TEntity Retrieve(TKey key)
        {
            TEntity data = _readRepo.Retrieve(key);
            _writeRepo.Save(data, key);
            return data;
        }
    }
}