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

                    WebHeaderCollection responseHeaders = client.ResponseHeaders;

                    if (client.ResponseHeaders != null)
                    {
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
                    }

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

                    WebHeaderCollection responseHeaders = client.ResponseHeaders;

                    if (client.ResponseHeaders != null)
                    {
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
                    }

                    cachedItem = new CacheModel(esiResponse, esiModel.Etag, cacheSeconds, esiModel.MaxPages);

                    _cache.Remove(address);
                    _cache.Add(address, cachedItem);
                }
                else
                {
                    string esiResponse = client.DownloadString(address);

                    WebHeaderCollection responseHeaders = client.ResponseHeaders;

                    if (client.ResponseHeaders != null)
                    {
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
                    }

                    cachedItem = new CacheModel(esiResponse, esiModel.Etag, cacheSeconds, esiModel.MaxPages);

                    _cache.Add(address, cachedItem);
                }

                esiModel.Model = cachedItem.Item;

                return esiModel;
            }
            catch (WebException e)
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
                        string resp = new StreamReader(e.Response.GetResponseStream()).ReadToEnd();
                        string errorMessage = string.Empty;

                        string abTest = string.Empty;

                        WebHeaderCollection returnHeaders = webResponse.Headers;

                        try
                        {
                            EsiError error = JsonConvert.DeserializeObject<EsiError>(resp);

                            errorMessage = error.Error;

                            if (returnHeaders != null)
                            {
                                for (int i = 0; i < returnHeaders.Count; i++)
                                {
                                    abTest += $"{returnHeaders.GetKey(i)}: {returnHeaders.Get(i)} | ";
                                }
                            }
                        }
                        catch (Exception) { }

                        throw new ESIException($"{e.Message} Url: {address} Message From Server: {errorMessage} : Return Headers = {abTest} . Data: {data}", e);
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

                    WebHeaderCollection responseHeaders = client.ResponseHeaders;

                    if (client.ResponseHeaders != null)
                    {
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
                    }

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

                    WebHeaderCollection responseHeaders = client.ResponseHeaders;

                    if (client.ResponseHeaders != null)
                    {
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
                    }

                    cachedItem = new CacheModel(esiResponse, esiModel.Etag, cacheSeconds, esiModel.MaxPages);

                    _cache.Remove(address);
                    _cache.Add(address, cachedItem);
                }
                else
                {
                    string esiResponse = await client.DownloadStringTaskAsync(address);

                    WebHeaderCollection responseHeaders = client.ResponseHeaders;

                    if (client.ResponseHeaders != null)
                    {
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
                    }

                    cachedItem = new CacheModel(esiResponse, esiModel.Etag, cacheSeconds, esiModel.MaxPages);

                    _cache.Add(address, cachedItem);
                }

                esiModel.Model = cachedItem.Item;

                return esiModel;
            }
            catch (WebException e)
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
                        string resp = new StreamReader(e.Response.GetResponseStream()).ReadToEnd();
                        string errorMessage = string.Empty;

                        string abTest = string.Empty;

                        WebHeaderCollection returnHeaders = webResponse.Headers;

                        try
                        {
                            EsiError error = JsonConvert.DeserializeObject<EsiError>(resp);

                            errorMessage = error.Error;

                            if (returnHeaders != null)
                            {
                                for (int i = 0; i < returnHeaders.Count; i++)
                                {
                                    abTest += $"{returnHeaders.GetKey(i)}: {returnHeaders.Get(i)} | ";
                                }
                            }
                        }
                        catch (Exception) { }

                        throw new ESIException($"{e.Message} Url: {address} Message From Server: {errorMessage} : Return Headers = {abTest} . Data: {data}", e);
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
                HttpWebResponse webResponse = e.Response as HttpWebResponse;

                switch (webResponse?.StatusCode)
                {
                    case HttpStatusCode.Forbidden:
                    case HttpStatusCode.InternalServerError:
                    case HttpStatusCode.NotFound:
                    case HttpStatusCode.BadRequest:
                        string resp = new StreamReader(e.Response.GetResponseStream()).ReadToEnd();
                        string errorMessage = string.Empty;

                        string abTest = string.Empty;

                        WebHeaderCollection returnHeaders = webResponse.Headers;

                        try
                        {
                            EsiError error = JsonConvert.DeserializeObject<EsiError>(resp);

                            errorMessage = error.Error;

                            if (returnHeaders != null)
                            {
                                for (int i = 0; i < returnHeaders.Count; i++)
                                {
                                    abTest += $"{returnHeaders.GetKey(i)}: {returnHeaders.Get(i)} | ";
                                }
                            }
                        }
                        catch (Exception) { }

                        throw new ESIException($"{e.Message} Url: {address} Message From Server: {errorMessage} : Return Headers = {abTest} . Data: {data}", e);
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
                HttpWebResponse webResponse = e.Response as HttpWebResponse;

                switch (webResponse?.StatusCode)
                {
                    case HttpStatusCode.Forbidden:
                    case HttpStatusCode.InternalServerError:
                    case HttpStatusCode.NotFound:
                    case HttpStatusCode.BadRequest:
                        string resp = new StreamReader(e.Response.GetResponseStream()).ReadToEnd();
                        string errorMessage = string.Empty;

                        string abTest = string.Empty;

                        WebHeaderCollection returnHeaders = webResponse.Headers;

                        try
                        {
                            EsiError error = JsonConvert.DeserializeObject<EsiError>(resp);

                            errorMessage = error.Error;

                            if (returnHeaders != null)
                            {
                                for (int i = 0; i < returnHeaders.Count; i++)
                                {
                                    abTest += $"{returnHeaders.GetKey(i)}: {returnHeaders.Get(i)} | ";
                                }
                            }
                        }
                        catch (Exception) { }

                        throw new ESIException($"{e.Message} Url: {address} Message From Server: {errorMessage} : Return Headers = {abTest} . Data: {data}", e);
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

            string etag = string.Empty;
            int page = 0;
            DateTime expires = DateTime.MinValue;
            DateTime lastModified = DateTime.MinValue;
            Dictionary<string, string> headersDictionary = new Dictionary<string, string>();

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

                    WebHeaderCollection responseHeaders = client.ResponseHeaders;

                    if (client.ResponseHeaders != null)
                    {
                        for (int i = 0; i < responseHeaders.Count; i++)
                        {
                            switch (responseHeaders.GetKey(i))
                            {
                                case "ETag":
                                    etag = responseHeaders.Get(i);
                                    break;
                                case "X-Pages":
                                    int.TryParse(responseHeaders.Get(i), out page);
                                    break;
                                case "Expires":
                                    DateTime.TryParse(responseHeaders.Get(i), out expires);
                                    break;
                                case "Last-Modified":
                                    DateTime.TryParse(responseHeaders.Get(i), out lastModified);
                                    break;
                            }

                            headersDictionary.Add(responseHeaders.GetKey(i), responseHeaders.Get(i));
                        }
                    }

                    cachedItem = new CacheModel(esiResponse, etag, cacheSeconds, page);

                    _cache.Remove(address);
                    _cache.Add(address, cachedItem);
                }
                else
                {
                    string esiResponse = await client.DownloadStringTaskAsync(address);

                    WebHeaderCollection responseHeaders = client.ResponseHeaders;

                    if (client.ResponseHeaders != null)
                    {
                        for (int i = 0; i < responseHeaders.Count; i++)
                        {
                            switch (responseHeaders.GetKey(i))
                            {
                                case "ETag":
                                    etag = responseHeaders.Get(i);
                                    break;
                                case "X-Pages":
                                    int.TryParse(responseHeaders.Get(i), out page);
                                    break;
                                case "Expires":
                                    DateTime.TryParse(responseHeaders.Get(i), out expires);
                                    break;
                                case "Last-Modified":
                                    DateTime.TryParse(responseHeaders.Get(i), out lastModified);
                                    break;
                            }

                            headersDictionary.Add(responseHeaders.GetKey(i), responseHeaders.Get(i));
                        }
                    }

                    cachedItem = new CacheModel(esiResponse, etag, cacheSeconds, page);

                    _cache.Add(address, cachedItem);
                }

                esiModel.Model = cachedItem.Item;
                esiModel.Etag = etag;
                esiModel.MaxPages = page;
                esiModel.Expires = expires;
                esiModel.LastModified = lastModified;
                esiModel.ResponseHeaders = headersDictionary;

                return esiModel;
            }
            catch (WebException e)
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
                        string resp = new StreamReader(e.Response.GetResponseStream()).ReadToEnd();
                        string errorMessage = string.Empty;

                        string abTest = string.Empty;

                        WebHeaderCollection returnHeaders = webResponse.Headers;

                        try
                        {
                            EsiError error = JsonConvert.DeserializeObject<EsiError>(resp);

                            errorMessage = error.Error;

                            if (returnHeaders != null)
                            {
                                for (int i = 0; i < returnHeaders.Count; i++)
                                {
                                    abTest += $"{returnHeaders.GetKey(i)}: {returnHeaders.Get(i)} | ";
                                }
                            }
                        }
                        catch (Exception) { }

                        throw new ESIException($"{e.Message} Url: {address} Message From Server: {errorMessage} : Return Headers = {abTest}", e);
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

            string etag = string.Empty;
            int page = 0;
            DateTime expires = DateTime.MinValue;
            DateTime lastModified = DateTime.MinValue;
            Dictionary<string, string> headersDictionary = new Dictionary<string, string>();

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

                    WebHeaderCollection responseHeaders = client.ResponseHeaders;

                    if (client.ResponseHeaders != null)
                    {
                        for (int i = 0; i < responseHeaders.Count; i++)
                        {
                            switch (responseHeaders.GetKey(i))
                            {
                                case "ETag":
                                    etag = responseHeaders.Get(i);
                                    break;
                                case "X-Pages":
                                    int.TryParse(responseHeaders.Get(i), out page);
                                    break;
                                case "Expires":
                                    DateTime.TryParse(responseHeaders.Get(i), out expires);
                                    break;
                                case "Last-Modified":
                                    DateTime.TryParse(responseHeaders.Get(i), out lastModified);
                                    break;
                            }

                            headersDictionary.Add(responseHeaders.GetKey(i), responseHeaders.Get(i));
                        }
                    }

                    cachedItem = new CacheModel(esiResponse, etag, cacheSeconds, page);

                    _cache.Remove(address);
                    _cache.Add(address, cachedItem);
                }
                else
                {
                    string esiResponse = client.DownloadString(address);

                    WebHeaderCollection responseHeaders = client.ResponseHeaders;

                    if (client.ResponseHeaders != null)
                    {
                        for (int i = 0; i < responseHeaders.Count; i++)
                        {
                            switch (responseHeaders.GetKey(i))
                            {
                                case "ETag":
                                    etag = responseHeaders.Get(i);
                                    break;
                                case "X-Pages":
                                    int.TryParse(responseHeaders.Get(i), out page);
                                    break;
                                case "Expires":
                                    DateTime.TryParse(responseHeaders.Get(i), out expires);
                                    break;
                                case "Last-Modified":
                                    DateTime.TryParse(responseHeaders.Get(i), out lastModified);
                                    break;
                            }

                            headersDictionary.Add(responseHeaders.GetKey(i), responseHeaders.Get(i));
                        }
                    }

                    cachedItem = new CacheModel(esiResponse, etag, cacheSeconds, page);

                    _cache.Add(address, cachedItem);
                }

                esiModel.Model = cachedItem.Item;
                esiModel.Etag = etag;
                esiModel.MaxPages = page;
                esiModel.Expires = expires;
                esiModel.LastModified = lastModified;
                esiModel.ResponseHeaders = headersDictionary;

                return esiModel;
            }
            catch (WebException e)
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
                        string resp = new StreamReader(e.Response.GetResponseStream()).ReadToEnd();
                        string errorMessage = string.Empty;

                        string abTest = string.Empty;

                        WebHeaderCollection returnHeaders = webResponse.Headers;

                        try
                        {
                            EsiError error = JsonConvert.DeserializeObject<EsiError>(resp);

                            errorMessage = error.Error;

                            if (returnHeaders != null)
                            {
                                for (int i = 0; i < returnHeaders.Count; i++)
                                {
                                    abTest += $"{returnHeaders.GetKey(i)}: {returnHeaders.Get(i)} | ";
                                }
                            }
                        }
                        catch (Exception) { }

                        throw new ESIException($"{e.Message} Url: {address} Message From Server: {errorMessage} : Return Headers = {abTest}", e);
                }

                throw;
            }
        }
    }
}
