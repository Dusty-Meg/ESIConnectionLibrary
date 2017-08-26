using System;
using System.Net;
using ESIConnectionLibrary.Exceptions;

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

            try
            {
                return client.UploadString(address, data);
            }
            catch (WebException e)
            {
                HttpWebResponse webResponse = e.Response as HttpWebResponse;

                switch (webResponse?.StatusCode)
                {
                    case HttpStatusCode.Forbidden:
                    case HttpStatusCode.InternalServerError:
                        throw new ESIException(e.Message, e);
                }

                throw;
            }
        }

        public string Get(WebHeaderCollection headers, string address)
        {
            System.Net.WebClient client = new System.Net.WebClient
            {
                Headers = headers
            };

            client.Headers["UserAgent"] = "Dusty Meg";

            try
            {
                return client.DownloadString(address);
            }
            catch (WebException e)
            {
                HttpWebResponse webResponse = e.Response as HttpWebResponse;

                switch (webResponse?.StatusCode)
                {
                    case HttpStatusCode.Forbidden:
                    case HttpStatusCode.InternalServerError:
                        throw new ESIException(e.Message, e);
                }

                throw;
            }
        }

        public string Get(string address)
        {
            System.Net.WebClient client = new System.Net.WebClient
            {
                Headers = { ["UserAgent"] = "Dusty Meg" }
            };

            try
            {
                return client.DownloadString(address);
            }
            catch (WebException e)
            {
                HttpWebResponse webResponse = e.Response as HttpWebResponse;

                switch (webResponse?.StatusCode)
                {
                    case HttpStatusCode.Forbidden:
                    case HttpStatusCode.InternalServerError:
                        throw new ESIException(e.Message, e);
                }

                throw;
            } 
        }
    }
}
