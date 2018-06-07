﻿using System;
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
        public void GetActiveAlliances_Successfully_returns_a_list_of_AllianceIds()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[99000001,99000002]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel{Model = json});

            InternalLatestAlliance internalLatestAlliance = new InternalLatestAlliance(mockedWebClient.Object, string.Empty);

            IList<int> allianceIds = internalLatestAlliance.GetActiveAlliances();

            Assert.Equal(2, allianceIds.Count);
        }

        [Fact]
        public async Task GetActiveAlliancesAsync_Successfully_returns_a_list_of_AllianceIds()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[99000001,99000002]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestAlliance internalLatestAlliance = new InternalLatestAlliance(mockedWebClient.Object, string.Empty);

            IList<int> allianceIds = await internalLatestAlliance.GetActiveAlliancesAsync();

            Assert.Equal(2, allianceIds.Count);
        }

        [Fact]
        public void GetPublicAllianceInfo_Successfully_returns_a_GetPublicAlliance()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\"name\": \"C C P Alliance\",\"ticker\": \"<C C P>\",\"creator_id\": 12345,\"creator_corporation_id\": 45678,\"executor_corporation_id\": 98356193,\"date_founded\": \"2016-06-26T21:00:00Z\"}";

            int allianceId = 8762;

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestAlliance internalLatestAlliance = new InternalLatestAlliance(mockedWebClient.Object, string.Empty);

            V3GetPublicAlliance allianceInfo = internalLatestAlliance.GetPublicAllianceInfo(allianceId);

            Assert.Equal("C C P Alliance", allianceInfo.Name);
            Assert.Equal(DateTime.Parse("2016-06-26T21:00:00"), allianceInfo.DateFounded);
        }

        [Fact]
        public async Task GetPublicAllianceInfoAsync_Successfully_returns_a_GetPublicAlliance()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\"name\": \"C C P Alliance\",\"ticker\": \"<C C P>\",\"creator_id\": 12345,\"creator_corporation_id\": 45678,\"executor_corporation_id\": 98356193,\"date_founded\": \"2016-06-26T21:00:00Z\"}";

            int allianceId = 8762;

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestAlliance internalLatestAlliance = new InternalLatestAlliance(mockedWebClient.Object, string.Empty);

            V3GetPublicAlliance allianceInfo = await internalLatestAlliance.GetPublicAllianceInfoAsync(allianceId);

            Assert.Equal("C C P Alliance", allianceInfo.Name);
            Assert.Equal(DateTime.Parse("2016-06-26T21:00:00"), allianceInfo.DateFounded);
        }

        [Fact]
        public void GetAllianceCorporations_successfully_return_a_list_of_ints()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[98000001]";

            int allianceId = 8762;

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestAlliance internalLatestAlliance = new InternalLatestAlliance(mockedWebClient.Object, string.Empty);

            IList<int> corporationIds = internalLatestAlliance.GetAllianceCorporation(allianceId);

            Assert.Equal(98000001, corporationIds.First());
            Assert.Single(corporationIds);
        }

        [Fact]
        public async Task GetAllianceCorporationsAsync_successfully_return_a_list_of_ints()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[98000001]";

            int allianceId = 8762;

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestAlliance internalLatestAlliance = new InternalLatestAlliance(mockedWebClient.Object, string.Empty);

            IList<int> corporationIds = await internalLatestAlliance.GetAllianceCorporationAsync(allianceId);

            Assert.Equal(98000001, corporationIds.First());
            Assert.Single(corporationIds);
        }

        [Fact]
        public void GetAllianceIcons_sucessfully_return_a_AllianceIcons()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\"px64x64\": \"https://imageserver.eveonline.com/Alliance/503818424_64.png\",\"px128x128\": \"https://imageserver.eveonline.com/Alliance/503818424_128.png\"}";

            int allianceId = 8762;

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestAlliance internalLatestAlliance = new InternalLatestAlliance(mockedWebClient.Object, string.Empty);

            V1AllianceIcons allianceIcons = internalLatestAlliance.GetAllianceIcons(allianceId);

            Assert.Equal("https://imageserver.eveonline.com/Alliance/503818424_64.png", allianceIcons.Px64X64);
            Assert.Equal("https://imageserver.eveonline.com/Alliance/503818424_128.png", allianceIcons.Px128X128);
        }

        [Fact]
        public async Task GetAllianceIconsAsync_sucessfully_return_a_AllianceIcons()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\"px64x64\": \"https://imageserver.eveonline.com/Alliance/503818424_64.png\",\"px128x128\": \"https://imageserver.eveonline.com/Alliance/503818424_128.png\"}";

            int allianceId = 8762;

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestAlliance internalLatestAlliance = new InternalLatestAlliance(mockedWebClient.Object, string.Empty);

            V1AllianceIcons allianceIcons = await internalLatestAlliance.GetAllianceIconsAsync(allianceId);

            Assert.Equal("https://imageserver.eveonline.com/Alliance/503818424_64.png", allianceIcons.Px64X64);
            Assert.Equal("https://imageserver.eveonline.com/Alliance/503818424_128.png", allianceIcons.Px128X128);
        }

        [Fact]
        public void GetAllianceNamesFromIds_successfully_returns_a_list_of_allianceIdsToNames()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[{\"alliance_id\": 1000171,\"alliance_name\": \"Republic University\"}]";

            IList<int> allianceIds = new List<int> { 8762 };

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestAlliance internalLatestAlliance = new InternalLatestAlliance(mockedWebClient.Object, string.Empty);

            IList<V2AllianceIdsToNames> allianceNames = internalLatestAlliance.GetAllianceNamesFromIds(allianceIds);

            Assert.Single(allianceNames);
            Assert.Equal("Republic University", allianceNames.First().AllianceName);
            Assert.Equal(1000171, allianceNames.First().AllianceId);
        }

        [Fact]
        public async Task GetAllianceNamesFromIdsAsync_successfully_returns_a_list_of_allianceIdsToNames()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[{\"alliance_id\": 1000171,\"alliance_name\": \"Republic University\"}]";

            IList<int> allianceIds = new List<int> { 8762 };

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestAlliance internalLatestAlliance = new InternalLatestAlliance(mockedWebClient.Object, string.Empty);

            IList<V2AllianceIdsToNames> allianceNames = await internalLatestAlliance.GetAllianceNamesFromIdsAsync(allianceIds);

            Assert.Single(allianceNames);
            Assert.Equal("Republic University", allianceNames.First().AllianceName);
            Assert.Equal(1000171, allianceNames.First().AllianceId);
        }
    }
}
