using System;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;
using ESIConnectionLibrary.Public_classes;
using Xunit;

namespace ESIConnectionLibraryTests.IntegrationTests
{
    public class StatusIntergrationTests
    {
        [Fact]
        public void Status_successfully_returns_a_status()
        {
            LatestStatusEndpoints internalLatestStatus = new LatestStatusEndpoints(string.Empty, true);

            V1Status response = internalLatestStatus.Status();

            Assert.Equal(12345, response.Players);
            Assert.Equal("1132976", response.ServerVersion);
            Assert.Equal(new DateTime(2017, 01, 02, 12, 34, 56), response.StartTime);
        }

        [Fact]
        public async Task StatusAsync_successfully_returns_a_status()
        {
            LatestStatusEndpoints internalLatestStatus = new LatestStatusEndpoints(string.Empty, true);

            V1Status response = await internalLatestStatus.StatusAsync();

            Assert.Equal(12345, response.Players);
            Assert.Equal("1132976", response.ServerVersion);
            Assert.Equal(new DateTime(2017, 01, 02, 12, 34, 56), response.StartTime);
        }
    }
}
