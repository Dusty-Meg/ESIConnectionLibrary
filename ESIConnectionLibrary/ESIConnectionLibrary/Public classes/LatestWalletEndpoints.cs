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

        public double GetCharactersWallet(SsoToken token, int characterId)
        {
            return _internalLatestWallet.GetCharactersWallet(token, characterId);
        }

        public async Task<double> GetCharactersWalletAsync(SsoToken token, int characterId)
        {
            return await _internalLatestWallet.GetCharactersWalletAsync(token, characterId);
        }

        public PagedModel<V4WalletCharacterJournal> GetCharactersWalletJournal(SsoToken token, int characterId, int page)
        {
            if (page < 1)
            {
                throw new ESIException("Pages below 1 is not allowed!");
            }

            return _internalLatestWallet.GetCharactersWalletJournal(token, characterId, page);
        }

        public async Task<PagedModel<V4WalletCharacterJournal>> GetCharactersWalletJournalAsync(SsoToken token, int characterId, int page)
        {
            if (page < 1)
            {
                throw new ESIException("Pages below 1 is not allowed!");
            }

            return await _internalLatestWallet.GetCharactersWalletJournalAsync(token, characterId, page);
        }

        public PagedModel<V1WalletCharacterTransactions> GetCharactersWalletTransaction(SsoToken token, int characterId, int lastTransactionId)
        {
            return _internalLatestWallet.GetCharactersWalletTransaction(token, characterId, lastTransactionId);
        }

        public async Task<PagedModel<V1WalletCharacterTransactions>> GetCharactersWalletTransactionAsync(SsoToken token, int characterId, int lastTransactionId)
        {
            return await _internalLatestWallet.GetCharactersWalletTransactionAsync(token, characterId, lastTransactionId);
        }
    }
}
