using System.Collections.Generic;
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
        PagedModel<V3WalletCorporationJournal> GetCorporationJournal(SsoToken token, int corporationId, int division, int page);
        Task<PagedModel<V3WalletCorporationJournal>> GetCorporationJournalAsync(SsoToken token, int corporationId, int division, int page);
        IList<V1WalletCorporationTransactions> GetCorporationTransactions(SsoToken token, int corporationId, int division, int lastTransactionId);
        Task<IList<V1WalletCorporationTransactions>> GetCorporationTransactionsAsync(SsoToken token, int corporationId, int division, int lastTransactionId);
        IList<V1WalletCorporationWallet> GetCorporationWallets(SsoToken token, int corporationId);
        Task<IList<V1WalletCorporationWallet>> GetCorporationWalletsAsync(SsoToken token, int corporationId);
    }
}