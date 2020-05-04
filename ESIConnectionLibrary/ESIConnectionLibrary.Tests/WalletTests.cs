using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;
using Moq;
using Xunit;

namespace ESIConnectionLibrary.Tests
{
    public class WalletTests
    {
        [Fact]
        public void Character_successfully_returns_a_double()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 98772;
            WalletScopes scopes = WalletScopes.esi_wallet_read_character_wallet_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, WalletScopesFlags = scopes };
            string json = "29500.01";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestWallet internalLatestWallet = new InternalLatestWallet(mockedWebClient.Object, string.Empty);

            double getCharactersWallet = internalLatestWallet.Character(inputToken);

            Assert.Equal(29500.01, getCharactersWallet);
        }

        [Fact]
        public async Task CharacterAsync_successfully_returns_a_double()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 98772;
            WalletScopes scopes = WalletScopes.esi_wallet_read_character_wallet_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, WalletScopesFlags = scopes };
            string json = "29500.01";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestWallet internalLatestWallet = new InternalLatestWallet(mockedWebClient.Object, string.Empty);

            double getCharactersWallet = await internalLatestWallet.CharacterAsync(inputToken);

            Assert.Equal(29500.01, getCharactersWallet);
        }

        [Fact]
        public void CharacterJournal_successfully_returns_a_pagedModelWalletCharacterJournal()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 98772;
            int page = 1;
            WalletScopes scopes = WalletScopes.esi_wallet_read_character_wallet_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, WalletScopesFlags = scopes };
            string json = "[{\"amount\": -100000,\"balance\": 500000.4316,\"context_id\": 4,\"context_id_type\": \"contract_id\",\"date\": \"2018-02-23T14:31:32Z\",\"description\": \"Contract Deposit\",\"first_party_id\": 2112625428,\"id\": 89,\"ref_type\": \"contract_deposit\",\"second_party_id\": 1000132}]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json, MaxPages = 2});

            InternalLatestWallet internalLatestWallet = new InternalLatestWallet(mockedWebClient.Object, string.Empty);

            PagedModel<V6WalletCharacterJournal> getCharactersWalletJournal = internalLatestWallet.CharacterJournal(inputToken, page);

            Assert.Equal(2, getCharactersWalletJournal.MaxPages);
            Assert.Equal(1, getCharactersWalletJournal.CurrentPage);
            Assert.Equal(1, getCharactersWalletJournal.Model.Count);
            Assert.Equal(V6WalletCharacterJournalRefType.ContractDeposit, getCharactersWalletJournal.Model[0].RefType);
            Assert.Equal(V6WalletCharacterJournalContextIdType.ContractId, getCharactersWalletJournal.Model[0].ContextIdType);
            Assert.Equal(-100000, getCharactersWalletJournal.Model[0].Amount);
            Assert.Equal(500000.4316, getCharactersWalletJournal.Model[0].Balance);
        }

        [Fact]
        public async Task CharacterJournalAsync_successfully_returns_a_pagedModelWalletCharacterJournalAsync()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 98772;
            int page = 1;
            WalletScopes scopes = WalletScopes.esi_wallet_read_character_wallet_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, WalletScopesFlags = scopes };
            string json = "[{\"amount\": -100000,\"balance\": 500000.4316,\"context_id\": 4,\"context_id_type\": \"contract_id\",\"date\": \"2018-02-23T14:31:32Z\",\"description\": \"Contract Deposit\",\"first_party_id\": 2112625428,\"id\": 89,\"ref_type\": \"contract_deposit\",\"second_party_id\": 1000132}]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json, MaxPages = 2});

            InternalLatestWallet internalLatestWallet = new InternalLatestWallet(mockedWebClient.Object, string.Empty);

            PagedModel<V6WalletCharacterJournal> getCharactersWalletJournal = await internalLatestWallet.CharacterJournalAsync(inputToken, page);

            Assert.Equal(2, getCharactersWalletJournal.MaxPages);
            Assert.Equal(1, getCharactersWalletJournal.CurrentPage);
            Assert.Equal(1, getCharactersWalletJournal.Model.Count);
            Assert.Equal(V6WalletCharacterJournalRefType.ContractDeposit, getCharactersWalletJournal.Model[0].RefType);
            Assert.Equal(V6WalletCharacterJournalContextIdType.ContractId, getCharactersWalletJournal.Model[0].ContextIdType);
            Assert.Equal(-100000, getCharactersWalletJournal.Model[0].Amount);
            Assert.Equal(500000.4316, getCharactersWalletJournal.Model[0].Balance);
        }

        [Fact]
        public void CharacterTransactions_successfully_returns_a_pagedModelWalletCharacterTransaction()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 98772;
            int lastId = 1;
            WalletScopes scopes = WalletScopes.esi_wallet_read_character_wallet_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, WalletScopesFlags = scopes };
            string json = "[{\"client_id\": 54321,\"date\": \"2016-10-24T09:00:00Z\",\"is_buy\": true,\"is_personal\": true,\"journal_ref_id\": 67890,\"location_id\": 60014719,\"quantity\": 1,\"transaction_id\": 1234567890,\"type_id\": 587,\"unit_price\": 1}]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json, MaxPages = 2});

            InternalLatestWallet internalLatestWallet = new InternalLatestWallet(mockedWebClient.Object, string.Empty);

            PagedModel<V1WalletCharacterTransactions> getCharactersWalletTransactions = internalLatestWallet.CharacterTransactions(inputToken, lastId);

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
        public async Task CharacterTransactionsAsync_successfully_returns_a_pagedModelWalletCharacterTransaction()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 98772;
            int lastId = 1;
            WalletScopes scopes = WalletScopes.esi_wallet_read_character_wallet_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, WalletScopesFlags = scopes };
            string json = "[{\"client_id\": 54321,\"date\": \"2016-10-24T09:00:00Z\",\"is_buy\": true,\"is_personal\": true,\"journal_ref_id\": 67890,\"location_id\": 60014719,\"quantity\": 1,\"transaction_id\": 1234567890,\"type_id\": 587,\"unit_price\": 1}]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json, MaxPages = 2});

            InternalLatestWallet internalLatestWallet = new InternalLatestWallet(mockedWebClient.Object, string.Empty);

            PagedModel<V1WalletCharacterTransactions> getCharactersWalletTransactions = await internalLatestWallet.CharacterTransactionsAsync(inputToken, lastId);

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

        [Fact]
        public void Corporation_successfully_returns_a_listV1WalletCorporationWallet()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 98772;
            WalletScopes scopes = WalletScopes.esi_wallet_read_corporation_wallets_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, WalletScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"balance\": 123.45,\r\n    \"division\": 1\r\n  },\r\n  {\r\n    \"balance\": 123.45,\r\n    \"division\": 2\r\n  },\r\n  {\r\n    \"balance\": 123.45,\r\n    \"division\": 3\r\n  },\r\n  {\r\n    \"balance\": 123.45,\r\n    \"division\": 4\r\n  },\r\n  {\r\n    \"balance\": 123.45,\r\n    \"division\": 5\r\n  },\r\n  {\r\n    \"balance\": 123.45,\r\n    \"division\": 6\r\n  },\r\n  {\r\n    \"balance\": 123.45,\r\n    \"division\": 7\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestWallet internalLatestWallet = new InternalLatestWallet(mockedWebClient.Object, string.Empty);

            IList<V1WalletCorporationWallet> getCorporationsWallets = internalLatestWallet.Corporation(inputToken, 999);

            Assert.Equal(7, getCorporationsWallets.Count);
            Assert.Equal(123.45, getCorporationsWallets[0].Balance);
            Assert.Equal(1, getCorporationsWallets[0].Division);
            Assert.Equal(123.45, getCorporationsWallets[6].Balance);
            Assert.Equal(7, getCorporationsWallets[6].Division);
        }

        [Fact]
        public async Task CorporationAsync_successfully_returns_a_listV1WalletCorporationWallet()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 98772;
            WalletScopes scopes = WalletScopes.esi_wallet_read_corporation_wallets_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, WalletScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"balance\": 123.45,\r\n    \"division\": 1\r\n  },\r\n  {\r\n    \"balance\": 123.45,\r\n    \"division\": 2\r\n  },\r\n  {\r\n    \"balance\": 123.45,\r\n    \"division\": 3\r\n  },\r\n  {\r\n    \"balance\": 123.45,\r\n    \"division\": 4\r\n  },\r\n  {\r\n    \"balance\": 123.45,\r\n    \"division\": 5\r\n  },\r\n  {\r\n    \"balance\": 123.45,\r\n    \"division\": 6\r\n  },\r\n  {\r\n    \"balance\": 123.45,\r\n    \"division\": 7\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestWallet internalLatestWallet = new InternalLatestWallet(mockedWebClient.Object, string.Empty);

            IList<V1WalletCorporationWallet> getCorporationsWallets = await internalLatestWallet.CorporationAsync(inputToken, 999);

            Assert.Equal(7, getCorporationsWallets.Count);
            Assert.Equal(123.45, getCorporationsWallets[0].Balance);
            Assert.Equal(1, getCorporationsWallets[0].Division);
            Assert.Equal(123.45, getCorporationsWallets[6].Balance);
            Assert.Equal(7, getCorporationsWallets[6].Division);
        }

        [Fact]
        public void CorporationJournal_successfully_returns_a_listV3WalletCorporationJournal()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 98772;
            WalletScopes scopes = WalletScopes.esi_wallet_read_corporation_wallets_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, WalletScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"amount\": -1000,\r\n    \"balance\": 100000,\r\n    \"context_id\": 2112625428,\r\n    \"context_id_type\": \"character_id\",\r\n    \"date\": \"2016-10-24T09:00:00Z\",\r\n    \"description\": \"CCP Zoetrope transferred cash from C C P\'s corporate account to CCP SnowedIn\'s account\",\r\n    \"first_party_id\": 109299958,\r\n    \"id\": 1234567890,\r\n    \"ref_type\": \"corporation_account_withdrawal\",\r\n    \"second_party_id\": 95538921\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json, MaxPages = 2});

            InternalLatestWallet internalLatestWallet = new InternalLatestWallet(mockedWebClient.Object, string.Empty);

            PagedModel<V4WalletCorporationJournal> getCorporationJournals = internalLatestWallet.CorporationJournal(inputToken, 999, 1, 1);

            Assert.Equal(1, getCorporationJournals.Model.Count);
            Assert.Equal(-1000, getCorporationJournals.Model[0].Amount);
            Assert.Equal(100000, getCorporationJournals.Model[0].Balance);
            Assert.Equal(2112625428, getCorporationJournals.Model[0].ContextId);
            Assert.Equal(WalletContextIdType.CharacterId, getCorporationJournals.Model[0].ContextIdType);
            Assert.Equal(new DateTime(2016,10,24,09,00,00), getCorporationJournals.Model[0].Date);
            Assert.Equal("CCP Zoetrope transferred cash from C C P's corporate account to CCP SnowedIn's account", getCorporationJournals.Model[0].Description);
            Assert.Equal(109299958, getCorporationJournals.Model[0].FirstPartyId);
            Assert.Equal(1234567890, getCorporationJournals.Model[0].Id);
            Assert.Equal(WalletRefType.CorporationAccountWithdrawal, getCorporationJournals.Model[0].RefType);
            Assert.Equal(95538921, getCorporationJournals.Model[0].SecondPartyId);
        }

        [Fact]
        public async Task CorporationJournalAsync_successfully_returns_a_listV3WalletCorporationJournal()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 98772;
            WalletScopes scopes = WalletScopes.esi_wallet_read_corporation_wallets_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, WalletScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"amount\": -1000,\r\n    \"balance\": 100000,\r\n    \"context_id\": 2112625428,\r\n    \"context_id_type\": \"character_id\",\r\n    \"date\": \"2016-10-24T09:00:00Z\",\r\n    \"description\": \"CCP Zoetrope transferred cash from C C P\'s corporate account to CCP SnowedIn\'s account\",\r\n    \"first_party_id\": 109299958,\r\n    \"id\": 1234567890,\r\n    \"ref_type\": \"corporation_account_withdrawal\",\r\n    \"second_party_id\": 95538921\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json, MaxPages = 2});

            InternalLatestWallet internalLatestWallet = new InternalLatestWallet(mockedWebClient.Object, string.Empty);

            PagedModel<V4WalletCorporationJournal> getCorporationJournals = await internalLatestWallet.CorporationJournalAsync(inputToken, 999, 1, 1);

            Assert.Equal(1, getCorporationJournals.Model.Count);
            Assert.Equal(-1000, getCorporationJournals.Model[0].Amount);
            Assert.Equal(100000, getCorporationJournals.Model[0].Balance);
            Assert.Equal(2112625428, getCorporationJournals.Model[0].ContextId);
            Assert.Equal(WalletContextIdType.CharacterId, getCorporationJournals.Model[0].ContextIdType);
            Assert.Equal(new DateTime(2016, 10, 24, 09, 00, 00), getCorporationJournals.Model[0].Date);
            Assert.Equal("CCP Zoetrope transferred cash from C C P's corporate account to CCP SnowedIn's account", getCorporationJournals.Model[0].Description);
            Assert.Equal(109299958, getCorporationJournals.Model[0].FirstPartyId);
            Assert.Equal(1234567890, getCorporationJournals.Model[0].Id);
            Assert.Equal(WalletRefType.CorporationAccountWithdrawal, getCorporationJournals.Model[0].RefType);
            Assert.Equal(95538921, getCorporationJournals.Model[0].SecondPartyId);
        }

        [Fact]
        public void CorporationTransactions_successfully_returns_a_listV1WalletCharacterTransactions()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 98772;
            WalletScopes scopes = WalletScopes.esi_wallet_read_corporation_wallets_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, WalletScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"client_id\": 54321,\r\n    \"date\": \"2016-10-24T09:00:00Z\",\r\n    \"is_buy\": true,\r\n    \"journal_ref_id\": 67890,\r\n    \"location_id\": 60014719,\r\n    \"quantity\": 1,\r\n    \"transaction_id\": 1234567890,\r\n    \"type_id\": 587,\r\n    \"unit_price\": 1\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.Get(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).Returns(new EsiModel { Model = json });

            InternalLatestWallet internalLatestWallet = new InternalLatestWallet(mockedWebClient.Object, string.Empty);

            IList<V1WalletCorporationTransactions> getCorporationJournals = internalLatestWallet.CorporationTransactions(inputToken, 999, 1, 1);

            Assert.Equal(1, getCorporationJournals.Count);
            Assert.Equal(54321, getCorporationJournals[0].ClientId);
            Assert.Equal(new DateTime(2016, 10, 24, 09, 00, 00), getCorporationJournals[0].Date);
            Assert.True(getCorporationJournals[0].IsBuy);
            Assert.Equal(67890, getCorporationJournals[0].JournalRefId);
            Assert.Equal(60014719, getCorporationJournals[0].LocationId);
            Assert.Equal(1, getCorporationJournals[0].Quantity);
            Assert.Equal(1234567890, getCorporationJournals[0].TransactionId);
            Assert.Equal(587, getCorporationJournals[0].TypeId);
            Assert.Equal(1, getCorporationJournals[0].UnitPrice);
        }

        [Fact]
        public async Task CorporationTransactionsAsync_successfully_returns_a_listV1WalletCharacterTransactions()
        {
            Mock<IWebClient> mockedWebClient = new Mock<IWebClient>();

            int characterId = 98772;
            WalletScopes scopes = WalletScopes.esi_wallet_read_corporation_wallets_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, WalletScopesFlags = scopes };
            string json = "[\r\n  {\r\n    \"client_id\": 54321,\r\n    \"date\": \"2016-10-24T09:00:00Z\",\r\n    \"is_buy\": true,\r\n    \"journal_ref_id\": 67890,\r\n    \"location_id\": 60014719,\r\n    \"quantity\": 1,\r\n    \"transaction_id\": 1234567890,\r\n    \"type_id\": 587,\r\n    \"unit_price\": 1\r\n  }\r\n]";

            mockedWebClient.Setup(x => x.GetAsync(It.IsAny<WebHeaderCollection>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EsiModel { Model = json });

            InternalLatestWallet internalLatestWallet = new InternalLatestWallet(mockedWebClient.Object, string.Empty);

            IList<V1WalletCorporationTransactions> getCorporationJournals = await internalLatestWallet.CorporationTransactionsAsync(inputToken, 999, 1, 1);

            Assert.Equal(1, getCorporationJournals.Count);
            Assert.Equal(54321, getCorporationJournals[0].ClientId);
            Assert.Equal(new DateTime(2016, 10, 24, 09, 00, 00), getCorporationJournals[0].Date);
            Assert.True(getCorporationJournals[0].IsBuy);
            Assert.Equal(67890, getCorporationJournals[0].JournalRefId);
            Assert.Equal(60014719, getCorporationJournals[0].LocationId);
            Assert.Equal(1, getCorporationJournals[0].Quantity);
            Assert.Equal(1234567890, getCorporationJournals[0].TransactionId);
            Assert.Equal(587, getCorporationJournals[0].TypeId);
            Assert.Equal(1, getCorporationJournals[0].UnitPrice);
        }
    }
}
