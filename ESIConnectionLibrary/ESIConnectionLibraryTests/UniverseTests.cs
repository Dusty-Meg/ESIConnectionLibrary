using System.Collections.Generic;
using System.Linq;
using System.Net;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;
using Moq;
using Xunit;

namespace ESIConnectionLibraryTests
{
    public class UniverseTests
    {
        [Fact]
        public void GetNames_successfully_returns_a_list_of_Names()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string universeNamesJson = "[{\"category\": \"character\",\"id\": 95465499,\"name\": \"CCP Bartender\"},{\"category\": \"solar_system\",\"id\": 30000142,\"name\": \"Jita\"}]";

            mockedWebClient.Setup(x => x.Post(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>())).Returns(universeNamesJson);

            InternalUniverse internalUniverse = new InternalUniverse(mockedWebClient.Object, string.Empty);

            IList<UniverseNames> universeNames = internalUniverse.GetNames(new List<int>());

            Assert.Equal(2, universeNames.Count);
            Assert.Equal("character", universeNames.First().Category);
            Assert.Equal(95465499, universeNames.First().Id);
            Assert.Equal("CCP Bartender", universeNames.First().Name);
        }
    }
}
