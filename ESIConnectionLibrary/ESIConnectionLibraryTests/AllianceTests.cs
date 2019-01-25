using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;
using Moq;
using Xunit;

namespace ESIConnectionLibraryTests
{
    public class AllianceTests
    {
        [Fact]
        public void Alliances_Successfully_returns_a_list_of_AllianceIds()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[99000001,99000002]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel{Model = json});

            InternalLatestAlliance internalLatestAlliance = new InternalLatestAlliance(mockedWebClient.Object, string.Empty);

            IList<int> allianceIds = internalLatestAlliance.Alliances();

            Assert.Equal(2, allianceIds.Count);
        }

        [Fact]
        public async Task AlliancesAsync_Successfully_returns_a_list_of_AllianceIds()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[99000001,99000002]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestAlliance internalLatestAlliance = new InternalLatestAlliance(mockedWebClient.Object, string.Empty);

            IList<int> allianceIds = await internalLatestAlliance.AlliancesAsync();

            Assert.Equal(2, allianceIds.Count);
        }

        [Fact]
        public void PublicInfo_Successfully_returns_a_GetPublicAlliance()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\"name\": \"C C P Alliance\",\"ticker\": \"<C C P>\",\"creator_id\": 12345,\"creator_corporation_id\": 45678,\"executor_corporation_id\": 98356193,\"date_founded\": \"2016-06-26T21:00:00Z\"}";

            int allianceId = 8762;

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestAlliance internalLatestAlliance = new InternalLatestAlliance(mockedWebClient.Object, string.Empty);

            V3AlliancePublicInfo infoInfo = internalLatestAlliance.PublicInfo(allianceId);

            Assert.Equal("C C P Alliance", infoInfo.Name);
            Assert.Equal(DateTime.Parse("2016-06-26T21:00:00"), infoInfo.DateFounded);
        }

        [Fact]
        public async Task PublicInfoAsync_Successfully_returns_a_GetPublicAlliance()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\"name\": \"C C P Alliance\",\"ticker\": \"<C C P>\",\"creator_id\": 12345,\"creator_corporation_id\": 45678,\"executor_corporation_id\": 98356193,\"date_founded\": \"2016-06-26T21:00:00Z\"}";

            int allianceId = 8762;

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestAlliance internalLatestAlliance = new InternalLatestAlliance(mockedWebClient.Object, string.Empty);

            V3AlliancePublicInfo infoInfo = await internalLatestAlliance.PublicInfoAsync(allianceId);

            Assert.Equal("C C P Alliance", infoInfo.Name);
            Assert.Equal(DateTime.Parse("2016-06-26T21:00:00"), infoInfo.DateFounded);
        }

        [Fact]
        public void Corporations_successfully_return_a_list_of_ints()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[98000001]";

            int allianceId = 8762;

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestAlliance internalLatestAlliance = new InternalLatestAlliance(mockedWebClient.Object, string.Empty);

            IList<int> corporationIds = internalLatestAlliance.Corporations(allianceId);

            Assert.Equal(98000001, corporationIds.First());
            Assert.Single(corporationIds);
        }

        [Fact]
        public async Task CorporationsAsync_successfully_return_a_list_of_ints()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[98000001]";

            int allianceId = 8762;

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestAlliance internalLatestAlliance = new InternalLatestAlliance(mockedWebClient.Object, string.Empty);

            IList<int> corporationIds = await internalLatestAlliance.CorporationsAsync(allianceId);

            Assert.Equal(98000001, corporationIds.First());
            Assert.Single(corporationIds);
        }

        [Fact]
        public void Icons_successfully_return_a_AllianceIcons()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\"px64x64\": \"https://imageserver.eveonline.com/Alliance/503818424_64.png\",\"px128x128\": \"https://imageserver.eveonline.com/Alliance/503818424_128.png\"}";

            int allianceId = 8762;

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestAlliance internalLatestAlliance = new InternalLatestAlliance(mockedWebClient.Object, string.Empty);

            V1AllianceIcons allianceIcons = internalLatestAlliance.Icons(allianceId);

            Assert.Equal("https://imageserver.eveonline.com/Alliance/503818424_64.png", allianceIcons.Px64X64);
            Assert.Equal("https://imageserver.eveonline.com/Alliance/503818424_128.png", allianceIcons.Px128X128);
        }

        [Fact]
        public async Task IconsAsync_successfully_return_a_AllianceIcons()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\"px64x64\": \"https://imageserver.eveonline.com/Alliance/503818424_64.png\",\"px128x128\": \"https://imageserver.eveonline.com/Alliance/503818424_128.png\"}";

            int allianceId = 8762;

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestAlliance internalLatestAlliance = new InternalLatestAlliance(mockedWebClient.Object, string.Empty);

            V1AllianceIcons allianceIcons = await internalLatestAlliance.IconsAsync(allianceId);

            Assert.Equal("https://imageserver.eveonline.com/Alliance/503818424_64.png", allianceIcons.Px64X64);
            Assert.Equal("https://imageserver.eveonline.com/Alliance/503818424_128.png", allianceIcons.Px128X128);
        }
    }
}
