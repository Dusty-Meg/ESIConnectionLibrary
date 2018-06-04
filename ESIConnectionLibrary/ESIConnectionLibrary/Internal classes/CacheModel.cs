using System;

namespace ESIConnectionLibrary.Internal_classes
{
    internal class CacheModel
    {
        public CacheModel(string item, string etag, int cacheTime, int page)
        {
            Item = item;
            Etag = etag;
            Expires = DateTime.UtcNow.AddSeconds(cacheTime);
            Page = page;
        }

        public string Item { get; set; }
        public string Etag { get; set; }
        public DateTime Expires { get; set; }
        public int Page { get; set; }
    }
}