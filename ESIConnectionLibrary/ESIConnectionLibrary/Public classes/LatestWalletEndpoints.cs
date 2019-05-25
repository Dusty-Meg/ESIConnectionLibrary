using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.Exceptions;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public class LatestWalletEndpoints : ILatestWalletEndpoints
    {
        private readonly IInternalLatestWallet _internalLatestWallet;

        public LatestWalletEndpoints(string userAgent, bool testing = false)
        {
            _internalLatestWallet = new InternalLatestWallet(null, userAgent, testing);
        }

        public double Character(SsoToken token)
        {
            return _internalLatestWallet.Character(token);
        }

        public async Task<double> CharacterAsync(SsoToken token)
        {
            return await _internalLatestWallet.CharacterAsync(token);
        }

        public PagedModel<V5WalletCharacterJournal> CharacterJournal(SsoToken token, int page)
        {
            if (page < 1)
            {
                throw new EsiException("Pages below 1 is not allowed!");
            }

            return _internalLatestWallet.CharacterJournal(token, page);
        }

        public async Task<PagedModel<V5WalletCharacterJournal>> CharacterJournalAsync(SsoToken token, int page)
        {
            if (page < 1)
            {
                throw new EsiException("Pages below 1 is not allowed!");
            }

            return await _internalLatestWallet.CharacterJournalAsync(token, page);
        }

        public PagedModel<V1WalletCharacterTransactions> CharacterTransactions(SsoToken token, int lastTransactionId)
        {
            return _internalLatestWallet.CharacterTransactions(token, lastTransactionId);
        }

        public async Task<PagedModel<V1WalletCharacterTransactions>> CharacterTransactionsAsync(SsoToken token, int lastTransactionId)
        {
            return await _internalLatestWallet.CharacterTransactionsAsync(token, lastTransactionId);
        }

        public IList<V1WalletCorporationWallet> Corporation(SsoToken token, int corporationId)
        {
            return _internalLatestWallet.Corporation(token, corporationId);
        }

        public async Task<IList<V1WalletCorporationWallet>> CorporationAsync(SsoToken token, int corporationId)
        {
            return await _internalLatestWallet.CorporationAsync(token, corporationId);
        }

        public PagedModel<V4WalletCorporationJournal> CorporationJournal(SsoToken token, int corporationId, int division, int page)
        {
            return _internalLatestWallet.CorporationJournal(token, corporationId, division, page);
        }

        public async Task<PagedModel<V4WalletCorporationJournal>> CorporationJournalAsync(SsoToken token, int corporationId, int division, int page)
        {
            return await _internalLatestWallet.CorporationJournalAsync(token, corporationId, division, page);
        }

        public IList<V1WalletCorporationTransactions> CorporationTransactions(SsoToken token, int corporationId, int division, int lastTransactionId)
        {
            return _internalLatestWallet.CorporationTransactions(token, corporationId, division, lastTransactionId);
        }

        public async Task<IList<V1WalletCorporationTransactions>> CorporationTransactionsAsync(SsoToken token, int corporationId, int division, int lastTransactionId)
        {
            return await _internalLatestWallet.CorporationTransactionsAsync(token, corporationId, division, lastTransactionId);
        }
    }
}
