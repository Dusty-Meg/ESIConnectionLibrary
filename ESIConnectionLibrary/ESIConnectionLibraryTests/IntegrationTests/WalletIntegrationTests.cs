using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;
using ESIConnectionLibrary.Public_classes;
using Xunit;

namespace ESIConnectionLibraryTests.IntegrationTests
{
    public class WalletIntegrationTests
    {
        [Fact]
        public void Character_successfully_returns_a_double()
        {
            int characterId = 98772;
            WalletScopes scopes = WalletScopes.esi_wallet_read_character_wallet_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, WalletScopesFlags = scopes };

            LatestWalletEndpoints internalLatestWallet = new LatestWalletEndpoints(string.Empty, true);

            double getCharactersWallet = internalLatestWallet.Character(inputToken);

            Assert.Equal(29500.01, getCharactersWallet);
        }

        [Fact]
        public async Task CharacterAsync_successfully_returns_a_double()
        {
            int characterId = 98772;
            WalletScopes scopes = WalletScopes.esi_wallet_read_character_wallet_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, WalletScopesFlags = scopes };

            LatestWalletEndpoints internalLatestWallet = new LatestWalletEndpoints(string.Empty, true);

            double getCharactersWallet = await internalLatestWallet.CharacterAsync(inputToken);

            Assert.Equal(29500.01, getCharactersWallet);
        }

        [Fact]
        public void CharacterJournal_successfully_returns_a_pagedModelWalletCharacterJournal()
        {
            int characterId = 98772;
            int page = 1;
            WalletScopes scopes = WalletScopes.esi_wallet_read_character_wallet_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, WalletScopesFlags = scopes };

            LatestWalletEndpoints internalLatestWallet = new LatestWalletEndpoints(string.Empty, true);

            PagedModel<V5WalletCharacterJournal> getCharactersWalletJournal = internalLatestWallet.CharacterJournal(inputToken, page);

            Assert.Equal(1, getCharactersWalletJournal.CurrentPage);
            Assert.Equal(1, getCharactersWalletJournal.Model.Count);
            Assert.Equal(WalletRefType.ContractDeposit, getCharactersWalletJournal.Model[0].RefType);
            Assert.Equal(WalletContextIdType.ContractId, getCharactersWalletJournal.Model[0].ContextIdType);
            Assert.Equal(-100000, getCharactersWalletJournal.Model[0].Amount);
            Assert.Equal(500000.4316, getCharactersWalletJournal.Model[0].Balance);
        }

        [Fact]
        public async Task CharacterJournalAsync_successfully_returns_a_pagedModelWalletCharacterJournalAsync()
        {
            int characterId = 98772;
            int page = 1;
            WalletScopes scopes = WalletScopes.esi_wallet_read_character_wallet_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, WalletScopesFlags = scopes };

            LatestWalletEndpoints internalLatestWallet = new LatestWalletEndpoints(string.Empty, true);

            PagedModel<V5WalletCharacterJournal> getCharactersWalletJournal = await internalLatestWallet.CharacterJournalAsync(inputToken, page);

            Assert.Equal(1, getCharactersWalletJournal.CurrentPage);
            Assert.Equal(1, getCharactersWalletJournal.Model.Count);
            Assert.Equal(WalletRefType.ContractDeposit, getCharactersWalletJournal.Model[0].RefType);
            Assert.Equal(WalletContextIdType.ContractId, getCharactersWalletJournal.Model[0].ContextIdType);
            Assert.Equal(-100000, getCharactersWalletJournal.Model[0].Amount);
            Assert.Equal(500000.4316, getCharactersWalletJournal.Model[0].Balance);
        }

        [Fact]
        public void CharacterTransactions_successfully_returns_a_pagedModelWalletCharacterTransaction()
        {
            int characterId = 98772;
            int lastId = 1;
            WalletScopes scopes = WalletScopes.esi_wallet_read_character_wallet_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, WalletScopesFlags = scopes };

            LatestWalletEndpoints internalLatestWallet = new LatestWalletEndpoints(string.Empty, true);

            PagedModel<V1WalletCharacterTransactions> getCharactersWalletTransactions = internalLatestWallet.CharacterTransactions(inputToken, lastId);

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
        public async Task CharacterTransactionsAsync_successfully_returns_a_pagedModelWalletCharacterTransaction()
        {
            int characterId = 98772;
            int lastId = 1;
            WalletScopes scopes = WalletScopes.esi_wallet_read_character_wallet_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, WalletScopesFlags = scopes };

            LatestWalletEndpoints internalLatestWallet = new LatestWalletEndpoints(string.Empty, true);

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
            int characterId = 98772;
            WalletScopes scopes = WalletScopes.esi_wallet_read_corporation_wallets_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, WalletScopesFlags = scopes };

            LatestWalletEndpoints internalLatestWallet = new LatestWalletEndpoints(string.Empty, true);

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
            int characterId = 98772;
            WalletScopes scopes = WalletScopes.esi_wallet_read_corporation_wallets_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, WalletScopesFlags = scopes };

            LatestWalletEndpoints internalLatestWallet = new LatestWalletEndpoints(string.Empty, true);

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
            int characterId = 98772;
            WalletScopes scopes = WalletScopes.esi_wallet_read_corporation_wallets_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, WalletScopesFlags = scopes };

            LatestWalletEndpoints internalLatestWallet = new LatestWalletEndpoints(string.Empty, true);

            PagedModel<V3WalletCorporationJournal> getCorporationJournals = internalLatestWallet.CorporationJournal(inputToken, 999, 1, 1);

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
        public async Task CorporationJournalAsync_successfully_returns_a_listV3WalletCorporationJournal()
        {
            int characterId = 98772;
            WalletScopes scopes = WalletScopes.esi_wallet_read_corporation_wallets_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, WalletScopesFlags = scopes };

            LatestWalletEndpoints internalLatestWallet = new LatestWalletEndpoints(string.Empty, true);

            PagedModel<V3WalletCorporationJournal> getCorporationJournals = await internalLatestWallet.CorporationJournalAsync(inputToken, 999, 1, 1);

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
            int characterId = 98772;
            WalletScopes scopes = WalletScopes.esi_wallet_read_corporation_wallets_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, WalletScopesFlags = scopes };

            LatestWalletEndpoints internalLatestWallet = new LatestWalletEndpoints(string.Empty, true);

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
            int characterId = 98772;
            WalletScopes scopes = WalletScopes.esi_wallet_read_corporation_wallets_v1;

            SsoToken inputToken = new SsoToken { AccessToken = "This is a old access token", RefreshToken = "This is a old refresh token", CharacterId = characterId, WalletScopesFlags = scopes };

            LatestWalletEndpoints internalLatestWallet = new LatestWalletEndpoints(string.Empty, true);

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
