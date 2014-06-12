using System;
using System.Collections.Generic;
using System.IO;
using D3ApiDotNet.DataAccess.Helper;

namespace D3ApiDotNet.DataAccess.Repositories
{
    public class StreamCacheMemoryRepository : ICacheRepository<Stream,string>
    {
        private readonly TimeSpan _cacheDuration;
        private Dictionary<string,StreamDateTimeData> _cacheData = new Dictionary<string, StreamDateTimeData>(); 

        public StreamCacheMemoryRepository(TimeSpan cacheDuration)
        {
            _cacheDuration = cacheDuration;
        }

        public Stream Retrieve(string key)
        {
            if (!IsValid(key)) throw new RepositoryEntityNotFoundException();
            return new MemoryStream(_cacheData[key].Bytes);
        }

        public void Save(Stream entity, string key)
        {
            _cacheData.Add(key, new StreamDateTimeData(entity.ReadFully(), DateTime.Now));
            entity.Position = 0;
        }

        public void Delete(string key)
        {
            _cacheData.Remove(key);
        }

        public bool IsValid(string key)
        {
            if (_cacheData.ContainsKey(key) && (DateTime.Now - _cacheData[key].Time) < _cacheDuration)
                return true;
            if(_cacheData.ContainsKey(key))
                Delete(key);
            return false;
        }
    }
}