using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;
using Moq;
using Xunit;

namespace ESIConnectionLibraryTests
{
    public class FittingsTests
    {
        [Fact]
        public void Character_successfully_returns_a_list_of_fittings()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            FittingScopes scopes = FittingScopes.esi_fittings_read_fittings_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, FittingScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"description\": \"Awesome Vindi fitting\",\r\n    \"fitting_id\": 1,\r\n    \"items\": [\r\n      {\r\n        \"flag\": 12,\r\n        \"quantity\": 1,\r\n        \"type_id\": 1234\r\n      }\r\n    ],\r\n    \"name\": \"Best Vindicator\",\r\n    \"ship_type_id\": 123\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestFittings internalLatestFittings = new InternalLatestFittings(mockedWebClient.Object, string.Empty);

            IList<V1FittingsCharacter> model = internalLatestFittings.Character(inputToken);

            Assert.Single(model);
            Assert.Equal("Awesome Vindi fitting", model[0].Description);
            Assert.Equal(1, model[0].FittingId);

            Assert.Single(model[0].Items);
            Assert.Equal(12, model[0].Items[0].Flag);
            Assert.Equal(1, model[0].Items[0].Quantity);
            Assert.Equal(1234, model[0].Items[0].TypeId);

            Assert.Equal("Best Vindicator", model[0].Name);
            Assert.Equal(123, model[0].ShipTypeId);
        }
        [Fact]
        public async Task CharacterAsync_successfully_returns_a_list_of_fittings()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 828658;
            string characterName = "ThisIsACharacter";
            FittingScopes scopes = FittingScopes.esi_fittings_read_fittings_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, CharacterName = characterName, FittingScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"description\": \"Awesome Vindi fitting\",\r\n    \"fitting_id\": 1,\r\n    \"items\": [\r\n      {\r\n        \"flag\": 12,\r\n        \"quantity\": 1,\r\n        \"type_id\": 1234\r\n      }\r\n    ],\r\n    \"name\": \"Best Vindicator\",\r\n    \"ship_type_id\": 123\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestFittings internalLatestFittings = new InternalLatestFittings(mockedWebClient.Object, string.Empty);

            IList<V1FittingsCharacter> model = await internalLatestFittings.CharacterAsync(inputToken);

            Assert.Single(model);
            Assert.Equal("Awesome Vindi fitting", model[0].Description);
            Assert.Equal(1, model[0].FittingId);

            Assert.Single(model[0].Items);
            Assert.Equal(12, model[0].Items[0].Flag);
            Assert.Equal(1, model[0].Items[0].Quantity);
            Assert.Equal(1234, model[0].Items[0].TypeId);

            Assert.Equal("Best Vindicator", model[0].Name);
            Assert.Equal(123, model[0].ShipTypeId);
        }
    }
}
