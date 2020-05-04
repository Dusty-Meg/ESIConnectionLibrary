using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;
using Moq;
using Xunit;

namespace ESIConnectionLibrary.Tests
{
    public class InsuranceTests
    {
        [Fact]
        public void Insurance_successfully_returns_a_listV1InsuranceInsurance()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  {\r\n    \"levels\": [\r\n      {\r\n        \"cost\": 10.01,\r\n        \"name\": \"Basic\",\r\n        \"payout\": 20.01\r\n      }\r\n    ],\r\n    \"type_id\": 1\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestInsurance internalLatestInsurance = new InternalLatestInsurance(mockedWebClient.Object, string.Empty);

            IList<V1InsuranceInsurance> returnModel = internalLatestInsurance.Insurance();

            Assert.Single(returnModel);

            Assert.Single(returnModel[0].Levels);

            Assert.Equal(10.01f, returnModel[0].Levels[0].Cost);
            Assert.Equal("Basic", returnModel[0].Levels[0].Name);
            Assert.Equal(20.01f, returnModel[0].Levels[0].Payout);

            Assert.Equal(1, returnModel[0].TypeId);
        }

        [Fact]
        public async Task InsuranceAsync_successfully_returns_a_listV1InsuranceInsurance()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  {\r\n    \"levels\": [\r\n      {\r\n        \"cost\": 10.01,\r\n        \"name\": \"Basic\",\r\n        \"payout\": 20.01\r\n      }\r\n    ],\r\n    \"type_id\": 1\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestInsurance internalLatestInsurance = new InternalLatestInsurance(mockedWebClient.Object, string.Empty);

            IList<V1InsuranceInsurance> returnModel = await internalLatestInsurance.InsuranceAsync();

            Assert.Single(returnModel);

            Assert.Single(returnModel[0].Levels);

            Assert.Equal(10.01f, returnModel[0].Levels[0].Cost);
            Assert.Equal("Basic", returnModel[0].Levels[0].Name);
            Assert.Equal(20.01f, returnModel[0].Levels[0].Payout);

            Assert.Equal(1, returnModel[0].TypeId);
        }
    }
}
