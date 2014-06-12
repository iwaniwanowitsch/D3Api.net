using System;
using System.IO;

namespace D3ApiDotNet.DataAccess.Repositories
{
    public class StreamDateTimeData
    {
        public byte[] Bytes { get; set; }
        public DateTime Time { get; set; }

        public StreamDateTimeData(byte[] bytes, DateTime time)
        {
            if (bytes == null) throw new ArgumentNullException("bytes");
            Bytes = bytes;
            Time = time;
        }
    }
}