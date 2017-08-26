using System.Net;

namespace ESIConnectionLibrary.Internal_classes
{
    internal class WebClient : IWebClient
    {
        public string Post(WebHeaderCollection headers, string address, string data)
        {
            System.Net.WebClient client = new System.Net.WebClient
            {
                Headers = headers
            };

            client.Headers["UserAgent"] = "Dusty Meg";

            return client.UploadString(address, data);
        }

        public string Get(WebHeaderCollection headers, string address)
        {
            System.Net.WebClient client = new System.Net.WebClient
            {
                Headers = headers
            };

            client.Headers["UserAgent"] = "Dusty Meg";

            return client.DownloadString(address);
        }

        public string Get(string address)
        {
            System.Net.WebClient client = new System.Net.WebClient
            {
                Headers = { ["UserAgent"] = "Dusty Meg" }
            };

            return client.DownloadString(address);
        }
    }
}
