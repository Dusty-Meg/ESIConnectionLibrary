using System;
using System.Collections.Generic;
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
        public void Character_successfully_returns_a_pagedModelV1ContractsCharacter()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            int page = 1;
            ContractScopes scopes = ContractScopes.esi_contracts_read_character_contracts_v1;

            SsoToken inputToken = new SsoToken {AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, ContractScopesFlags = scopes};
            string json = "[\r\n  {\r\n    \"acceptor_id\": 0,\r\n    \"assignee_id\": 0,\r\n    \"availability\": \"public\",\r\n    \"buyout\": 10000000000.01,\r\n    \"contract_id\": 1,\r\n    \"date_accepted\": \"2017-06-06T13:12:32Z\",\r\n    \"date_completed\": \"2017-06-06T13:12:32Z\",\r\n    \"date_expired\": \"2017-06-13T13:12:32Z\",\r\n    \"date_issued\": \"2017-06-06T13:12:32Z\",\r\n    \"days_to_complete\": 0,\r\n    \"end_location_id\": 60014719,\r\n    \"for_corporation\": true,\r\n    \"issuer_corporation_id\": 456,\r\n    \"issuer_id\": 123,\r\n    \"price\": 1000000.01,\r\n    \"reward\": 0.01,\r\n    \"start_location_id\": 60014719,\r\n    \"status\": \"outstanding\",\r\n    \"type\": \"auction\",\r\n    \"volume\": 0.01\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json, MaxPages = 2 });

            InternalLatestContracts internalLatestContracts = new InternalLatestContracts(mockedWebClient.Object, string.Empty);

            PagedModel<V1ContractsCharacter> esiModel = internalLatestContracts.Character(inputToken, page);

            Assert.Equal(1, esiModel.Model.Count);
            Assert.Equal(2, esiModel.MaxPages);
            Assert.Equal(0, esiModel.Model[0].AcceptorId);
            Assert.Equal(0, esiModel.Model[0].AssigneeId);
            Assert.Equal(V1ContractsCharacterAvailability.Public, esiModel.Model[0].Availability);
            Assert.Equal(10000000000.01, esiModel.Model[0].Buyout);
            Assert.Equal(1, esiModel.Model[0].ContractId);
            Assert.Equal(new DateTime(2017, 06, 06, 13, 12, 32), esiModel.Model[0].DateAccepted);
            Assert.Equal(new DateTime(2017, 06, 06, 13, 12, 32), esiModel.Model[0].DateCompleted);
            Assert.Equal(new DateTime(2017, 06, 13, 13, 12, 32), esiModel.Model[0].DateExpired);
            Assert.Equal(new DateTime(2017, 06, 06, 13, 12, 32), esiModel.Model[0].DateIssued);
            Assert.Equal(0, esiModel.Model[0].DaysToComplete);
            Assert.Equal(60014719, esiModel.Model[0].EndLocationId);
            Assert.True(esiModel.Model[0].ForCorporation);
            Assert.Equal(456, esiModel.Model[0].IssuerCorporationId);
            Assert.Equal(123, esiModel.Model[0].IssuerId);
            Assert.Equal(1000000.01, esiModel.Model[0].Price);
            Assert.Equal(0.01, esiModel.Model[0].Reward);
            Assert.Equal(60014719, esiModel.Model[0].StartLocationId);
            Assert.Equal(V1ContractsCharacterStatus.Outstanding, esiModel.Model[0].Status);
            Assert.Equal(V1ContractsCharacterType.Auction, esiModel.Model[0].Type);
            Assert.Equal(0.01, esiModel.Model[0].Volume);
        }

        [Fact]
        public async Task CharacterAsync_successfully_returns_a_pagedModelV1ContractsCharacter()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            int page = 1;
            ContractScopes scopes = ContractScopes.esi_contracts_read_character_contracts_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, ContractScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"acceptor_id\": 0,\r\n    \"assignee_id\": 0,\r\n    \"availability\": \"public\",\r\n    \"buyout\": 10000000000.01,\r\n    \"contract_id\": 1,\r\n    \"date_accepted\": \"2017-06-06T13:12:32Z\",\r\n    \"date_completed\": \"2017-06-06T13:12:32Z\",\r\n    \"date_expired\": \"2017-06-13T13:12:32Z\",\r\n    \"date_issued\": \"2017-06-06T13:12:32Z\",\r\n    \"days_to_complete\": 0,\r\n    \"end_location_id\": 60014719,\r\n    \"for_corporation\": true,\r\n    \"issuer_corporation_id\": 456,\r\n    \"issuer_id\": 123,\r\n    \"price\": 1000000.01,\r\n    \"reward\": 0.01,\r\n    \"start_location_id\": 60014719,\r\n    \"status\": \"outstanding\",\r\n    \"type\": \"auction\",\r\n    \"volume\": 0.01\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json, MaxPages = 2 });

            InternalLatestContracts internalLatestContracts = new InternalLatestContracts(mockedWebClient.Object, string.Empty);

            PagedModel<V1ContractsCharacter> esiModel = await internalLatestContracts.CharacterAsync(inputToken, page);

            Assert.Equal(1, esiModel.Model.Count);
            Assert.Equal(2, esiModel.MaxPages);
            Assert.Equal(0, esiModel.Model[0].AcceptorId);
            Assert.Equal(0, esiModel.Model[0].AssigneeId);
            Assert.Equal(V1ContractsCharacterAvailability.Public, esiModel.Model[0].Availability);
            Assert.Equal(10000000000.01, esiModel.Model[0].Buyout);
            Assert.Equal(1, esiModel.Model[0].ContractId);
            Assert.Equal(new DateTime(2017, 06, 06, 13, 12, 32), esiModel.Model[0].DateAccepted);
            Assert.Equal(new DateTime(2017, 06, 06, 13, 12, 32), esiModel.Model[0].DateCompleted);
            Assert.Equal(new DateTime(2017, 06, 13, 13, 12, 32), esiModel.Model[0].DateExpired);
            Assert.Equal(new DateTime(2017, 06, 06, 13, 12, 32), esiModel.Model[0].DateIssued);
            Assert.Equal(0, esiModel.Model[0].DaysToComplete);
            Assert.Equal(60014719, esiModel.Model[0].EndLocationId);
            Assert.True(esiModel.Model[0].ForCorporation);
            Assert.Equal(456, esiModel.Model[0].IssuerCorporationId);
            Assert.Equal(123, esiModel.Model[0].IssuerId);
            Assert.Equal(1000000.01, esiModel.Model[0].Price);
            Assert.Equal(0.01, esiModel.Model[0].Reward);
            Assert.Equal(60014719, esiModel.Model[0].StartLocationId);
            Assert.Equal(V1ContractsCharacterStatus.Outstanding, esiModel.Model[0].Status);
            Assert.Equal(V1ContractsCharacterType.Auction, esiModel.Model[0].Type);
            Assert.Equal(0.01, esiModel.Model[0].Volume);
        }

        [Fact]
        public void CharacterBids_successfully_returns_a_IListV1ContractsCharacterBids()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            ContractScopes scopes = ContractScopes.esi_contracts_read_character_contracts_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, ContractScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"amount\": 1.23,\r\n    \"bid_id\": 1,\r\n    \"bidder_id\": 123,\r\n    \"date_bid\": \"2017-01-01T10:10:10Z\"\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestContracts internalLatestContracts = new InternalLatestContracts(mockedWebClient.Object, string.Empty);

            IList<V1ContractsCharacterBids> esiModel = internalLatestContracts.CharacterBids(inputToken, 44);

            Assert.Equal(1.23f, esiModel[0].Amount);
            Assert.Equal(1, esiModel[0].BidId);
            Assert.Equal(123, esiModel[0].BidderId);
            Assert.Equal(new DateTime(2017, 01, 01, 10, 10, 10), esiModel[0].DateBid);
        }

        [Fact]
        public async Task CharacterBidsAsync_successfully_returns_a_IListV1ContractsCharacterBids()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            ContractScopes scopes = ContractScopes.esi_contracts_read_character_contracts_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, ContractScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"amount\": 1.23,\r\n    \"bid_id\": 1,\r\n    \"bidder_id\": 123,\r\n    \"date_bid\": \"2017-01-01T10:10:10Z\"\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestContracts internalLatestContracts = new InternalLatestContracts(mockedWebClient.Object, string.Empty);

            IList<V1ContractsCharacterBids> esiModel = await internalLatestContracts.CharacterBidsAsync(inputToken, 44);

            Assert.Equal(1.23f, esiModel[0].Amount);
            Assert.Equal(1, esiModel[0].BidId);
            Assert.Equal(123, esiModel[0].BidderId);
            Assert.Equal(new DateTime(2017, 01, 01, 10, 10, 10), esiModel[0].DateBid);
        }

        [Fact]
        public void CharacterItems_successfully_returns_a_IListV1ContractsCharacterItems()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            ContractScopes scopes = ContractScopes.esi_contracts_read_character_contracts_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, ContractScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"is_included\": true,\r\n    \"is_singleton\": false,\r\n    \"quantity\": 1,\r\n    \"record_id\": 123456,\r\n    \"type_id\": 587\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestContracts internalLatestContracts = new InternalLatestContracts(mockedWebClient.Object, string.Empty);

            IList<V1ContractsCharacterItems> esiModel = internalLatestContracts.CharacterItems(inputToken, 44);

            Assert.True(esiModel[0].IsIncluded);
            Assert.False(esiModel[0].IsSingleton);
            Assert.Equal(1, esiModel[0].Quantity);
            Assert.Equal(123456, esiModel[0].RecordId);
            Assert.Equal(587, esiModel[0].TypeId);
        }

        [Fact]
        public async Task CharacterItemsAsync_successfully_returns_a_IListV1ContractsCharacterItems()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            ContractScopes scopes = ContractScopes.esi_contracts_read_character_contracts_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, ContractScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"is_included\": true,\r\n    \"is_singleton\": false,\r\n    \"quantity\": 1,\r\n    \"record_id\": 123456,\r\n    \"type_id\": 587\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestContracts internalLatestContracts = new InternalLatestContracts(mockedWebClient.Object, string.Empty);

            IList<V1ContractsCharacterItems> esiModel = await internalLatestContracts.CharacterItemsAsync(inputToken, 44);

            Assert.True(esiModel[0].IsIncluded);
            Assert.False(esiModel[0].IsSingleton);
            Assert.Equal(1, esiModel[0].Quantity);
            Assert.Equal(123456, esiModel[0].RecordId);
            Assert.Equal(587, esiModel[0].TypeId);
        }

        [Fact]
        public void Corporation_successfully_returns_a_pagedModelV1ContractsCorporation()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            int page = 1;
            ContractScopes scopes = ContractScopes.esi_contracts_read_corporation_contracts_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, ContractScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"acceptor_id\": 0,\r\n    \"assignee_id\": 0,\r\n    \"availability\": \"public\",\r\n    \"buyout\": 10000000000.01,\r\n    \"contract_id\": 1,\r\n    \"date_expired\": \"2017-06-13T13:12:32Z\",\r\n    \"date_issued\": \"2017-06-06T13:12:32Z\",\r\n    \"days_to_complete\": 0,\r\n    \"end_location_id\": 60014719,\r\n    \"for_corporation\": true,\r\n    \"issuer_corporation_id\": 456,\r\n    \"issuer_id\": 123,\r\n    \"price\": 1000000.01,\r\n    \"reward\": 0.01,\r\n    \"start_location_id\": 60014719,\r\n    \"status\": \"outstanding\",\r\n    \"type\": \"auction\",\r\n    \"volume\": 0.01\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json, MaxPages = 2 });

            InternalLatestContracts internalLatestContracts = new InternalLatestContracts(mockedWebClient.Object, string.Empty);

            PagedModel<V1ContractsCorporation> esiModel = internalLatestContracts.Corporation(inputToken, 22, page);

            Assert.Equal(0, esiModel.Model[0].AcceptorId);
            Assert.Equal(0, esiModel.Model[0].AssigneeId);
            Assert.Equal(V1ContractsCorporationAvailability.Public, esiModel.Model[0].Availability);
            Assert.Equal(10000000000.01, esiModel.Model[0].Buyout);
            Assert.Equal(1, esiModel.Model[0].ContractId);
            Assert.Equal(new DateTime(2017, 06, 13, 13, 12, 32), esiModel.Model[0].DateExpired);
            Assert.Equal(new DateTime(2017, 06, 06, 13, 12, 32), esiModel.Model[0].DateIssued);
            Assert.Equal(0, esiModel.Model[0].DaysToComplete);
            Assert.Equal(60014719, esiModel.Model[0].EndLocationId);
            Assert.True(esiModel.Model[0].ForCorporation);
            Assert.Equal(456, esiModel.Model[0].IssuerCorporationId);
            Assert.Equal(123, esiModel.Model[0].IssuerId);
            Assert.Equal(1000000.01, esiModel.Model[0].Price);
            Assert.Equal(0.01, esiModel.Model[0].Reward);
            Assert.Equal(60014719, esiModel.Model[0].StartLocationId);
            Assert.Equal(V1ContractsCorporationStatus.Outstanding, esiModel.Model[0].Status);
            Assert.Equal(V1ContractsCorporationType.Auction, esiModel.Model[0].Type);
            Assert.Equal(0.01, esiModel.Model[0].Volume);
        }

        [Fact]
        public async Task CorporationAsync_successfully_returns_a_pagedModelV1ContractsCorporation()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            int page = 1;
            ContractScopes scopes = ContractScopes.esi_contracts_read_corporation_contracts_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, ContractScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"acceptor_id\": 0,\r\n    \"assignee_id\": 0,\r\n    \"availability\": \"public\",\r\n    \"buyout\": 10000000000.01,\r\n    \"contract_id\": 1,\r\n    \"date_expired\": \"2017-06-13T13:12:32Z\",\r\n    \"date_issued\": \"2017-06-06T13:12:32Z\",\r\n    \"days_to_complete\": 0,\r\n    \"end_location_id\": 60014719,\r\n    \"for_corporation\": true,\r\n    \"issuer_corporation_id\": 456,\r\n    \"issuer_id\": 123,\r\n    \"price\": 1000000.01,\r\n    \"reward\": 0.01,\r\n    \"start_location_id\": 60014719,\r\n    \"status\": \"outstanding\",\r\n    \"type\": \"auction\",\r\n    \"volume\": 0.01\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json, MaxPages = 2 });

            InternalLatestContracts internalLatestContracts = new InternalLatestContracts(mockedWebClient.Object, string.Empty);

            PagedModel<V1ContractsCorporation> esiModel = await internalLatestContracts.CorporationAsync(inputToken, 22, page);

            Assert.Equal(0, esiModel.Model[0].AcceptorId);
            Assert.Equal(0, esiModel.Model[0].AssigneeId);
            Assert.Equal(V1ContractsCorporationAvailability.Public, esiModel.Model[0].Availability);
            Assert.Equal(10000000000.01, esiModel.Model[0].Buyout);
            Assert.Equal(1, esiModel.Model[0].ContractId);
            Assert.Equal(new DateTime(2017, 06, 13, 13, 12, 32), esiModel.Model[0].DateExpired);
            Assert.Equal(new DateTime(2017, 06, 06, 13, 12, 32), esiModel.Model[0].DateIssued);
            Assert.Equal(0, esiModel.Model[0].DaysToComplete);
            Assert.Equal(60014719, esiModel.Model[0].EndLocationId);
            Assert.True(esiModel.Model[0].ForCorporation);
            Assert.Equal(456, esiModel.Model[0].IssuerCorporationId);
            Assert.Equal(123, esiModel.Model[0].IssuerId);
            Assert.Equal(1000000.01, esiModel.Model[0].Price);
            Assert.Equal(0.01, esiModel.Model[0].Reward);
            Assert.Equal(60014719, esiModel.Model[0].StartLocationId);
            Assert.Equal(V1ContractsCorporationStatus.Outstanding, esiModel.Model[0].Status);
            Assert.Equal(V1ContractsCorporationType.Auction, esiModel.Model[0].Type);
            Assert.Equal(0.01, esiModel.Model[0].Volume);
        }

        [Fact]
        public void CorporationBids_successfully_returns_a_IListV1ContractsCorporationBids()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            ContractScopes scopes = ContractScopes.esi_contracts_read_corporation_contracts_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, ContractScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"amount\": 1.23,\r\n    \"bid_id\": 1,\r\n    \"bidder_id\": 123,\r\n    \"date_bid\": \"2017-01-01T10:10:10Z\"\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestContracts internalLatestContracts = new InternalLatestContracts(mockedWebClient.Object, string.Empty);

            IList<V1ContractsCorporationBids> esiModel = internalLatestContracts.CorporationBids(inputToken, 33, 44);

            Assert.Equal(1.23f, esiModel[0].Amount);
            Assert.Equal(1, esiModel[0].BidId);
            Assert.Equal(123, esiModel[0].BidderId);
            Assert.Equal(new DateTime(2017, 01, 01, 10, 10, 10), esiModel[0].DateBid);
        }

        [Fact]
        public async Task CorporationBidsAsync_successfully_returns_a_IListV1ContractsCorporationBids()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            ContractScopes scopes = ContractScopes.esi_contracts_read_corporation_contracts_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, ContractScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"amount\": 1.23,\r\n    \"bid_id\": 1,\r\n    \"bidder_id\": 123,\r\n    \"date_bid\": \"2017-01-01T10:10:10Z\"\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestContracts internalLatestContracts = new InternalLatestContracts(mockedWebClient.Object, string.Empty);

            IList<V1ContractsCorporationBids> esiModel = await internalLatestContracts.CorporationBidsAsync(inputToken, 33, 44);

            Assert.Equal(1.23f, esiModel[0].Amount);
            Assert.Equal(1, esiModel[0].BidId);
            Assert.Equal(123, esiModel[0].BidderId);
            Assert.Equal(new DateTime(2017, 01, 01, 10, 10, 10), esiModel[0].DateBid);
        }

        [Fact]
        public void CorporationItems_successfully_returns_a_IListV1ContractsCorporationItems()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            ContractScopes scopes = ContractScopes.esi_contracts_read_corporation_contracts_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, ContractScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"is_included\": true,\r\n    \"is_singleton\": false,\r\n    \"quantity\": 1,\r\n    \"record_id\": 123456,\r\n    \"type_id\": 587\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestContracts internalLatestContracts = new InternalLatestContracts(mockedWebClient.Object, string.Empty);

            IList<V1ContractsCorporationItems> esiModel = internalLatestContracts.CorporationItems(inputToken, 33, 44);

            Assert.True(esiModel[0].IsIncluded);
            Assert.False(esiModel[0].IsSingleton);
            Assert.Equal(1, esiModel[0].Quantity);
            Assert.Equal(123456, esiModel[0].RecordId);
            Assert.Equal(587, esiModel[0].TypeId);
        }

        [Fact]
        public async Task CorporationItemsAsync_successfully_returns_a_IListV1ContractsCorporationItems()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 88823;
            ContractScopes scopes = ContractScopes.esi_contracts_read_corporation_contracts_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, ContractScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"is_included\": true,\r\n    \"is_singleton\": false,\r\n    \"quantity\": 1,\r\n    \"record_id\": 123456,\r\n    \"type_id\": 587\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestContracts internalLatestContracts = new InternalLatestContracts(mockedWebClient.Object, string.Empty);

            IList<V1ContractsCorporationItems> esiModel = await internalLatestContracts.CorporationItemsAsync(inputToken, 33, 44);

            Assert.True(esiModel[0].IsIncluded);
            Assert.False(esiModel[0].IsSingleton);
            Assert.Equal(1, esiModel[0].Quantity);
            Assert.Equal(123456, esiModel[0].RecordId);
            Assert.Equal(587, esiModel[0].TypeId);
        }

        [Fact]
        public void Public_successfully_returns_a_PagedModel_V1ContractsPublic()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  {\r\n    \"buyout\": 10000000000.01,\r\n    \"contract_id\": 1,\r\n    \"date_expired\": \"2017-06-13T13:12:32Z\",\r\n    \"date_issued\": \"2017-06-06T13:12:32Z\",\r\n    \"days_to_complete\": 0,\r\n    \"end_location_id\": 60014719,\r\n    \"for_corporation\": true,\r\n    \"issuer_corporation_id\": 456,\r\n    \"issuer_id\": 123,\r\n    \"price\": 1000000.01,\r\n    \"reward\": 0.01,\r\n    \"start_location_id\": 60014719,\r\n    \"type\": \"auction\",\r\n    \"volume\": 0.01\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestContracts internalLatestContracts = new InternalLatestContracts(mockedWebClient.Object, string.Empty);

            PagedModel<V1ContractsPublic> esiModel = internalLatestContracts.Public(33, 1);

            Assert.Equal(10000000000.01, esiModel.Model[0].buyout);
            Assert.Equal(1, esiModel.Model[0].contract_id);
            Assert.Equal(new DateTime(2017, 06, 13, 13, 12, 32), esiModel.Model[0].date_expired);
            Assert.Equal(new DateTime(2017, 06, 06, 13, 12, 32), esiModel.Model[0].date_issued);
            Assert.Equal(0, esiModel.Model[0].days_to_complete);
            Assert.Equal(60014719, esiModel.Model[0].end_location_id);
            Assert.True(esiModel.Model[0].for_corporation);
            Assert.Equal(456, esiModel.Model[0].issuer_corporation_id);
            Assert.Equal(123, esiModel.Model[0].issuer_id);
            Assert.Equal(1000000.01, esiModel.Model[0].price);
            Assert.Equal(0.01, esiModel.Model[0].reward);
            Assert.Equal(60014719, esiModel.Model[0].start_location_id);
            Assert.Equal(V1ContractsPublicType.auction, esiModel.Model[0].type);
            Assert.Equal(0.01, esiModel.Model[0].volume);
        }

        [Fact]
        public async Task PublicAsync_successfully_returns_a_PagedModel_V1ContractsPublic()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  {\r\n    \"buyout\": 10000000000.01,\r\n    \"contract_id\": 1,\r\n    \"date_expired\": \"2017-06-13T13:12:32Z\",\r\n    \"date_issued\": \"2017-06-06T13:12:32Z\",\r\n    \"days_to_complete\": 0,\r\n    \"end_location_id\": 60014719,\r\n    \"for_corporation\": true,\r\n    \"issuer_corporation_id\": 456,\r\n    \"issuer_id\": 123,\r\n    \"price\": 1000000.01,\r\n    \"reward\": 0.01,\r\n    \"start_location_id\": 60014719,\r\n    \"type\": \"auction\",\r\n    \"volume\": 0.01\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestContracts internalLatestContracts = new InternalLatestContracts(mockedWebClient.Object, string.Empty);

            PagedModel<V1ContractsPublic> esiModel = await internalLatestContracts.PublicAsync(33, 1);

            Assert.Equal(10000000000.01, esiModel.Model[0].buyout);
            Assert.Equal(1, esiModel.Model[0].contract_id);
            Assert.Equal(new DateTime(2017, 06, 13, 13, 12, 32), esiModel.Model[0].date_expired);
            Assert.Equal(new DateTime(2017, 06, 06, 13, 12, 32), esiModel.Model[0].date_issued);
            Assert.Equal(0, esiModel.Model[0].days_to_complete);
            Assert.Equal(60014719, esiModel.Model[0].end_location_id);
            Assert.True(esiModel.Model[0].for_corporation);
            Assert.Equal(456, esiModel.Model[0].issuer_corporation_id);
            Assert.Equal(123, esiModel.Model[0].issuer_id);
            Assert.Equal(1000000.01, esiModel.Model[0].price);
            Assert.Equal(0.01, esiModel.Model[0].reward);
            Assert.Equal(60014719, esiModel.Model[0].start_location_id);
            Assert.Equal(V1ContractsPublicType.auction, esiModel.Model[0].type);
            Assert.Equal(0.01, esiModel.Model[0].volume);
        }

        [Fact]
        public void PublicBids_successfully_returns_a_PagedModel_V1ContractsPublicBid()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  {\r\n    \"amount\": 1.23,\r\n    \"bid_id\": 1,\r\n    \"bidder_id\": 123,\r\n    \"date_bid\": \"2017-01-01T10:10:10Z\"\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestContracts internalLatestContracts = new InternalLatestContracts(mockedWebClient.Object, string.Empty);

            PagedModel<V1ContractsPublicBid> esiModel = internalLatestContracts.PublicBids(33, 1);

            Assert.Equal(1.23f, esiModel.Model[0].amount);
            Assert.Equal(1, esiModel.Model[0].bid_id);
            Assert.Equal(123, esiModel.Model[0].bidder_id);
            Assert.Equal(new DateTime(2017, 01, 01, 10, 10, 10), esiModel.Model[0].date_bid);
        }

        [Fact]
        public async Task PublicBidsAsync_successfully_returns_a_PagedModel_V1ContractsPublicBid()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  {\r\n    \"amount\": 1.23,\r\n    \"bid_id\": 1,\r\n    \"bidder_id\": 123,\r\n    \"date_bid\": \"2017-01-01T10:10:10Z\"\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestContracts internalLatestContracts = new InternalLatestContracts(mockedWebClient.Object, string.Empty);

            PagedModel<V1ContractsPublicBid> esiModel = await internalLatestContracts.PublicBidsAsync(33, 1);

            Assert.Equal(1.23f, esiModel.Model[0].amount);
            Assert.Equal(1, esiModel.Model[0].bid_id);
            Assert.Equal(123, esiModel.Model[0].bidder_id);
            Assert.Equal(new DateTime(2017, 01, 01, 10, 10, 10), esiModel.Model[0].date_bid);
        }

        [Fact]
        public void PublicItems_successfully_returns_a_PagedModel_V1ContractsPublicItem()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  {\r\n    \"is_included\": true,\r\n    \"item_id\": 123456,\r\n    \"quantity\": 1,\r\n    \"record_id\": 123456,\r\n    \"type_id\": 587\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestContracts internalLatestContracts = new InternalLatestContracts(mockedWebClient.Object, string.Empty);

            PagedModel<V1ContractsPublicItem> esiModel = internalLatestContracts.PublicItems(33, 1);

            Assert.True(esiModel.Model[0].is_included);
            Assert.Equal(123456, esiModel.Model[0].item_id);
            Assert.Equal(1, esiModel.Model[0].quantity);
            Assert.Equal(123456, esiModel.Model[0].record_id);
            Assert.Equal(587, esiModel.Model[0].type_id);
        }

        [Fact]
        public async Task PublicItemsAsync_successfully_returns_a_PagedModel_V1ContractsPublicItem()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            string json = "[\r\n  {\r\n    \"is_included\": true,\r\n    \"item_id\": 123456,\r\n    \"quantity\": 1,\r\n    \"record_id\": 123456,\r\n    \"type_id\": 587\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestContracts internalLatestContracts = new InternalLatestContracts(mockedWebClient.Object, string.Empty);

            PagedModel<V1ContractsPublicItem> esiModel = await internalLatestContracts.PublicItemsAsync(33, 1);

            Assert.True(esiModel.Model[0].is_included);
            Assert.Equal(123456, esiModel.Model[0].item_id);
            Assert.Equal(1, esiModel.Model[0].quantity);
            Assert.Equal(123456, esiModel.Model[0].record_id);
            Assert.Equal(587, esiModel.Model[0].type_id);
        }
    }
}
