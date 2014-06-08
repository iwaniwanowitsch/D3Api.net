using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using D3apiData.API.Objects;
using D3apiData.JSON;

namespace D3apiData.Repositories
{
    public class JsonObjectRepositoryDecorator<TObject> : IReadonlyRepository<TObject,string> where TObject : class, IBaseObject
    {
        protected readonly IReadonlyRepository<Stream, string> _readRepo;

        public JsonObjectRepositoryDecorator(IReadonlyRepository<Stream,string> readRepo)
        {
            if (readRepo == null) throw new ArgumentNullException("readRepo");
            _readRepo = readRepo;
        }

        public virtual TObject Retrieve(string url)
        {
            using (var dataStream = _readRepo.Retrieve(url))
            {
                return JsonUtility.ObjectFromJsonPersistentStream<TObject>(dataStream);
            }
        }
    }
}
