using System.Net;
using System.Threading.Tasks;

namespace ESIConnectionLibrary.Internal_classes
{
    internal interface IWebClient
    {
        EsiModel Get(WebHeaderCollection headers, string address, int cacheSeconds = 0);
        Task<EsiModel> GetAsync(WebHeaderCollection headers, string address, int cacheSeconds = 0);
        string Put(WebHeaderCollection headers, string address, string data);
        Task<string> PutAsync(WebHeaderCollection headers, string address, string data);
        EsiModel Post(WebHeaderCollection headers, string address, string data, int cacheSeconds = 0);
        Task<EsiModel> PostAsync(WebHeaderCollection headers, string address, string data, int cacheSeconds = 0);
    }
}