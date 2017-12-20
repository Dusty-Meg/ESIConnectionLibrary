using System.Net;
using System.Threading.Tasks;

namespace ESIConnectionLibrary.Internal_classes
{
    internal interface IWebClient
    {
        string Get(string address, int cacheSeconds = 0);
        string Get(WebHeaderCollection headers, string address, int cacheSeconds = 0);
        Task<string> GetAsync(string address, int cacheSeconds = 0);
        Task<string> GetAsync(WebHeaderCollection headers, string address, int cacheSeconds = 0);
        string Post(WebHeaderCollection headers, string address, string data, int cacheSeconds = 0);
        Task<string> PostAsync(WebHeaderCollection headers, string address, string data, int cacheSeconds = 0);
        string Put(WebHeaderCollection headers, string address, string data, int cacheSeconds = 0);
        Task<string> PutAsync(WebHeaderCollection headers, string address, string data, int cacheSeconds = 0);
    }
}