using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Internal_classes
{
    internal interface IInternalLatestWallet
    {
        double Character(SsoToken token);
        Task<double> CharacterAsync(SsoToken token);
        PagedModel<V6WalletCharacterJournal> CharacterJournal(SsoToken token, int page);
        Task<PagedModel<V6WalletCharacterJournal>> CharacterJournalAsync(SsoToken token, int page);
        PagedModel<V1WalletCharacterTransactions> CharacterTransactions(SsoToken token, int lastTransactionId);
        Task<PagedModel<V1WalletCharacterTransactions>> CharacterTransactionsAsync(SsoToken token, int lastTransactionId);
        PagedModel<V4WalletCorporationJournal> CorporationJournal(SsoToken token, int corporationId, int division, int page);
        Task<PagedModel<V4WalletCorporationJournal>> CorporationJournalAsync(SsoToken token, int corporationId, int division, int page);
        IList<V1WalletCorporationTransactions> CorporationTransactions(SsoToken token, int corporationId, int division, int lastTransactionId);
        Task<IList<V1WalletCorporationTransactions>> CorporationTransactionsAsync(SsoToken token, int corporationId, int division, int lastTransactionId);
        IList<V1WalletCorporationWallet> Corporation(SsoToken token, int corporationId);
        Task<IList<V1WalletCorporationWallet>> CorporationAsync(SsoToken token, int corporationId);
    }
}