using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;
using ESIConnectionLibrary.Public_classes;
using Xunit;

namespace ESIConnectionLibraryTests.IntegrationTests
{
    public class AllianceIntegrationTests
    {
        [Fact]
        public void GetActiveAlliances_Successfully_returns_a_list_of_AllianceIds()
        {
            LatestAllianceEndpoints internalLatestAlliance = new LatestAllianceEndpoints(string.Empty, true);

            IList<int> allianceIds = internalLatestAlliance.GetActiveAlliances();

            Assert.Equal(2, allianceIds.Count);
        }

        [Fact]
        public async Task GetActiveAlliancesAsync_Successfully_returns_a_list_of_AllianceIds()
        {
            LatestAllianceEndpoints latestAlliance = new LatestAllianceEndpoints(string.Empty, true);

            IList<int> allianceIds = await latestAlliance.GetActiveAlliancesAsync();

            Assert.Equal(2, allianceIds.Count);
        }

        [Fact]
        public void GetPublicAllianceInfo_Successfully_returns_a_GetPublicAlliance()
        {
            int allianceId = 8762;

            LatestAllianceEndpoints latestAlliance = new LatestAllianceEndpoints(string.Empty, true);

            V3GetPublicAlliance allianceInfo = latestAlliance.GetPublicAllianceInfo(allianceId);

            Assert.Equal("C C P Alliance", allianceInfo.Name);
            Assert.Equal(DateTime.Parse("2016-06-26T21:00:00"), allianceInfo.DateFounded);
        }

        [Fact]
        public async Task GetPublicAllianceInfoAsync_Successfully_returns_a_GetPublicAlliance()
        {
            int allianceId = 8762;

            LatestAllianceEndpoints latestAlliance = new LatestAllianceEndpoints(string.Empty, true);

            V3GetPublicAlliance allianceInfo = await latestAlliance.GetPublicAllianceInfoAsync(allianceId);

            Assert.Equal("C C P Alliance", allianceInfo.Name);
            Assert.Equal(DateTime.Parse("2016-06-26T21:00:00"), allianceInfo.DateFounded);
        }

        [Fact]
        public void GetAllianceCorporations_successfully_return_a_list_of_ints()
        {
            int allianceId = 8762;

            LatestAllianceEndpoints latestAlliance = new LatestAllianceEndpoints(string.Empty, true);

            IList<int> corporationIds = latestAlliance.GetAllianceCorporation(allianceId);

            Assert.Equal(98000001, corporationIds.First());
            Assert.Single(corporationIds);
        }

        [Fact]
        public async Task GetAllianceCorporationsAsync_successfully_return_a_list_of_ints()
        {
            int allianceId = 8762;

            LatestAllianceEndpoints latestAlliance = new LatestAllianceEndpoints(string.Empty, true);

            IList<int> corporationIds = await latestAlliance.GetAllianceCorporationAsync(allianceId);

            Assert.Equal(98000001, corporationIds.First());
            Assert.Single(corporationIds);
        }

        [Fact]
        public void GetAllianceIcons_sucessfully_return_a_AllianceIcons()
        {
            int allianceId = 8762;

            LatestAllianceEndpoints latestAlliance = new LatestAllianceEndpoints(string.Empty, true);

            V1AllianceIcons allianceIcons = latestAlliance.GetAllianceIcons(allianceId);

            Assert.Equal("https://imageserver.eveonline.com/Alliance/503818424_64.png", allianceIcons.Px64X64);
            Assert.Equal("https://imageserver.eveonline.com/Alliance/503818424_128.png", allianceIcons.Px128X128);
        }

        [Fact]
        public async Task GetAllianceIconsAsync_sucessfully_return_a_AllianceIcons()
        {
            int allianceId = 8762;

            LatestAllianceEndpoints latestAlliance = new LatestAllianceEndpoints(string.Empty, true);

            V1AllianceIcons allianceIcons = await latestAlliance.GetAllianceIconsAsync(allianceId);

            Assert.Equal("https://imageserver.eveonline.com/Alliance/503818424_64.png", allianceIcons.Px64X64);
            Assert.Equal("https://imageserver.eveonline.com/Alliance/503818424_128.png", allianceIcons.Px128X128);
        }
    }
}
