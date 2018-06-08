using System;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;
using ESIConnectionLibrary.Public_classes;
using Xunit;

namespace ESIConnectionLibraryTests.IntegrationTests
{
    public class ContractIntegrationTests
    {
        [Fact]
        public void GetCharactersContracts_successfully_returns_a_pagedModelV1ContractsGetContracts()
        {
            int characterId = 88823;
            int page = 1;
            ContractScopes scopes = ContractScopes.esi_contracts_read_character_contracts_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, ContractScopesFlags = scopes };

            LatestContractEndpoints internalLatestContracts = new LatestContractEndpoints(string.Empty, true);

            PagedModel<V1ContractsCharacterContracts> getCharactersContracts = internalLatestContracts.GetCharactersContracts(inputToken, page);

            Assert.Equal(1, getCharactersContracts.Model.Count);
            Assert.Equal(ContractsAvailability.@public, getCharactersContracts.Model[0].Availability);
            Assert.Equal(ContractsStatus.outstanding, getCharactersContracts.Model[0].Status);
            Assert.Equal(ContractsType.auction, getCharactersContracts.Model[0].Type);
            Assert.Equal(new DateTime(2017, 06, 06, 13, 12, 32), getCharactersContracts.Model[0].DateAccepted);
            Assert.Equal(0.01, getCharactersContracts.Model[0].Reward);
            Assert.Equal(0.01, getCharactersContracts.Model[0].Volume);
        }

        [Fact]
        public async Task GetCharactersContractsAsync_successfully_returns_a_pagedModelV1ContractsGetContracts()
        {
            int characterId = 88823;
            int page = 1;
            ContractScopes scopes = ContractScopes.esi_contracts_read_character_contracts_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, ContractScopesFlags = scopes };

            LatestContractEndpoints internalLatestContracts = new LatestContractEndpoints(string.Empty, true);

            PagedModel<V1ContractsCharacterContracts> getCharactersContracts = await internalLatestContracts.GetCharactersContractsAsync(inputToken, page);

            Assert.Equal(1, getCharactersContracts.Model.Count);
            Assert.Equal(ContractsAvailability.@public, getCharactersContracts.Model[0].Availability);
            Assert.Equal(ContractsStatus.outstanding, getCharactersContracts.Model[0].Status);
            Assert.Equal(ContractsType.auction, getCharactersContracts.Model[0].Type);
            Assert.Equal(new DateTime(2017, 06, 06, 13, 12, 32), getCharactersContracts.Model[0].DateAccepted);
            Assert.Equal(0.01, getCharactersContracts.Model[0].Reward);
            Assert.Equal(0.01, getCharactersContracts.Model[0].Volume);
        }
    }
}
