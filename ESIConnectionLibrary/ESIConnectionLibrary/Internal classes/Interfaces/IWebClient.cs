using System.Net;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Internal_classes
{
    internal interface IWebClient
    {
        EsiModel Get(WebHeaderCollection headers, string address, int cacheSeconds = 0);
        Task<EsiModel> GetAsync(WebHeaderCollection headers, string address, int cacheSeconds = 0);
        string Post(WebHeaderCollection headers, string address, string data, int cacheSeconds = 0);
        Task<string> PostAsync(WebHeaderCollection headers, string address, string data, int cacheSeconds = 0);
        string Put(WebHeaderCollection headers, string address, string data, int cacheSeconds = 0);
        Task<string> PutAsync(WebHeaderCollection headers, string address, string data, int cacheSeconds = 0);
    }
}