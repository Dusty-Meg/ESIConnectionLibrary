﻿using System.Net;

namespace ESIConnectionLibrary.Tests
{
    public class SwaggerSpecFixture
    {
        public string SwaggerSpec;

        public SwaggerSpecFixture()
        {
            WebClient client = new WebClient
            {
                Headers = { ["UserAgent"] = "Dusty Meg Tests" }
            };

            SwaggerSpec = client.DownloadString("https://esi.evetech.net/latest/swagger.json?datasource=tranquility");
        }
    }
}