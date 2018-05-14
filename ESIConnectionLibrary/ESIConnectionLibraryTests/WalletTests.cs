using System;
using System.Net;
using System.Threading.Tasks;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;
using Moq;
using Xunit;

namespace ESIConnectionLibraryTests
{
    public class WalletTests
    {
        [Fact]
        public void GetCharactersWallet_successfully_returns_a_double()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 98772;
            WalletScopes scopes = WalletScopes.esi_wallet_read_character_wallet_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, WalletScopesFlags = scopes };
            string getWalletJournalJson = "29500.01";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(getWalletJournalJson);

            InternalLatestWallet internalLatestWallet = new InternalLatestWallet(mockedWebClient.Object, string.Empty);

            double getCharactersWallet = internalLatestWallet.GetCharactersWallet(inputToken);

            Assert.Equal(29500.01, getCharactersWallet);
        }

        [Fact]
        public async Task GetCharactersWalletAsync_successfully_returns_a_double()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 98772;
            WalletScopes scopes = WalletScopes.esi_wallet_read_character_wallet_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, WalletScopesFlags = scopes };
            string getWalletJournalJson = "29500.01";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(getWalletJournalJson);

            InternalLatestWallet internalLatestWallet = new InternalLatestWallet(mockedWebClient.Object, string.Empty);

            double getCharactersWallet = await internalLatestWallet.GetCharactersWalletAsync(inputToken);

            Assert.Equal(29500.01, getCharactersWallet);
        }

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

            PagedModel<V4WalletCharacterJournal> getCharactersWalletJournal = internalLatestWallet.GetCharactersWalletJournal(inputToken, page);

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

            PagedModel<V4WalletCharacterJournal> getCharactersWalletJournal = await internalLatestWallet.GetCharactersWalletJournalAsync(inputToken, page);

            Assert.Equal(2, getCharactersWalletJournal.MaxPages);
            Assert.Equal(1, getCharactersWalletJournal.CurrentPage);
            Assert.Equal(1, getCharactersWalletJournal.Model.Count);
            Assert.Equal(WalletRefType.contract_deposit, getCharactersWalletJournal.Model[0].RefType);
            Assert.Equal(WalletContextIdType.contract_id, getCharactersWalletJournal.Model[0].ContextIdType);
            Assert.Equal(-100000, getCharactersWalletJournal.Model[0].Amount);
            Assert.Equal(500000.4316, getCharactersWalletJournal.Model[0].Balance);
        }

        [Fact]
        public void GetCharactersWalletTransaction_successfully_returns_a_pagedModelWalletCharacterTransaction()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 98772;
            int lastId = 1;
            WalletScopes scopes = WalletScopes.esi_wallet_read_character_wallet_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, WalletScopesFlags = scopes };
            string getWalletTransactionJson = "[{\"client_id\": 54321,\"date\": \"2016-10-24T09:00:00Z\",\"is_buy\": true,\"is_personal\": true,\"journal_ref_id\": 67890,\"location_id\": 60014719,\"quantity\": 1,\"transaction_id\": 1234567890,\"type_id\": 587,\"unit_price\": 1}]";

            PagedJson pagedJson = new PagedJson { Response = getWalletTransactionJson };

            mockedWebClient.Setup(x => x.GetPaged(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(pagedJson);

            InternalLatestWallet internalLatestWallet = new InternalLatestWallet(mockedWebClient.Object, string.Empty);

            PagedModel<V1WalletCharacterTransactions> getCharactersWalletTransactions = internalLatestWallet.GetCharactersWalletTransaction(inputToken, lastId);

            Assert.Equal(1, getCharactersWalletTransactions.CurrentPage);
            Assert.Equal(1, getCharactersWalletTransactions.Model.Count);
            Assert.Equal(54321, getCharactersWalletTransactions.Model[0].ClientId);
            Assert.Equal(new DateTime(2016,10,24,09,00,00), getCharactersWalletTransactions.Model[0].Date);
            Assert.True(getCharactersWalletTransactions.Model[0].IsBuy);
            Assert.True(getCharactersWalletTransactions.Model[0].IsPersonal);
            Assert.Equal(67890, getCharactersWalletTransactions.Model[0].JournalRefId);
            Assert.Equal(60014719, getCharactersWalletTransactions.Model[0].LocationId);
            Assert.Equal(1, getCharactersWalletTransactions.Model[0].Quantity);
            Assert.Equal(1234567890, getCharactersWalletTransactions.Model[0].TransactionId);
            Assert.Equal(587, getCharactersWalletTransactions.Model[0].TypeId);
            Assert.Equal(1, getCharactersWalletTransactions.Model[0].UnitPrice);
        }

        [Fact]
        public async Task GetCharactersWalletTransactionAsync_successfully_returns_a_pagedModelWalletCharacterTransaction()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 98772;
            int lastId = 1;
            WalletScopes scopes = WalletScopes.esi_wallet_read_character_wallet_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, WalletScopesFlags = scopes };
            string getWalletTransactionJson = "[{\"client_id\": 54321,\"date\": \"2016-10-24T09:00:00Z\",\"is_buy\": true,\"is_personal\": true,\"journal_ref_id\": 67890,\"location_id\": 60014719,\"quantity\": 1,\"transaction_id\": 1234567890,\"type_id\": 587,\"unit_price\": 1}]";

            PagedJson pagedJson = new PagedJson { Response = getWalletTransactionJson };

            mockedWebClient.Setup(x => x.GetPagedAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(pagedJson);

            InternalLatestWallet internalLatestWallet = new InternalLatestWallet(mockedWebClient.Object, string.Empty);

            PagedModel<V1WalletCharacterTransactions> getCharactersWalletTransactions = await internalLatestWallet.GetCharactersWalletTransactionAsync(inputToken, lastId);

            Assert.Equal(1, getCharactersWalletTransactions.CurrentPage);
            Assert.Equal(1, getCharactersWalletTransactions.Model.Count);
            Assert.Equal(54321, getCharactersWalletTransactions.Model[0].ClientId);
            Assert.Equal(new DateTime(2016, 10, 24, 09, 00, 00), getCharactersWalletTransactions.Model[0].Date);
            Assert.True(getCharactersWalletTransactions.Model[0].IsBuy);
            Assert.True(getCharactersWalletTransactions.Model[0].IsPersonal);
            Assert.Equal(67890, getCharactersWalletTransactions.Model[0].JournalRefId);
            Assert.Equal(60014719, getCharactersWalletTransactions.Model[0].LocationId);
            Assert.Equal(1, getCharactersWalletTransactions.Model[0].Quantity);
            Assert.Equal(1234567890, getCharactersWalletTransactions.Model[0].TransactionId);
            Assert.Equal(587, getCharactersWalletTransactions.Model[0].TypeId);
            Assert.Equal(1, getCharactersWalletTransactions.Model[0].UnitPrice);
        }
    }
}
