namespace D3apiData.Repositories
{
    public interface IRepository<TEntity, in TKey> : IReadonlyRepository<TEntity, TKey> where TEntity : class
    {
        void Save(TEntity entity, TKey key);

        void Delete(TKey key);
    }
}