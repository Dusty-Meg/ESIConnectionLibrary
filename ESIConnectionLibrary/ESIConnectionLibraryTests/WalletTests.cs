using System.Net;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;
using Moq;
using Xunit;

namespace ESIConnectionLibraryTests
{
    public class WalletTests
    {
        [Fact]
        public void GetCharactersWalletJournal_successfully_returns_a_pagedModelWalletCharacterJournal()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 98772;
            int page = 1;
            WalletScopes scopes = WalletScopes.esi_wallet_read_character_wallet_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, WalletScopesFlags = scopes };
            string getWalletJournalJson = "[{\"amount\": -100000,\"balance\": 500000.4316,\"context_id\": 4,\"context_id_type\": \"contract_id\",\"date\": \"2018-02-23T14:31:32Z\",\"description\": \"Contract Deposit\",\"first_party_id\": 2112625428,\"id\": 89,\"ref_type\": \"contract_deposit\",\"second_party_id\": 1000132}]";

            PagedJson pagedJson = new PagedJson{ Response = getWalletJournalJson, MaxPages = 2 };

            mockedWebClient.Setup(x => x.GetPaged(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(pagedJson);

            InternalLatestWallet internalLatestWallet = new InternalLatestWallet(mockedWebClient.Object, string.Empty);

            PagedModel<V4WalletCharacterJournal> getCharactersWalletJournal = internalLatestWallet.GetCharactersWalletJournal(inputToken, characterId, page);

            Assert.Equal(2, getCharactersWalletJournal.MaxPages);
            Assert.Equal(1, getCharactersWalletJournal.CurrentPage);
            Assert.Equal(1, getCharactersWalletJournal.Model.Count);
            Assert.Equal(WalletRefType.contract_deposit, getCharactersWalletJournal.Model[0].RefType);
            Assert.Equal(WalletContextIdType.contract_id, getCharactersWalletJournal.Model[0].ContextIdType);
            Assert.Equal(-100000, getCharactersWalletJournal.Model[0].Amount);
            Assert.Equal(500000.4316, getCharactersWalletJournal.Model[0].Balance);
        }

        [Fact]
        public async System.Threading.Tasks.Task GetCharactersWalletJournalAsync_successfully_returns_a_pagedModelWalletCharacterJournalAsync()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 98772;
            int page = 1;
            WalletScopes scopes = WalletScopes.esi_wallet_read_character_wallet_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, WalletScopesFlags = scopes };
            string getWalletJournalJson = "[{\"amount\": -100000,\"balance\": 500000.4316,\"context_id\": 4,\"context_id_type\": \"contract_id\",\"date\": \"2018-02-23T14:31:32Z\",\"description\": \"Contract Deposit\",\"first_party_id\": 2112625428,\"id\": 89,\"ref_type\": \"contract_deposit\",\"second_party_id\": 1000132}]";

            PagedJson pagedJson = new PagedJson { Response = getWalletJournalJson, MaxPages = 2 };

            mockedWebClient.Setup(x => x.GetPagedAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(pagedJson);

            InternalLatestWallet internalLatestWallet = new InternalLatestWallet(mockedWebClient.Object, string.Empty);

            PagedModel<V4WalletCharacterJournal> getCharactersWalletJournal = await internalLatestWallet.GetCharactersWalletJournalAsync(inputToken, characterId, page);

            Assert.Equal(2, getCharactersWalletJournal.MaxPages);
            Assert.Equal(1, getCharactersWalletJournal.CurrentPage);
            Assert.Equal(1, getCharactersWalletJournal.Model.Count);
            Assert.Equal(WalletRefType.contract_deposit, getCharactersWalletJournal.Model[0].RefType);
            Assert.Equal(WalletContextIdType.contract_id, getCharactersWalletJournal.Model[0].ContextIdType);
            Assert.Equal(-100000, getCharactersWalletJournal.Model[0].Amount);
            Assert.Equal(500000.4316, getCharactersWalletJournal.Model[0].Balance);
        }
    }
}
