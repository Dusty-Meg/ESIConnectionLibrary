using System;
using System.IO;
using System.Net;
using System.Net.Cache;
using System.Threading.Tasks;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.Exceptions;
using ESIConnectionLibrary.PublicModels;
using LazyCache;
using Microsoft.CSharp.RuntimeBinder;
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

                                    if (returnHeaders.GetKey(i) == "X-Esi-Ab-Test")
                                    {
                                        abTest = returnHeaders.Get(i);
                                    }
                                }
                            }
                        }
                        catch (Exception) { }

                        throw new ESIException($"{e.Message} Url: {address} Message From Server: {errorMessage} : AB test = {abTest} . Data: {data}", e);
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
                string reply = await _cache.GetOrAddAsync($"{address}{data}", async () => await client.UploadStringTaskAsync(url, data), DateTimeOffset.UtcNow.AddSeconds(cacheSeconds));

                return reply;
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

                                    if (returnHeaders.GetKey(i) == "X-Esi-Ab-Test")
                                    {
                                        abTest = returnHeaders.Get(i);
                                    }
                                }
                            }
                        }
                        catch (Exception) { }

                        throw new ESIException($"{e.Message} Url: {address} Message From Server: {errorMessage} : AB test = {abTest} . Data: {data}", e);
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

                                    if (returnHeaders.GetKey(i) == "X-Esi-Ab-Test")
                                    {
                                        abTest = returnHeaders.Get(i);
                                    }
                                }
                            }
                        }
                        catch (Exception) { }

                        throw new ESIException($"{e.Message} Url: {address} Message From Server: {errorMessage} : AB test = {abTest} . Data: {data}", e);
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

                                    if (returnHeaders.GetKey(i) == "X-Esi-Ab-Test")
                                    {
                                        abTest = returnHeaders.Get(i);
                                    }
                                }
                            }
                        }
                        catch (Exception) { }

                        throw new ESIException($"{e.Message} Url: {address} Message From Server: {errorMessage} : AB test = {abTest} . Data: {data}", e);
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

                                    if (returnHeaders.GetKey(i) == "X-Esi-Ab-Test")
                                    {
                                        abTest = returnHeaders.Get(i);
                                    }
                                }
                            }
                        }
                        catch (Exception) { }

                        throw new ESIException($"{e.Message} Url: {address} Message From Server: {errorMessage} : AB test = {abTest}", e);
                }

                throw;
            }
        }

        public PagedJson GetPaged(WebHeaderCollection headers, string address, int cacheSeconds = 0)
        {
            System.Net.WebClient client = new System.Net.WebClient
            {
                Headers = headers
            };

            try
            {
                PagedJson pagedJson = new PagedJson
                {
                    Response = _cache.GetOrAdd(address, () => client.DownloadString(address), DateTimeOffset.UtcNow.AddSeconds(cacheSeconds))
                };

                WebHeaderCollection responseHeaders = client.ResponseHeaders;

                if (client.ResponseHeaders != null)
                {
                    for (int i = 0; i < responseHeaders.Count; i++)
                    {
                        if (responseHeaders.GetKey(i) == "X-Pages")
                        {
                            pagedJson.MaxPages = int.Parse(responseHeaders.Get(i));
                        }
                    }
                }

                return pagedJson;
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

                                    if (returnHeaders.GetKey(i) == "X-Esi-Ab-Test")
                                    {
                                        abTest = returnHeaders.Get(i);
                                    }
                                }
                            }
                        }
                        catch (Exception) { }

                        throw new ESIException($"{e.Message} Url: {address} Message From Server: {errorMessage} : AB test = {abTest}", e);
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

                                    if (returnHeaders.GetKey(i) == "X-Esi-Ab-Test")
                                    {
                                        abTest = returnHeaders.Get(i);
                                    }
                                }
                            }
                        }
                        catch (Exception) { }

                        throw new ESIException($"{e.Message} Url: {address} Message From Server: {errorMessage} : AB test = {abTest}", e);
                }

                throw;
            }
        }

        public async Task<PagedJson> GetPagedAsync(WebHeaderCollection headers, string address, int cacheSeconds = 0)
        {
            System.Net.WebClient client = new System.Net.WebClient
            {
                Headers = headers
            };

            try
            {
                PagedJson pagedJson = new PagedJson
                {
                    Response = await _cache.GetOrAddAsync(address, async () => await client.DownloadStringTaskAsync(address), DateTimeOffset.UtcNow.AddSeconds(cacheSeconds))
                };

                if (client.ResponseHeaders != null)
                {
                    WebHeaderCollection responseHeaders = client.ResponseHeaders;

                    for (int i = 0; i < responseHeaders.Count; i++)
                    {
                        if (responseHeaders.GetKey(i) == "X-Pages")
                        {
                            pagedJson.MaxPages = int.Parse(responseHeaders.Get(i));
                        }
                    }
                }

                return pagedJson;
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

                                    if (returnHeaders.GetKey(i) == "X-Esi-Ab-Test")
                                    {
                                        abTest = returnHeaders.Get(i);
                                    }
                                }
                            }
                        }
                        catch (Exception) { }

                        throw new ESIException($"{e.Message} Url: {address} Message From Server: {errorMessage} : AB test = {abTest}", e);
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

                                    if (returnHeaders.GetKey(i) == "X-Esi-Ab-Test")
                                    {
                                        abTest = returnHeaders.Get(i);
                                    }
                                }
                            }
                        }
                        catch (Exception) { }

                        throw new ESIException($"{e.Message} Url: {address} Message From Server: {errorMessage} : AB test = {abTest}", e);
                }

                throw;
            } 
        }

        public PagedJson GetPaged(string address, int cacheSeconds = 0)
        {
            System.Net.WebClient client = new System.Net.WebClient
            {
                Headers = { ["UserAgent"] = _userAgent }
            };

            try
            {
                PagedJson pagedJson = new PagedJson
                {
                    Response = _cache.GetOrAdd(address, () => client.DownloadString(address), DateTimeOffset.UtcNow.AddSeconds(cacheSeconds))
                };

                WebHeaderCollection responseHeaders = client.ResponseHeaders;

                if (client.ResponseHeaders != null)
                {
                    for (int i = 0; i < responseHeaders.Count; i++)
                    {
                        if (responseHeaders.GetKey(i) == "X-Pages")
                        {
                            pagedJson.MaxPages = int.Parse(responseHeaders.Get(i));
                        }
                    }
                }

                return pagedJson;
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

                                    if (returnHeaders.GetKey(i) == "X-Esi-Ab-Test")
                                    {
                                        abTest = returnHeaders.Get(i);
                                    }
                                }
                            }
                        }
                        catch (Exception) { }

                        throw new ESIException($"{e.Message} Url: {address} Message From Server: {errorMessage} : AB test = {abTest}", e);
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

                                    if (returnHeaders.GetKey(i) == "X-Esi-Ab-Test")
                                    {
                                        abTest = returnHeaders.Get(i);
                                    }
                                }
                            }
                        }
                        catch (Exception) { }

                        throw new ESIException($"{e.Message} Url: {address} Message From Server: {errorMessage} : AB test = {abTest}", e);
                }

                throw;
            }
        }

        public async Task<PagedJson> GetPagedAsync(string address, int cacheSeconds = 0)
        {
            System.Net.WebClient client = new System.Net.WebClient
            {
                Headers = { ["UserAgent"] = _userAgent }
            };

            try
            {
                PagedJson pagedJson = new PagedJson
                {
                    Response = await _cache.GetOrAddAsync(address, async () => await client.DownloadStringTaskAsync(address), DateTimeOffset.UtcNow.AddSeconds(cacheSeconds))
                };

                WebHeaderCollection responseHeaders = client.ResponseHeaders;

                if (client.ResponseHeaders != null)
                {
                    for (int i = 0; i < responseHeaders.Count; i++)
                    {
                        if (responseHeaders.GetKey(i) == "X-Pages")
                        {
                            pagedJson.MaxPages = int.Parse(responseHeaders.Get(i));
                        }
                    }
                }

                return pagedJson;
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

                                    if (returnHeaders.GetKey(i) == "X-Esi-Ab-Test")
                                    {
                                        abTest = returnHeaders.Get(i);
                                    }
                                }
                            }
                        }
                        catch (Exception) { }

                        throw new ESIException($"{e.Message} Url: {address} Message From Server: {errorMessage} : AB test = {abTest}", e);
                }

                throw;
            }
        }
    }
}
