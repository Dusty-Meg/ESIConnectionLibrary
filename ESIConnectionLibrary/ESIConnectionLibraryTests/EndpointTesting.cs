using System;
using System.Reflection;
using ESIConnectionLibrary.Internal_classes;
using Xunit;
using WebClient = System.Net.WebClient;

namespace ESIConnectionLibraryTests
{
    public class EndpointTesting
    {
        private string _swaggerSpec;

        private string SwaggerSpec
        {
            get
            {
                if (_swaggerSpec == null)
                {
                    WebClient client = new WebClient
                    {
                        Headers = { ["UserAgent"] = "Dusty Meg Tests" }
                    };

                    _swaggerSpec = client.DownloadString("https://esi.tech.ccp.is/latest/swagger.json?datasource=tranquility");
                }

                return _swaggerSpec;
            }
        }

        private string GetPrivateString(string privateMethodName)
        {
            Type type = typeof(StaticConnectionStrings);

            PropertyInfo info = type.GetProperty(privateMethodName, BindingFlags.NonPublic | BindingFlags.Static);

            return info.GetValue(null) as string;
        }

        [Fact]
        public void SkillsSkillsEndpoint()
        {
            Assert.True(SwaggerSpec.Contains(GetPrivateString("SkillsSkillsRaw")));
        }

        [Fact]
        public void SkillsAttributesEndpoint()
        {
            Assert.True(SwaggerSpec.Contains(GetPrivateString("SkillsAttributesRaw")));
        }

        [Fact]
        public void SkillsSkillQueueEndpoint()
        {
            Assert.True(SwaggerSpec.Contains(GetPrivateString("SkillsSkillQueueRaw")));
        }

        [Fact]
        public void IndustryCharacterJobs()
        {
            Assert.True(SwaggerSpec.Contains(GetPrivateString("IndustryCharacterJobsRaw")));
        }

        [Fact]
        public void FleetsGetFleet()
        {
            Assert.True(SwaggerSpec.Contains(GetPrivateString("FleetsGetFleetRaw")));
        }
    }
}
