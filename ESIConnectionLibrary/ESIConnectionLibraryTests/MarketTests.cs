using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;
using Moq;
using Xunit;

namespace ESIConnectionLibraryTests
{
    public class MarketTests
    {
        [Fact]
        public void GetMarketGroupInformation_Sucessfully_returns_a_MarketGroupInformation()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int marketGroupId = 8976562;

            string getMarketGroupInformationJson = "{\"market_group_id\": 5,\"name\": \"Standard Frigates\",\"description\": \"Small, fast vessels suited to a variety of purposes.\",\"types\": [582, 583],\"parent_group_id\": 1361}";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(getMarketGroupInformationJson);

            InternalLatestMarket internalLatestMarket = new InternalLatestMarket(mockedWebClient.Object, string.Empty);

            V1MarketGroupInformation v1MarketGroupInformation = internalLatestMarket.GetMarketGroupInformation(marketGroupId);

            Assert.Equal(5, v1MarketGroupInformation.MarketGroupId);
            Assert.Equal(2, v1MarketGroupInformation.Types.Count);
            Assert.Equal(582, v1MarketGroupInformation.Types.First());
            Assert.Equal(1361, v1MarketGroupInformation.ParentGroupId);
        }

        [Fact]
        public async Task GetMarketGroupInformationAsync_Sucessfully_returns_a_MarketGroupInformation()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int marketGroupId = 8976562;

            string getMarketGroupInformationJson = "{\"market_group_id\": 5,\"name\": \"Standard Frigates\",\"description\": \"Small, fast vessels suited to a variety of purposes.\",\"types\": [582, 583],\"parent_group_id\": 1361}";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(getMarketGroupInformationJson);

            InternalLatestMarket internalLatestMarket = new InternalLatestMarket(mockedWebClient.Object, string.Empty);

            V1MarketGroupInformation v1MarketGroupInformation = await internalLatestMarket.GetMarketGroupInformationAsync(marketGroupId);

            Assert.Equal(5, v1MarketGroupInformation.MarketGroupId);
            Assert.Equal(2, v1MarketGroupInformation.Types.Count);
            Assert.Equal(582, v1MarketGroupInformation.Types.First());
            Assert.Equal(1361, v1MarketGroupInformation.ParentGroupId);
        }
    }
}
