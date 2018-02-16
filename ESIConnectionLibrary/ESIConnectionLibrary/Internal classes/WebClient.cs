using System;
using System.Net;
using System.Net.Cache;
using System.Threading.Tasks;
using ESIConnectionLibrary.Exceptions;
using LazyCache;

namespace ESIConnectionLibrary.Internal_classes
{
    internal class WebClient : IWebClient
    {
        private readonly IAppCache _cache;
        private readonly string _userAgent;


        public WebClient(string userAgent)
        {
            _cache = new CachingService();
            _userAgent = userAgent;
        }

        public string Post(WebHeaderCollection headers, string address, string data, int cacheSeconds = 0)
        {
            System.Net.WebClient client = new System.Net.WebClient
            {
                Headers = headers,
                CachePolicy = new HttpRequestCachePolicy()
            };

            client.Headers["UserAgent"] = _userAgent;

            try
            {
                return _cache.GetOrAdd($"{address}{data}", () => client.UploadString(address, data), DateTimeOffset.UtcNow.AddSeconds(cacheSeconds));
            }
            catch (WebException e)
            {
                HttpWebResponse webResponse = e.Response as HttpWebResponse;

                switch (webResponse?.StatusCode)
                {
                    case HttpStatusCode.Forbidden:
                    case HttpStatusCode.InternalServerError:
                    case HttpStatusCode.NotFound:
                        throw new ESIException($"{e.Message} Url: {address}", e);
                }

                throw;
            }
        }

        public async Task<string> PostAsync(WebHeaderCollection headers, string address, string data, int cacheSeconds = 0)
        {
            System.Net.WebClient client = new System.Net.WebClient
            {
                Headers = headers,
                CachePolicy = new HttpRequestCachePolicy()
            };

            client.Headers["UserAgent"] = _userAgent;

            Uri url = new Uri(address);

            try
            {
                return await _cache.GetOrAddAsync($"{address}{data}",async () => await client.UploadStringTaskAsync(url, data), DateTimeOffset.UtcNow.AddSeconds(cacheSeconds));
            }
            catch (WebException e)
            {
                HttpWebResponse webResponse = e.Response as HttpWebResponse;

                switch (webResponse?.StatusCode)
                {
                    case HttpStatusCode.Forbidden:
                    case HttpStatusCode.InternalServerError:
                    case HttpStatusCode.NotFound:
                        throw new ESIException($"{e.Message} Url: {address}", e);
                }

                throw;
            }
        }

        public string Put(WebHeaderCollection headers, string address, string data, int cacheSeconds = 0)
        {
            System.Net.WebClient client = new System.Net.WebClient
            {
                Headers = headers,
                CachePolicy = new HttpRequestCachePolicy()
            };

            client.Headers["UserAgent"] = _userAgent;

            try
            {
                return _cache.GetOrAdd($"{address}{data}", () => client.UploadString(address, "PUT", data), DateTimeOffset.UtcNow.AddSeconds(cacheSeconds));
            }
            catch (WebException e)
            {
                HttpWebResponse webResponse = e.Response as HttpWebResponse;

                switch (webResponse?.StatusCode)
                {
                    case HttpStatusCode.Forbidden:
                    case HttpStatusCode.InternalServerError:
                    case HttpStatusCode.NotFound:
                        throw new ESIException($"{e.Message} Url: {address}", e);
                }

                throw;
            }
        }

        public async Task<string> PutAsync(WebHeaderCollection headers, string address, string data, int cacheSeconds = 0)
        {
            System.Net.WebClient client = new System.Net.WebClient
            {
                Headers = headers,
                CachePolicy = new HttpRequestCachePolicy()
            };

            client.Headers["UserAgent"] = _userAgent;

            try
            {
                return await _cache.GetOrAddAsync($"{address}{data}", async () => await client.UploadStringTaskAsync(address, "PUT", data), DateTimeOffset.UtcNow.AddSeconds(cacheSeconds));
            }
            catch (WebException e)
            {
                HttpWebResponse webResponse = e.Response as HttpWebResponse;

                switch (webResponse?.StatusCode)
                {
                    case HttpStatusCode.Forbidden:
                    case HttpStatusCode.InternalServerError:
                    case HttpStatusCode.NotFound:
                        throw new ESIException($"{e.Message} Url: {address}", e);
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

            client.Headers["UserAgent"] = _userAgent;

            try
            {
                return _cache.GetOrAdd(address, () => client.DownloadString(address), DateTimeOffset.UtcNow.AddSeconds(cacheSeconds));
            }
            catch (WebException e)
            {
                HttpWebResponse webResponse = e.Response as HttpWebResponse;

                switch (webResponse?.StatusCode)
                {
                    case HttpStatusCode.Forbidden:
                    case HttpStatusCode.InternalServerError:
                    case HttpStatusCode.NotFound:
                        throw new ESIException($"{e.Message} Url: {address}", e);
                }

                throw;
            }
        }

        public async Task<string> GetAsync(WebHeaderCollection headers, string address, int cacheSeconds = 0)
        {
            System.Net.WebClient client = new System.Net.WebClient
            {
                Headers = headers
            };

            client.Headers["UserAgent"] = _userAgent;

            try
            {
                return await _cache.GetOrAddAsync(address, async () => await client.DownloadStringTaskAsync(address), DateTimeOffset.UtcNow.AddSeconds(cacheSeconds));
            }
            catch (WebException e)
            {
                HttpWebResponse webResponse = e.Response as HttpWebResponse;

                switch (webResponse?.StatusCode)
                {
                    case HttpStatusCode.Forbidden:
                    case HttpStatusCode.InternalServerError:
                    case HttpStatusCode.NotFound:
                        throw new ESIException($"{e.Message} Url: {address}", e);
                }

                throw;
            }
        }

        public string Get(string address, int cacheSeconds = 0)
        {
            System.Net.WebClient client = new System.Net.WebClient
            {
                Headers = { ["UserAgent"] = _userAgent }
            };

            try
            {
                return _cache.GetOrAdd(address, () => client.DownloadString(address), DateTimeOffset.UtcNow.AddSeconds(cacheSeconds));
            }
            catch (WebException e)
            {
                HttpWebResponse webResponse = e.Response as HttpWebResponse;

                switch (webResponse?.StatusCode)
                {
                    case HttpStatusCode.Forbidden:
                    case HttpStatusCode.InternalServerError:
                    case HttpStatusCode.NotFound:
                        throw new ESIException($"{e.Message} Url: {address}", e);
                }

                throw;
            } 
        }

        public async Task<string> GetAsync(string address, int cacheSeconds = 0)
        {
            System.Net.WebClient client = new System.Net.WebClient
            {
                Headers = { ["UserAgent"] = _userAgent }
            };

            try
            {
                return await _cache.GetOrAddAsync(address, async () => await client.DownloadStringTaskAsync(address), DateTimeOffset.UtcNow.AddSeconds(cacheSeconds));
            }
            catch (WebException e)
            {
                HttpWebResponse webResponse = e.Response as HttpWebResponse;

                switch (webResponse?.StatusCode)
                {
                    case HttpStatusCode.Forbidden:
                    case HttpStatusCode.InternalServerError:
                    case HttpStatusCode.NotFound:
                        throw new ESIException($"{e.Message} Url: {address}", e);
                }

                throw;
            }
        }
    }
}
