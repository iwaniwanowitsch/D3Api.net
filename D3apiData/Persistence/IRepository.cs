namespace D3apiData.Persistence
{
    public interface IRepository<TEntity, in TKey> : IReadonlyRepository<TEntity, TKey> where TEntity : class
    {
        void Save(TEntity entity, TKey key);
    }
}