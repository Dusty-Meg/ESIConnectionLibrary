using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Cache;
using System.Threading.Tasks;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.Exceptions;
using LazyCache;
using Newtonsoft.Json;

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

        public EsiModel Post(WebHeaderCollection headers, string address, string data, int cacheSeconds = 0)
        {
            System.Net.WebClient client = new System.Net.WebClient
            {
                Headers = headers,
                CachePolicy = new HttpRequestCachePolicy()
            };

            client.Headers["UserAgent"] = _userAgent;

            CacheModel cachedItem = _cache.Get<CacheModel>(address);
            EsiModel esiModel = new EsiModel();

            try
            {
                if (cacheSeconds == 0)
                {
                    esiModel.Model = client.UploadString(address, data);

                    esiModel = BuildHeaders(client.ResponseHeaders, esiModel);

                    return esiModel;
                }

                if (cachedItem != null)
                {
                    if (DateTime.Compare(cachedItem.Expires, DateTime.UtcNow) <= 0)
                    {
                        esiModel.Model = cachedItem.Item;
                        esiModel.Etag = cachedItem.Etag;
                        esiModel.MaxPages = cachedItem.Page;

                        return esiModel;
                    }

                    if (!string.IsNullOrEmpty(cachedItem.Etag))
                    {
                        client.Headers["If-None-Match"] = cachedItem.Etag;
                    }

                    string esiResponse = client.DownloadString(address);

                    esiModel = BuildHeaders(client.ResponseHeaders, esiModel);

                    cachedItem = new CacheModel(esiResponse, esiModel.Etag, cacheSeconds, esiModel.MaxPages);

                    _cache.Remove(address);
                    _cache.Add(address, cachedItem);
                }
                else
                {
                    string esiResponse = client.DownloadString(address);

                    esiModel = BuildHeaders(client.ResponseHeaders, esiModel);

                    cachedItem = new CacheModel(esiResponse, esiModel.Etag, cacheSeconds, esiModel.MaxPages);

                    _cache.Add(address, cachedItem);
                }

                esiModel.Model = cachedItem.Item;

                return esiModel;
            }
            catch (WebException e)
            {
                EsiModel returned = BuildException(e, cachedItem, esiModel, address, data);

                if (returned != null)
                {
                    return returned;
                }

                throw;
            }
        }

        public async Task<EsiModel> PostAsync(WebHeaderCollection headers, string address, string data, int cacheSeconds = 0)
        {
            System.Net.WebClient client = new System.Net.WebClient
            {
                Headers = headers,
                CachePolicy = new HttpRequestCachePolicy()
            };

            client.Headers["UserAgent"] = _userAgent;

            CacheModel cachedItem = await _cache.GetAsync<CacheModel>(address);
            EsiModel esiModel = new EsiModel();

            try
            {
                if (cacheSeconds == 0)
                {
                    esiModel.Model = await client.UploadStringTaskAsync(address, data);

                    esiModel = BuildHeaders(client.ResponseHeaders, esiModel);

                    return esiModel;
                }

                if (cachedItem != null)
                {
                    if (DateTime.Compare(cachedItem.Expires, DateTime.UtcNow) <= 0)
                    {
                        esiModel.Model = cachedItem.Item;
                        esiModel.Etag = cachedItem.Etag;
                        esiModel.MaxPages = cachedItem.Page;

                        return esiModel;
                    }

                    if (!string.IsNullOrEmpty(cachedItem.Etag))
                    {
                        client.Headers["If-None-Match"] = cachedItem.Etag;
                    }

                    string esiResponse = await client.DownloadStringTaskAsync(address);

                    esiModel = BuildHeaders(client.ResponseHeaders, esiModel);

                    cachedItem = new CacheModel(esiResponse, esiModel.Etag, cacheSeconds, esiModel.MaxPages);

                    _cache.Remove(address);
                    _cache.Add(address, cachedItem);
                }
                else
                {
                    string esiResponse = await client.DownloadStringTaskAsync(address);

                    esiModel = BuildHeaders(client.ResponseHeaders, esiModel);

                    cachedItem = new CacheModel(esiResponse, esiModel.Etag, cacheSeconds, esiModel.MaxPages);

                    _cache.Add(address, cachedItem);
                }

                esiModel.Model = cachedItem.Item;

                return esiModel;
            }
            catch (WebException e)
            {
                EsiModel returned = BuildException(e, cachedItem, esiModel, address, data);

                if (returned != null)
                {
                    return returned;
                }

                throw;
            }
        }

        public string Put(WebHeaderCollection headers, string address, string data)
        {
            System.Net.WebClient client = new System.Net.WebClient
            {
                Headers = headers,
                CachePolicy = new HttpRequestCachePolicy()
            };

            client.Headers["UserAgent"] = _userAgent;

            try
            {
                return client.UploadString(address, "PUT", data);
            }
            catch (WebException e)
            {
                EsiModel returned = BuildException(e, null, null, address, data);

                if (returned != null)
                {
                    return string.Empty;
                }

                throw;
            }
        }

        public async Task<string> PutAsync(WebHeaderCollection headers, string address, string data)
        {
            System.Net.WebClient client = new System.Net.WebClient
            {
                Headers = headers,
                CachePolicy = new HttpRequestCachePolicy()
            };

            client.Headers["UserAgent"] = _userAgent;

            try
            {
                return await client.UploadStringTaskAsync(address, "PUT", data);
            }
            catch (WebException e)
            {
                EsiModel returned = BuildException(e, null, null, address, data);

                if (returned != null)
                {
                    return string.Empty;
                }

                throw;
            }
        }

        public async Task<EsiModel> GetAsync(WebHeaderCollection headers, string address, int cacheSeconds = 0)
        {
            System.Net.WebClient client = new System.Net.WebClient
            {
                Headers = { ["UserAgent"] = _userAgent }
            };

            if (headers != null)
            {
                client.Headers = headers;
                client.Headers["UserAgent"] = _userAgent;
            }

            CacheModel cachedItem = await _cache.GetAsync<CacheModel>(address);
            EsiModel esiModel = new EsiModel();

            try
            {
                if (cachedItem != null)
                {
                    if (DateTime.Compare(cachedItem.Expires, DateTime.UtcNow) <= 0)
                    {
                        esiModel.Model = cachedItem.Item;
                        esiModel.Etag = cachedItem.Etag;
                        esiModel.MaxPages = cachedItem.Page;

                        return esiModel;
                    }

                    if (!string.IsNullOrEmpty(cachedItem.Etag))
                    {
                        client.Headers["If-None-Match"] = cachedItem.Etag;
                    }

                    string esiResponse = await client.DownloadStringTaskAsync(address);

                    esiModel = BuildHeaders(client.ResponseHeaders, esiModel);

                    cachedItem = new CacheModel(esiResponse, esiModel.Etag, cacheSeconds, esiModel.MaxPages);

                    _cache.Remove(address);
                    _cache.Add(address, cachedItem);
                }
                else
                {
                    string esiResponse = await client.DownloadStringTaskAsync(address);

                    esiModel = BuildHeaders(client.ResponseHeaders, esiModel);

                    cachedItem = new CacheModel(esiResponse, esiModel.Etag, cacheSeconds, esiModel.MaxPages);

                    _cache.Add(address, cachedItem);
                }

                esiModel.Model = cachedItem.Item;

                return esiModel;
            }
            catch (WebException e)
            {
                EsiModel returned = BuildException(e, cachedItem, esiModel, address, string.Empty);

                if (returned != null)
                {
                    return returned;
                }

                throw;
            }
        }

        public EsiModel Get(WebHeaderCollection headers, string address, int cacheSeconds = 0)
        {
            System.Net.WebClient client = new System.Net.WebClient
            {
                Headers = { ["UserAgent"] = _userAgent }
            };

            if (headers != null)
            {
                client.Headers = headers;
                client.Headers["UserAgent"] = _userAgent;
            }

            CacheModel cachedItem = _cache.Get<CacheModel>(address);
            EsiModel esiModel = new EsiModel();

            try
            {
                if (cachedItem != null)
                {
                    if (DateTime.Compare(cachedItem.Expires, DateTime.UtcNow) <= 0)
                    {
                        esiModel.Model = cachedItem.Item;
                        esiModel.Etag = cachedItem.Etag;
                        esiModel.MaxPages = cachedItem.Page;

                        return esiModel;
                    }

                    if (!string.IsNullOrEmpty(cachedItem.Etag))
                    {
                        client.Headers["If-None-Match"] = cachedItem.Etag;
                    }

                    string esiResponse = client.DownloadString(address);

                    esiModel = BuildHeaders(client.ResponseHeaders, esiModel);

                    cachedItem = new CacheModel(esiResponse, esiModel.Etag, cacheSeconds, esiModel.MaxPages);

                    _cache.Remove(address);
                    _cache.Add(address, cachedItem);
                }
                else
                {
                    string esiResponse = client.DownloadString(address);

                    esiModel = BuildHeaders(client.ResponseHeaders, esiModel);

                    cachedItem = new CacheModel(esiResponse, esiModel.Etag, cacheSeconds, esiModel.MaxPages);

                    _cache.Add(address, cachedItem);
                }

                esiModel.Model = cachedItem.Item;

                return esiModel;
            }
            catch (WebException e)
            {
                EsiModel returned = BuildException(e, cachedItem, esiModel, address, string.Empty);

                if (returned != null)
                {
                    return returned;
                }

                throw;
            }
        }

        private EsiModel BuildHeaders(WebHeaderCollection responseHeaders, EsiModel esiModel)
        {
            if (responseHeaders == null)
            {
                return esiModel;
            }

            for (int i = 0; i < responseHeaders.Count; i++)
            {
                switch (responseHeaders.GetKey(i))
                {
                    case "ETag":
                        esiModel.Etag = responseHeaders.Get(i);
                        break;
                    case "X-Pages":
                        int.TryParse(responseHeaders.Get(i), out int maxPages);

                        esiModel.MaxPages = maxPages;
                        break;
                    case "Expires":
                        DateTime.TryParse(responseHeaders.Get(i), out DateTime expires);

                        esiModel.Expires = expires;
                        break;
                    case "Last-Modified":
                        DateTime.TryParse(responseHeaders.Get(i), out DateTime lastModified);

                        esiModel.LastModified = lastModified;
                        break;
                }

                esiModel.ResponseHeaders.Add(responseHeaders.GetKey(i), responseHeaders.Get(i));
            }

            return esiModel;
        }

        private EsiModel BuildException(WebException e, CacheModel cachedItem, EsiModel esiModel, string address, string data)
        {
            HttpWebResponse webResponse = e.Response as HttpWebResponse;

            switch (webResponse?.StatusCode)
            {
                case HttpStatusCode.NotModified:
                    if (cachedItem == null)
                    {
                        return null;
                    }

                    esiModel.Model = cachedItem.Item;
                    esiModel.Etag = cachedItem.Etag;
                    esiModel.MaxPages = cachedItem.Page;

                    return esiModel;
                case HttpStatusCode.Forbidden:
                case HttpStatusCode.InternalServerError:
                case HttpStatusCode.NotFound:
                case HttpStatusCode.BadRequest:
                    Stream responseStream = webResponse.GetResponseStream();

                    if (responseStream == null)
                    {
                        throw new ESIException($"{e.Message} Url: {address}");
                    }

                    string resp = new StreamReader(responseStream).ReadToEnd();
                    string errorMessage = string.Empty;

                    string returnHeadersString = string.Empty;

                    WebHeaderCollection returnHeaders = webResponse.Headers;

                    try
                    {
                        EsiError error = JsonConvert.DeserializeObject<EsiError>(resp);

                        errorMessage = error.Error;

                        if (returnHeaders != null)
                        {
                            for (int i = 0; i < returnHeaders.Count; i++)
                            {
                                returnHeadersString += $"{returnHeaders.GetKey(i)}: {returnHeaders.Get(i)} | ";
                            }
                        }
                    }
                    catch (Exception)
                    {
                    }

                    throw new ESIException($"{e.Message} Url: {address} Message From Server: {errorMessage} : Return Headers = {returnHeadersString} . Data: {data}", e);
            }

            return null;
        }
    }
}
