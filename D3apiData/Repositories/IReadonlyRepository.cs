using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D3apiData.Repositories
{
    public interface IReadonlyRepository<TEntity, in TKey> where TEntity : class
    {
        TEntity Retrieve(TKey key);
    }
}
