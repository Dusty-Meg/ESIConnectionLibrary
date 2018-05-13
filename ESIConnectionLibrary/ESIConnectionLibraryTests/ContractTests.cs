using System;
using System.Net;
using System.Threading.Tasks;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;
using Moq;
using Xunit;

namespace ESIConnectionLibraryTests
{
    public class ContractTests
    {
        [Fact]
        public void GetCharactersContracts_successfully_returns_a_pagedModelV1ContractsGetContracts()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            int page = 1;
            ContractScopes scopes = ContractScopes.esi_contracts_read_character_contracts_v1;

            SsoToken inputToken = new SsoToken {AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, ContractScopesFlags = scopes};
            string getCharactersContractsJson = "[{\"acceptor_id\": 0,\"assignee_id\": 0,\"availability\": \"alliance\",\"buyout\": 10000000000.01,\"contract_id\": 1,\"date_accepted\": \"2017-06-06T13:12:32Z\",\"date_completed\": \"2017-06-06T13:12:32Z\",\"date_expired\": \"2017-06-13T13:12:32Z\",\"date_issued\": \"2017-06-06T13:12:32Z\",\"days_to_complete\": 0,\"end_location_id\": 60014719,\"for_corporation\": true,\"issuer_corporation_id\": 456,\"issuer_id\": 123,\"price\": 1000000.01,\"reward\": 0.01,\"start_location_id\": 60014719,\"status\": \"in_progress\",\"type\": \"auction\",\"volume\": 0.01}]";

            PagedJson pagedJson = new PagedJson{ Response = getCharactersContractsJson, MaxPages = 2 };

            mockedWebClient.Setup(x => x.GetPaged(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(pagedJson);

            InternalLatestContracts internalLatestContracts = new InternalLatestContracts(mockedWebClient.Object, string.Empty);

            PagedModel<V1ContractsCharacterContracts> getCharactersContracts = internalLatestContracts.GetCharactersContracts(inputToken, characterId, page);

            Assert.Equal(1, getCharactersContracts.Model.Count);
            Assert.Equal(2, getCharactersContracts.MaxPages);
            Assert.Equal(ContractsAvailability.alliance, getCharactersContracts.Model[0].Availability);
            Assert.Equal(ContractsStatus.in_progress, getCharactersContracts.Model[0].Status);
            Assert.Equal(ContractsType.auction, getCharactersContracts.Model[0].Type);
            Assert.Equal(new DateTime(2017,06,06,13,12,32), getCharactersContracts.Model[0].DateAccepted);
            Assert.Equal(0.01, getCharactersContracts.Model[0].Reward);
            Assert.Equal(0.01, getCharactersContracts.Model[0].Volume);
        }

        [Fact]
        public async Task GetCharactersContractsAsync_successfully_returns_a_pagedModelV1ContractsGetContracts()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            int page = 1;
            ContractScopes scopes = ContractScopes.esi_contracts_read_character_contracts_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, ContractScopesFlags = scopes };
            string getCharactersContractsJson = "[{\"acceptor_id\": 0,\"assignee_id\": 0,\"availability\": \"alliance\",\"buyout\": 10000000000.01,\"contract_id\": 1,\"date_accepted\": \"2017-06-06T13:12:32Z\",\"date_completed\": \"2017-06-06T13:12:32Z\",\"date_expired\": \"2017-06-13T13:12:32Z\",\"date_issued\": \"2017-06-06T13:12:32Z\",\"days_to_complete\": 0,\"end_location_id\": 60014719,\"for_corporation\": true,\"issuer_corporation_id\": 456,\"issuer_id\": 123,\"price\": 1000000.01,\"reward\": 0.01,\"start_location_id\": 60014719,\"status\": \"in_progress\",\"type\": \"auction\",\"volume\": 0.01}]";

            PagedJson pagedJson = new PagedJson { Response = getCharactersContractsJson, MaxPages = 2 };

            mockedWebClient.Setup(x => x.GetPagedAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(pagedJson);

            InternalLatestContracts internalLatestContracts = new InternalLatestContracts(mockedWebClient.Object, string.Empty);

            PagedModel<V1ContractsCharacterContracts> getCharactersContracts = await internalLatestContracts.GetCharactersContractsAsync(inputToken, characterId, page);

            Assert.Equal(1, getCharactersContracts.Model.Count);
            Assert.Equal(2, getCharactersContracts.MaxPages);
            Assert.Equal(ContractsAvailability.alliance, getCharactersContracts.Model[0].Availability);
            Assert.Equal(ContractsStatus.in_progress, getCharactersContracts.Model[0].Status);
            Assert.Equal(ContractsType.auction, getCharactersContracts.Model[0].Type);
            Assert.Equal(new DateTime(2017, 06, 06, 13, 12, 32), getCharactersContracts.Model[0].DateAccepted);
            Assert.Equal(0.01, getCharactersContracts.Model[0].Reward);
            Assert.Equal(0.01, getCharactersContracts.Model[0].Volume);
        }
    }
}
