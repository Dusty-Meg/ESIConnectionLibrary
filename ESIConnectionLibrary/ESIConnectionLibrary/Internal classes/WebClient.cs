using System;
using System.Net;
using System.Net.Cache;
using ESIConnectionLibrary.Exceptions;
using LazyCache;

namespace ESIConnectionLibrary.Internal_classes
{
    internal class WebClient : IWebClient
    {
        private IAppCache Cache { get; }

        public WebClient()
        {
            Cache = new CachingService();
        }

        public string Post(WebHeaderCollection headers, string address, string data, int cacheSeconds = 0)
        {
            System.Net.WebClient client = new System.Net.WebClient
            {
                Headers = headers,
                CachePolicy = new HttpRequestCachePolicy()
            };

            client.Headers["UserAgent"] = "Dusty Meg";

            try
            {
                return Cache.GetOrAdd($"{address}{data}", () => client.UploadString(address, data), DateTimeOffset.UtcNow.AddSeconds(cacheSeconds));
            }
            catch (WebException e)
            {
                HttpWebResponse webResponse = e.Response as HttpWebResponse;

                switch (webResponse?.StatusCode)
                {
                    case HttpStatusCode.Forbidden:
                    case HttpStatusCode.InternalServerError:
                        throw new ESIException(e.Message, e);
                }

                throw;
            }
        }

        public string Get(WebHeaderCollection headers, string address, int cacheSeconds = 0)
        {
            System.Net.WebClient client = new System.Net.WebClient
            {
                Headers = headers
            };

            client.Headers["UserAgent"] = "Dusty Meg";

            try
            {
                return Cache.GetOrAdd(address, () => client.DownloadString(address), DateTimeOffset.UtcNow.AddSeconds(cacheSeconds));
            }
            catch (WebException e)
            {
                HttpWebResponse webResponse = e.Response as HttpWebResponse;

                switch (webResponse?.StatusCode)
                {
                    case HttpStatusCode.Forbidden:
                    case HttpStatusCode.InternalServerError:
                        throw new ESIException(e.Message, e);
                }

                throw;
            }
        }

        public string Get(string address, int cacheSeconds = 0)
        {
            System.Net.WebClient client = new System.Net.WebClient
            {
                Headers = { ["UserAgent"] = "Dusty Meg" }
            };

            try
            {
                return Cache.GetOrAdd(address, () => client.DownloadString(address), DateTimeOffset.UtcNow.AddSeconds(cacheSeconds));
            }
            catch (WebException e)
            {
                HttpWebResponse webResponse = e.Response as HttpWebResponse;

                switch (webResponse?.StatusCode)
                {
                    case HttpStatusCode.Forbidden:
                    case HttpStatusCode.InternalServerError:
                        throw new ESIException(e.Message, e);
                }

                throw;
            } 
        }
    }
}
