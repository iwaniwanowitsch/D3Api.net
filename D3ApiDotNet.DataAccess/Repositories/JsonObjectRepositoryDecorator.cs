using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using D3ApiDotNet.Core.Objects;
using D3ApiDotNet.DataAccess.Helper;

namespace D3ApiDotNet.DataAccess.Repositories
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
