using System.Net;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Internal_classes
{
    internal interface IWebClient
    {
        string Get(string address, int cacheSeconds = 0);
        PagedJson GetPaged(string address, int cacheSeconds = 0);
        Task<string> GetAsync(string address, int cacheSeconds = 0);
        Task<PagedJson> GetPagedAsync(string address, int cacheSeconds = 0);
        string Get(WebHeaderCollection headers, string address, int cacheSeconds = 0);
        PagedJson GetPaged(WebHeaderCollection headers, string address, int cacheSeconds = 0);
        Task<string> GetAsync(WebHeaderCollection headers, string address, int cacheSeconds = 0);
        Task<PagedJson> GetPagedAsync(WebHeaderCollection headers, string address, int cacheSeconds = 0);
        string Post(WebHeaderCollection headers, string address, string data, int cacheSeconds = 0);
        Task<string> PostAsync(WebHeaderCollection headers, string address, string data, int cacheSeconds = 0);
        string Put(WebHeaderCollection headers, string address, string data, int cacheSeconds = 0);
        Task<string> PutAsync(WebHeaderCollection headers, string address, string data, int cacheSeconds = 0);
    }
}