using System;

namespace D3apiData.Persistence
{
    public class TryCacheRepositoryDecorator<TEntity, TKey> : IReadonlyRepository<TEntity, TKey> where TEntity : class
    {
        private IReadonlyRepository<TEntity, TKey> _readRepo;
        private IRepository<TEntity, TKey> _writeRepo;

        public TryCacheRepositoryDecorator(IReadonlyRepository<TEntity, TKey> readRepo, IRepository<TEntity, TKey> writeRepo)
        {
            if (readRepo == null) throw new ArgumentNullException("readRepo");
            if (writeRepo == null) throw new ArgumentNullException("writeRepo");
            _readRepo = readRepo;
            _writeRepo = writeRepo;
        }

        public TEntity Get(TKey key)
        {
            TEntity data;
            try
            {
                data = _writeRepo.Get(key);
            }
            catch (RepositoryEntityNotFoundException)
            {
                data = _readRepo.Get(key);
                _writeRepo.Save(data,key);
            }
            return data;
        }
    }
}