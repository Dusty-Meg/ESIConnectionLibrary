using System.Net;

namespace ESIConnectionLibrary.Internal_classes
{
    internal interface IWebClient
    {
        string Get(string address, int cacheSeconds = 0);
        string Get(WebHeaderCollection headers, string address, int cacheSeconds = 0);
        string Post(WebHeaderCollection headers, string address, string data, int cacheSeconds = 0);
    }
}