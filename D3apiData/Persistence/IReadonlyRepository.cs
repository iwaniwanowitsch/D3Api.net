using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D3apiData.Persistence
{
    public interface IReadonlyRepository<TEntity, in TKey> where TEntity : class
    {
        TEntity Get(TKey key);
    }
}
