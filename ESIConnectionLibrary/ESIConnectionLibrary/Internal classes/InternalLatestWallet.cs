using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.Internal_classes
{
    internal class InternalLatestWallet : IInternalLatestWallet
    {
        private readonly IWebClient _webClient;
        private readonly IMapper _mapper;
        private readonly bool _testing;

        public InternalLatestWallet(IWebClient webClient, string userAgent, bool testing = false)
        {
            IConfigurationProvider provider = new MapperConfiguration(cfg => { });

            _webClient = webClient ?? new WebClient(userAgent);
            _mapper = new Mapper(provider);
            _testing = testing;
        }

        public double Character(SsoToken token)
        {
            StaticMethods.CheckToken(token, WalletScopes.esi_wallet_read_character_wallet_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.WalletV1CharactersWallet(token.CharacterId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 120));

            return JsonConvert.DeserializeObject<double>(esiRaw.Model);
        }

        public async Task<double> CharacterAsync(SsoToken token)
        {
            StaticMethods.CheckToken(token, WalletScopes.esi_wallet_read_character_wallet_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.WalletV1CharactersWallet(token.CharacterId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 120));

            return JsonConvert.DeserializeObject<double>(esiRaw.Model);
        }

        public PagedModel<V5WalletCharacterJournal> CharacterJournal(SsoToken token, int page)
        {
            StaticMethods.CheckToken(token, WalletScopes.esi_wallet_read_character_wallet_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.WalletV5CharactersWalletJournal(token.CharacterId, page), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV5WalletCharacterJournal> esiModel = JsonConvert.DeserializeObject<IList<EsiV5WalletCharacterJournal>>(esiRaw.Model);

            IList<V5WalletCharacterJournal> mapped = _mapper.Map<IList<EsiV5WalletCharacterJournal>, IList<V5WalletCharacterJournal>>(esiModel);

            return new PagedModel<V5WalletCharacterJournal>{ Model = mapped, MaxPages = esiRaw.MaxPages, CurrentPage = page };
        }

        public async Task<PagedModel<V5WalletCharacterJournal>> CharacterJournalAsync(SsoToken token, int page)
        {
            StaticMethods.CheckToken(token, WalletScopes.esi_wallet_read_character_wallet_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.WalletV5CharactersWalletJournal(token.CharacterId, page), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV5WalletCharacterJournal> esiModel = JsonConvert.DeserializeObject<IList<EsiV5WalletCharacterJournal>>(esiRaw.Model);

            IList<V5WalletCharacterJournal> mapped = _mapper.Map<IList<EsiV5WalletCharacterJournal>, IList<V5WalletCharacterJournal>>(esiModel);

            return new PagedModel<V5WalletCharacterJournal> { Model = mapped, MaxPages = esiRaw.MaxPages, CurrentPage = page };
        }

        public PagedModel<V1WalletCharacterTransactions> CharacterTransactions(SsoToken token, int lastTransactionId)
        {
            StaticMethods.CheckToken(token, WalletScopes.esi_wallet_read_character_wallet_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.WalletV4CharactersWalletTransaction(token.CharacterId, lastTransactionId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1WalletCharacterTransactions> esiModel = JsonConvert.DeserializeObject<IList<EsiV1WalletCharacterTransactions>>(esiRaw.Model);

            IList<V1WalletCharacterTransactions> mapped = _mapper.Map<IList<EsiV1WalletCharacterTransactions>, IList<V1WalletCharacterTransactions>>(esiModel);

            return new PagedModel<V1WalletCharacterTransactions> { Model = mapped, CurrentPage = lastTransactionId, MaxPages = esiRaw.MaxPages};
        }

        public async Task<PagedModel<V1WalletCharacterTransactions>> CharacterTransactionsAsync(SsoToken token, int lastTransactionId)
        {
            StaticMethods.CheckToken(token, WalletScopes.esi_wallet_read_character_wallet_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.WalletV4CharactersWalletTransaction(token.CharacterId, lastTransactionId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1WalletCharacterTransactions> esiModel = JsonConvert.DeserializeObject<IList<EsiV1WalletCharacterTransactions>>(esiRaw.Model);

            IList<V1WalletCharacterTransactions> mapped = _mapper.Map<IList<EsiV1WalletCharacterTransactions>, IList<V1WalletCharacterTransactions>>(esiModel);

            return new PagedModel<V1WalletCharacterTransactions> { Model = mapped, CurrentPage = lastTransactionId, MaxPages = esiRaw.MaxPages};
        }

        public IList<V1WalletCorporationWallet> Corporation(SsoToken token, int corporationId)
        {
            StaticMethods.CheckToken(token, WalletScopes.esi_wallet_read_corporation_wallets_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.WalletV1CorporationWallets(corporationId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 300));

            IList<EsiV1WalletCorporationWallet> esiModel = JsonConvert.DeserializeObject<IList<EsiV1WalletCorporationWallet>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1WalletCorporationWallet>, IList<V1WalletCorporationWallet>>(esiModel);
        }

        public async Task<IList<V1WalletCorporationWallet>> CorporationAsync(SsoToken token, int corporationId)
        {
            StaticMethods.CheckToken(token, WalletScopes.esi_wallet_read_corporation_wallets_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.WalletV1CorporationWallets(corporationId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 300));

            IList<EsiV1WalletCorporationWallet> esiModel = JsonConvert.DeserializeObject<IList<EsiV1WalletCorporationWallet>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1WalletCorporationWallet>, IList<V1WalletCorporationWallet>>(esiModel);
        }

        public PagedModel<V3WalletCorporationJournal> CorporationJournal(SsoToken token, int corporationId, int division, int page)
        {
            StaticMethods.CheckToken(token, WalletScopes.esi_wallet_read_corporation_wallets_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.WalletV3CorporationDivisionsJournal(corporationId, division, page), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV3WalletCorporationJournal> esiModel = JsonConvert.DeserializeObject<IList<EsiV3WalletCorporationJournal>>(esiRaw.Model);

            IList<V3WalletCorporationJournal> mapped = _mapper.Map<IList<EsiV3WalletCorporationJournal>, IList<V3WalletCorporationJournal>>(esiModel);

            return new PagedModel<V3WalletCorporationJournal>{ Model = mapped, MaxPages = esiRaw.MaxPages, CurrentPage = page };
        }

        public async Task<PagedModel<V3WalletCorporationJournal>> CorporationJournalAsync(SsoToken token, int corporationId, int division, int page)
        {
            StaticMethods.CheckToken(token, WalletScopes.esi_wallet_read_corporation_wallets_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.WalletV3CorporationDivisionsJournal(corporationId, division, page), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV3WalletCorporationJournal> esiModel = JsonConvert.DeserializeObject<IList<EsiV3WalletCorporationJournal>>(esiRaw.Model);

            IList<V3WalletCorporationJournal> mapped = _mapper.Map<IList<EsiV3WalletCorporationJournal>, IList<V3WalletCorporationJournal>>(esiModel);

            return new PagedModel<V3WalletCorporationJournal> { Model = mapped, MaxPages = esiRaw.MaxPages, CurrentPage = page };
        }

        public IList<V1WalletCorporationTransactions> CorporationTransactions(SsoToken token, int corporationId, int division, int lastTransactionId)
        {
            StaticMethods.CheckToken(token, WalletScopes.esi_wallet_read_corporation_wallets_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.WalletV1CorporationDivisionsTransactions(corporationId, division, lastTransactionId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1WalletCorporationTransactions> esiModel = JsonConvert.DeserializeObject<IList<EsiV1WalletCorporationTransactions>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1WalletCorporationTransactions>, IList<V1WalletCorporationTransactions>>(esiModel);
        }

        public async Task<IList<V1WalletCorporationTransactions>> CorporationTransactionsAsync(SsoToken token, int corporationId, int division, int lastTransactionId)
        {
            StaticMethods.CheckToken(token, WalletScopes.esi_wallet_read_corporation_wallets_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.WalletV1CorporationDivisionsTransactions(corporationId, division, lastTransactionId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1WalletCorporationTransactions> esiModel = JsonConvert.DeserializeObject<IList<EsiV1WalletCorporationTransactions>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1WalletCorporationTransactions>, IList<V1WalletCorporationTransactions>>(esiModel);
        }
    }
}
