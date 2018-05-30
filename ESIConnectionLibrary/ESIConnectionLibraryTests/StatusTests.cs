using System;
using System.Net;
using System.Threading.Tasks;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;
using Moq;
using Xunit;

namespace ESIConnectionLibraryTests
{
    public class StatusTests
    {
        [Fact]
        public void GetStatus_successully_returns_a_status()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\r\n  \"players\": 12345,\r\n  \"server_version\": \"1132976\",\r\n  \"start_time\": \"2017-01-02T12:34:56Z\"\r\n}";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(json);

            InternalLatestStatus internalLatestStatus = new InternalLatestStatus(mockedWebClient.Object, string.Empty);

            V1Status response = internalLatestStatus.GetStatus();

            Assert.Equal(12345, response.Players);
            Assert.Equal("1132976", response.ServerVersion);
            Assert.Equal(new DateTime(2017, 01, 02, 12, 34, 56), response.StartTime);
        }

        [Fact]
        public async Task GetStatusAsync_successully_returns_a_status()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "{\r\n  \"players\": 12345,\r\n  \"server_version\": \"1132976\",\r\n  \"start_time\": \"2017-01-02T12:34:56Z\"\r\n}";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(json);

            InternalLatestStatus internalLatestStatus = new InternalLatestStatus(mockedWebClient.Object, string.Empty);

            V1Status response = await internalLatestStatus.GetStatusAsync();

            Assert.Equal(12345, response.Players);
            Assert.Equal("1132976", response.ServerVersion);
            Assert.Equal(new DateTime(2017, 01, 02, 12, 34, 56), response.StartTime);
        }
    }
}
