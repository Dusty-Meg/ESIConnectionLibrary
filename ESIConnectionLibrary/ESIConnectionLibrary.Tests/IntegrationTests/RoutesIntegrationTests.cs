using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;
using ESIConnectionLibrary.Public_classes;
using Xunit;

namespace ESIConnectionLibrary.Tests.IntegrationTests
{
    public class RoutesIntegrationTests
    {
        [Fact]
        public void Route_successfully_returns_a_listint()
        {
            LatestRoutesEndpoints internalLatestRoutes = new LatestRoutesEndpoints(string.Empty, true);

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
            LatestRoutesEndpoints internalLatestRoutes = new LatestRoutesEndpoints(string.Empty, true);

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
