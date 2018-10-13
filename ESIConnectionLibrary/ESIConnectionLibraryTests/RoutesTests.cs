using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;
using Moq;
using Xunit;

namespace ESIConnectionLibraryTests
{
    public class RoutesTests
    {
        [Fact]
        public void Route_successfully_returns_a_listint()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  30002771,\r\n  30002770,\r\n  30002769,\r\n  30002772\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestRoutes internalLatestRoutes = new InternalLatestRoutes(mockedWebClient.Object, string.Empty);

            IList<int> returnModel = internalLatestRoutes.Route(2, 2, V1RoutesFlag.Secure, null, null);

            Assert.NotNull(returnModel);

            Assert.Equal(4, returnModel.Count);

            Assert.Equal(30002771, returnModel[0]);
            Assert.Equal(30002770, returnModel[1]);
            Assert.Equal(30002769, returnModel[2]);
            Assert.Equal(30002772, returnModel[3]);
        }
        [Fact]
        public async Task RouteAsync_successfully_returns_a_listint()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  30002771,\r\n  30002770,\r\n  30002769,\r\n  30002772\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestRoutes internalLatestRoutes = new InternalLatestRoutes(mockedWebClient.Object, string.Empty);

            IList<int> returnModel = await internalLatestRoutes.RouteAsync(2, 2, V1RoutesFlag.Secure, null, null);

            Assert.NotNull(returnModel);

            Assert.Equal(4, returnModel.Count);

            Assert.Equal(30002771, returnModel[0]);
            Assert.Equal(30002770, returnModel[1]);
            Assert.Equal(30002769, returnModel[2]);
            Assert.Equal(30002772, returnModel[3]);
        }
    }
}
