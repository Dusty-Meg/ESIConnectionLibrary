using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;
using ESIConnectionLibrary.Public_classes;
using Xunit;

namespace ESIConnectionLibraryTests.IntegrationTests
{
    public class ContractIntegrationTests
    {
        [Fact]
        public void Character_successfully_returns_a_pagedModelV1ContractsCharacter()
        {
            int characterId = 88823;
            int page = 1;
            ContractScopes scopes = ContractScopes.esi_contracts_read_character_contracts_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, ContractScopesFlags = scopes };

            LatestContractEndpoints internalLatestContracts = new LatestContractEndpoints(string.Empty, true);

            PagedModel<V1ContractsCharacter> esiModel = internalLatestContracts.Character(inputToken, page);

            Assert.Equal(1, esiModel.Model.Count);
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
            int characterId = 88823;
            int page = 1;
            ContractScopes scopes = ContractScopes.esi_contracts_read_character_contracts_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, ContractScopesFlags = scopes };

            LatestContractEndpoints internalLatestContracts = new LatestContractEndpoints(string.Empty, true);

            PagedModel<V1ContractsCharacter> esiModel = await internalLatestContracts.CharacterAsync(inputToken, page);

            Assert.Equal(1, esiModel.Model.Count);
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
            int characterId = 88823;
            ContractScopes scopes = ContractScopes.esi_contracts_read_character_contracts_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, ContractScopesFlags = scopes };

            LatestContractEndpoints internalLatestContracts = new LatestContractEndpoints(string.Empty, true);

            IList<V1ContractsCharacterBids> esiModel = internalLatestContracts.CharacterBids(inputToken, 44);

            Assert.Equal(1.23f, esiModel[0].Amount);
            Assert.Equal(1, esiModel[0].BidId);
            Assert.Equal(123, esiModel[0].BidderId);
            Assert.Equal(new DateTime(2017, 01, 01, 10, 10, 10), esiModel[0].DateBid);
        }

        [Fact]
        public async Task CharacterBidsAsync_successfully_returns_a_IListV1ContractsCharacterBids()
        {
            int characterId = 88823;
            ContractScopes scopes = ContractScopes.esi_contracts_read_character_contracts_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, ContractScopesFlags = scopes };

            LatestContractEndpoints internalLatestContracts = new LatestContractEndpoints(string.Empty, true);

            IList<V1ContractsCharacterBids> esiModel = await internalLatestContracts.CharacterBidsAsync(inputToken, 44);

            Assert.Equal(1.23f, esiModel[0].Amount);
            Assert.Equal(1, esiModel[0].BidId);
            Assert.Equal(123, esiModel[0].BidderId);
            Assert.Equal(new DateTime(2017, 01, 01, 10, 10, 10), esiModel[0].DateBid);
        }

        [Fact]
        public void CharacterItems_successfully_returns_a_IListV1ContractsCharacterItems()
        {
            int characterId = 88823;
            ContractScopes scopes = ContractScopes.esi_contracts_read_character_contracts_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, ContractScopesFlags = scopes };

            LatestContractEndpoints internalLatestContracts = new LatestContractEndpoints(string.Empty, true);

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
            int characterId = 88823;
            ContractScopes scopes = ContractScopes.esi_contracts_read_character_contracts_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, ContractScopesFlags = scopes };

            LatestContractEndpoints internalLatestContracts = new LatestContractEndpoints(string.Empty, true);

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
            int characterId = 88823;
            int page = 1;
            ContractScopes scopes = ContractScopes.esi_contracts_read_corporation_contracts_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, ContractScopesFlags = scopes };

            LatestContractEndpoints internalLatestContracts = new LatestContractEndpoints(string.Empty, true);

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
            int characterId = 88823;
            int page = 1;
            ContractScopes scopes = ContractScopes.esi_contracts_read_corporation_contracts_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, ContractScopesFlags = scopes };

            LatestContractEndpoints internalLatestContracts = new LatestContractEndpoints(string.Empty, true);

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
            int characterId = 88823;
            ContractScopes scopes = ContractScopes.esi_contracts_read_corporation_contracts_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, ContractScopesFlags = scopes };

            LatestContractEndpoints internalLatestContracts = new LatestContractEndpoints(string.Empty, true);

            IList<V1ContractsCorporationBids> esiModel = internalLatestContracts.CorporationBids(inputToken, 33, 44);

            Assert.Equal(1.23f, esiModel[0].Amount);
            Assert.Equal(1, esiModel[0].BidId);
            Assert.Equal(123, esiModel[0].BidderId);
            Assert.Equal(new DateTime(2017, 01, 01, 10, 10, 10), esiModel[0].DateBid);
        }

        [Fact]
        public async Task CorporationBidsAsync_successfully_returns_a_IListV1ContractsCorporationBids()
        {
            int characterId = 88823;
            ContractScopes scopes = ContractScopes.esi_contracts_read_corporation_contracts_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, ContractScopesFlags = scopes };

            LatestContractEndpoints internalLatestContracts = new LatestContractEndpoints(string.Empty, true);

            IList<V1ContractsCorporationBids> esiModel = await internalLatestContracts.CorporationBidsAsync(inputToken, 33, 44);

            Assert.Equal(1.23f, esiModel[0].Amount);
            Assert.Equal(1, esiModel[0].BidId);
            Assert.Equal(123, esiModel[0].BidderId);
            Assert.Equal(new DateTime(2017, 01, 01, 10, 10, 10), esiModel[0].DateBid);
        }

        [Fact]
        public void CorporationItems_successfully_returns_a_IListV1ContractsCorporationItems()
        {
            int characterId = 88823;
            ContractScopes scopes = ContractScopes.esi_contracts_read_corporation_contracts_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, ContractScopesFlags = scopes };

            LatestContractEndpoints internalLatestContracts = new LatestContractEndpoints(string.Empty, true);

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
            int characterId = 88823;
            ContractScopes scopes = ContractScopes.esi_contracts_read_corporation_contracts_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, ContractScopesFlags = scopes };

            LatestContractEndpoints internalLatestContracts = new LatestContractEndpoints(string.Empty, true);

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
            LatestContractEndpoints internalLatestContracts = new LatestContractEndpoints(string.Empty, true);

            PagedModel<V1ContractsPublic> esiModel = internalLatestContracts.Public(33, 1);

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
            Assert.Equal(V1ContractsPublicType.Auction, esiModel.Model[0].Type);
            Assert.Equal(0.01, esiModel.Model[0].Volume);
        }

        [Fact]
        public async Task PublicAsync_successfully_returns_a_PagedModel_V1ContractsPublic()
        {
            LatestContractEndpoints internalLatestContracts = new LatestContractEndpoints(string.Empty, true);

            PagedModel<V1ContractsPublic> esiModel = await internalLatestContracts.PublicAsync(33, 1);

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
            Assert.Equal(V1ContractsPublicType.Auction, esiModel.Model[0].Type);
            Assert.Equal(0.01, esiModel.Model[0].Volume);
        }

        [Fact]
        public void PublicBids_successfully_returns_a_PagedModel_V1ContractsPublicBid()
        {
            LatestContractEndpoints internalLatestContracts = new LatestContractEndpoints(string.Empty, true);

            PagedModel<V1ContractsPublicBid> esiModel = internalLatestContracts.PublicBids(33, 1);

            Assert.Equal(1.23f, esiModel.Model[0].Amount);
            Assert.Equal(1, esiModel.Model[0].BidId);
            Assert.Equal(new DateTime(2017, 01, 01, 10, 10, 10), esiModel.Model[0].DateBid);
        }

        [Fact]
        public async Task PublicBidsAsync_successfully_returns_a_PagedModel_V1ContractsPublicBid()
        {
            LatestContractEndpoints internalLatestContracts = new LatestContractEndpoints(string.Empty, true);

            PagedModel<V1ContractsPublicBid> esiModel = await internalLatestContracts.PublicBidsAsync(33, 1);

            Assert.Equal(1.23f, esiModel.Model[0].Amount);
            Assert.Equal(1, esiModel.Model[0].BidId);
            Assert.Equal(new DateTime(2017, 01, 01, 10, 10, 10), esiModel.Model[0].DateBid);
        }

        [Fact]
        public void PublicItems_successfully_returns_a_PagedModel_V1ContractsPublicItem()
        {
            LatestContractEndpoints internalLatestContracts = new LatestContractEndpoints(string.Empty, true);

            PagedModel<V1ContractsPublicItem> esiModel = internalLatestContracts.PublicItems(33, 1);

            Assert.True(esiModel.Model[0].IsIncluded);
            Assert.Equal(123456, esiModel.Model[0].ItemId);
            Assert.Equal(1, esiModel.Model[0].Quantity);
            Assert.Equal(123456, esiModel.Model[0].RecordId);
            Assert.Equal(587, esiModel.Model[0].TypeId);
        }

        [Fact]
        public async Task PublicItemsAsync_successfully_returns_a_PagedModel_V1ContractsPublicItem()
        {
            LatestContractEndpoints internalLatestContracts = new LatestContractEndpoints(string.Empty, true);

            PagedModel<V1ContractsPublicItem> esiModel = await internalLatestContracts.PublicItemsAsync(33, 1);

            Assert.True(esiModel.Model[0].IsIncluded);
            Assert.Equal(123456, esiModel.Model[0].ItemId);
            Assert.Equal(1, esiModel.Model[0].Quantity);
            Assert.Equal(123456, esiModel.Model[0].RecordId);
            Assert.Equal(587, esiModel.Model[0].TypeId);
        }
    }
}
