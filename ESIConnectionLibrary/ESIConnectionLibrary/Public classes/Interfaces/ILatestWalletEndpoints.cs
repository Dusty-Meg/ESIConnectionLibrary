using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public interface ILatestWalletEndpoints
    {
        double GetCharactersWallet(SsoToken token);
        Task<double> GetCharactersWalletAsync(SsoToken token);
        PagedModel<V4WalletCharacterJournal> GetCharactersWalletJournal(SsoToken token, int page);
        Task<PagedModel<V4WalletCharacterJournal>> GetCharactersWalletJournalAsync(SsoToken token, int page);
        PagedModel<V1WalletCharacterTransactions> GetCharactersWalletTransaction(SsoToken token, int lastTransactionId);
        Task<PagedModel<V1WalletCharacterTransactions>> GetCharactersWalletTransactionAsync(SsoToken token, int lastTransactionId);
    }
}