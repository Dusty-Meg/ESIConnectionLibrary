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

        public LatestWalletEndpoints(string userAgent)
        {
            _internalLatestWallet = new InternalLatestWallet(null, userAgent);
        }

        public double GetCharactersWallet(SsoToken token)
        {
            return _internalLatestWallet.GetCharactersWallet(token);
        }

        public async Task<double> GetCharactersWalletAsync(SsoToken token)
        {
            return await _internalLatestWallet.GetCharactersWalletAsync(token);
        }

        public PagedModel<V4WalletCharacterJournal> GetCharactersWalletJournal(SsoToken token, int page)
        {
            if (page < 1)
            {
                throw new ESIException("Pages below 1 is not allowed!");
            }

            return _internalLatestWallet.GetCharactersWalletJournal(token, page);
        }

        public async Task<PagedModel<V4WalletCharacterJournal>> GetCharactersWalletJournalAsync(SsoToken token, int page)
        {
            if (page < 1)
            {
                throw new ESIException("Pages below 1 is not allowed!");
            }

            return await _internalLatestWallet.GetCharactersWalletJournalAsync(token, page);
        }

        public PagedModel<V1WalletCharacterTransactions> GetCharactersWalletTransaction(SsoToken token, int lastTransactionId)
        {
            return _internalLatestWallet.GetCharactersWalletTransaction(token, lastTransactionId);
        }

        public async Task<PagedModel<V1WalletCharacterTransactions>> GetCharactersWalletTransactionAsync(SsoToken token, int lastTransactionId)
        {
            return await _internalLatestWallet.GetCharactersWalletTransactionAsync(token, lastTransactionId);
        }

        public IList<V1WalletCorporationWallet> GetCorporationWallets(SsoToken token, int corporationId)
        {
            return _internalLatestWallet.GetCorporationWallets(token, corporationId);
        }

        public async Task<IList<V1WalletCorporationWallet>> GetCorporationWalletsAsync(SsoToken token, int corporationId)
        {
            return await _internalLatestWallet.GetCorporationWalletsAsync(token, corporationId);
        }

        public PagedModel<V3WalletCorporationJournal> GetCorporationJournal(SsoToken token, int corporationId, int division, int page)
        {
            return _internalLatestWallet.GetCorporationJournal(token, corporationId, division, page);
        }

        public async Task<PagedModel<V3WalletCorporationJournal>> GetCorporationJournalAsync(SsoToken token, int corporationId, int division, int page)
        {
            return await _internalLatestWallet.GetCorporationJournalAsync(token, corporationId, division, page);
        }

        public IList<V1WalletCorporationTransactions> GetCorporationTransactions(SsoToken token, int corporationId, int division, int lastTransactionId)
        {
            return _internalLatestWallet.GetCorporationTransactions(token, corporationId, division, lastTransactionId);
        }

        public async Task<IList<V1WalletCorporationTransactions>> GetCorporationTransactionsAsync(SsoToken token, int corporationId, int division, int lastTransactionId)
        {
            return await _internalLatestWallet.GetCorporationTransactionsAsync(token, corporationId, division, lastTransactionId);
        }
    }
}
