using System.Net;

namespace ESIConnectionLibrary.Internal_classes
{
    internal interface IWebClient
    {
        string Get(string address);
        string Get(WebHeaderCollection headers, string address);
        string Post(WebHeaderCollection headers, string address, string data);
    }
}