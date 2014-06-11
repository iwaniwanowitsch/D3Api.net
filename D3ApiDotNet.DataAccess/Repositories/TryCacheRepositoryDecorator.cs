using System;

namespace D3ApiDotNet.DataAccess.Repositories
{
    public class TryCacheRepositoryDecorator<TEntity, TKey> : IReadonlyRepository<TEntity, TKey> where TEntity : class
    {
        private IReadonlyRepository<TEntity, TKey> _readRepo;
        private ICacheRepository<TEntity, TKey> _writeRepo;

        public TryCacheRepositoryDecorator(IReadonlyRepository<TEntity, TKey> readRepo, ICacheRepository<TEntity, TKey> writeRepo)
        {
            if (readRepo == null) throw new ArgumentNullException("readRepo");
            if (writeRepo == null) throw new ArgumentNullException("writeRepo");
            _readRepo = readRepo;
            _writeRepo = writeRepo;
        }

        public TEntity Retrieve(TKey key)
        {
            TEntity data;
            try
            {
                data = _writeRepo.Retrieve(key);
            }
            catch (RepositoryEntityNotFoundException)
            {
                data = _readRepo.Retrieve(key);
                _writeRepo.Save(data,key);
            }
            return data;
        }
    }
}