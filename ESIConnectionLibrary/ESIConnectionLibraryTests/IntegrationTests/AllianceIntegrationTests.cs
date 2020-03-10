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
        public void Alliances_Successfully_returns_a_list_of_AllianceIds()
        {
            LatestAllianceEndpoints internalLatestAlliance = new LatestAllianceEndpoints(string.Empty, true);

            IList<int> allianceIds = internalLatestAlliance.Alliances();

            Assert.Equal(2, allianceIds.Count);
        }

        [Fact]
        public async Task AlliancesAsync_Successfully_returns_a_list_of_AllianceIds()
        {
            LatestAllianceEndpoints latestAlliance = new LatestAllianceEndpoints(string.Empty, true);

            IList<int> allianceIds = await latestAlliance.AlliancesAsync();

            Assert.Equal(2, allianceIds.Count);
        }

        [Fact]
        public void PublicInfo_Successfully_returns_a_GetPublicAlliance()
        {
            int allianceId = 8762;

            LatestAllianceEndpoints latestAlliance = new LatestAllianceEndpoints(string.Empty, true);

            V3AlliancePublicInfo infoInfo = latestAlliance.PublicInfo(allianceId);

            Assert.Equal("C C P Alliance", infoInfo.Name);
            Assert.Equal(DateTime.Parse("2016-06-26T21:00:00"), infoInfo.DateFounded);
        }

        [Fact]
        public async Task PublicInfoAsync_Successfully_returns_a_GetPublicAlliance()
        {
            int allianceId = 8762;

            LatestAllianceEndpoints latestAlliance = new LatestAllianceEndpoints(string.Empty, true);

            V3AlliancePublicInfo infoInfo = await latestAlliance.PublicInfoAsync(allianceId);

            Assert.Equal("C C P Alliance", infoInfo.Name);
            Assert.Equal(DateTime.Parse("2016-06-26T21:00:00"), infoInfo.DateFounded);
        }

        [Fact]
        public void Corporations_successfully_return_a_list_of_ints()
        {
            int allianceId = 8762;

            LatestAllianceEndpoints latestAlliance = new LatestAllianceEndpoints(string.Empty, true);

            IList<int> corporationIds = latestAlliance.Corporations(allianceId);

            Assert.Equal(98000001, corporationIds.First());
            Assert.Single(corporationIds);
        }

        [Fact]
        public async Task CorporationsAsync_successfully_return_a_list_of_ints()
        {
            int allianceId = 8762;

            LatestAllianceEndpoints latestAlliance = new LatestAllianceEndpoints(string.Empty, true);

            IList<int> corporationIds = await latestAlliance.CorporationsAsync(allianceId);

            Assert.Equal(98000001, corporationIds.First());
            Assert.Single(corporationIds);
        }

        [Fact]
        public void Icons_successfully_return_a_AllianceIcons()
        {
            int allianceId = 8762;

            LatestAllianceEndpoints latestAlliance = new LatestAllianceEndpoints(string.Empty, true);

            V1AllianceIcons allianceIcons = latestAlliance.Icons(allianceId);

            Assert.Equal("https://images.evetech.net/Alliance/503818424_64.png", allianceIcons.Px64X64);
            Assert.Equal("https://images.evetech.net/Alliance/503818424_128.png", allianceIcons.Px128X128);
        }

        [Fact]
        public async Task IconsAsync_successfully_return_a_AllianceIcons()
        {
            int allianceId = 8762;

            LatestAllianceEndpoints latestAlliance = new LatestAllianceEndpoints(string.Empty, true);

            V1AllianceIcons allianceIcons = await latestAlliance.IconsAsync(allianceId);

            Assert.Equal("https://images.evetech.net/Alliance/503818424_64.png", allianceIcons.Px64X64);
            Assert.Equal("https://images.evetech.net/Alliance/503818424_128.png", allianceIcons.Px128X128);
        }
    }
}
