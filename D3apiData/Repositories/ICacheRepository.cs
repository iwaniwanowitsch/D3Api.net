using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D3apiData.Repositories
{
    public interface ICacheRepository<TEntity, in TKey> : IRepository<TEntity,TKey> where TEntity : class
    {
        bool IsValid(TKey key);
    }
}
