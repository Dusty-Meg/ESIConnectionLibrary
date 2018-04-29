using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Internal_classes
{
    internal interface IInternalLatestWallet
    {
        PagedModel<V4WalletCharacterJournal> GetCharactersWalletJournal(SsoToken token, int characterId, int page);
        Task<PagedModel<V4WalletCharacterJournal>> GetCharactersWalletJournalAsync(SsoToken token, int characterId, int page);
        PagedModel<V1WalletCharacterTransactions> GetCharactersWalletTransaction(SsoToken token, int characterId, int lastTransactionId);
        Task<PagedModel<V1WalletCharacterTransactions>> GetCharactersWalletTransactionAsync(SsoToken token, int characterId, int lastTransactionId);
    }
}