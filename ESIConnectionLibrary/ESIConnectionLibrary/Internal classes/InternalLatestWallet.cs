using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ESIConnectionLibrary.AutomapperMappings;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.Internal_classes
{
    internal class InternalLatestWallet : IInternalLatestWallet
    {
        private readonly IWebClient _webClient;
        private readonly IMapper _mapper;

        public InternalLatestWallet(IWebClient webClient, string userAgent)
        {
            IConfigurationProvider provider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<WalletMappings>();
            });

            _webClient = webClient ?? new WebClient(userAgent);
            _mapper = new Mapper(provider);
        }

        public double GetCharactersWallet(SsoToken token)
        {
            StaticMethods.CheckToken(token, WalletScopes.esi_wallet_read_character_wallet_v1);

            string url = StaticConnectionStrings.WalletV1CharactersWallet(token.CharacterId);

            EsiModel raw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 120));

            return JsonConvert.DeserializeObject<double>(raw.Model);
        }

        public async Task<double> GetCharactersWalletAsync(SsoToken token)
        {
            StaticMethods.CheckToken(token, WalletScopes.esi_wallet_read_character_wallet_v1);

            string url = StaticConnectionStrings.WalletV1CharactersWallet(token.CharacterId);

            EsiModel raw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 120));

            return JsonConvert.DeserializeObject<double>(raw.Model);
        }

        public PagedModel<V4WalletCharacterJournal> GetCharactersWalletJournal(SsoToken token, int page)
        {
            StaticMethods.CheckToken(token, WalletScopes.esi_wallet_read_character_wallet_v1);

            string url = StaticConnectionStrings.WalletV4CharactersWalletJournal(token.CharacterId, page);

            EsiModel raw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV4WalletCharacterJournal> esiWalletJournal = JsonConvert.DeserializeObject<IList<EsiV4WalletCharacterJournal>>(raw.Model);

            IList<V4WalletCharacterJournal> mapped = _mapper.Map<IList<EsiV4WalletCharacterJournal>, IList<V4WalletCharacterJournal>>(esiWalletJournal);

            return new PagedModel<V4WalletCharacterJournal>{ Model = mapped, MaxPages = raw.MaxPages.GetValueOrDefault(), CurrentPage = page };
        }

        public async Task<PagedModel<V4WalletCharacterJournal>> GetCharactersWalletJournalAsync(SsoToken token, int page)
        {
            StaticMethods.CheckToken(token, WalletScopes.esi_wallet_read_character_wallet_v1);

            string url = StaticConnectionStrings.WalletV4CharactersWalletJournal(token.CharacterId, page);

            EsiModel raw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV4WalletCharacterJournal> esiWalletJournal = JsonConvert.DeserializeObject<IList<EsiV4WalletCharacterJournal>>(raw.Model);

            IList<V4WalletCharacterJournal> mapped = _mapper.Map<IList<EsiV4WalletCharacterJournal>, IList<V4WalletCharacterJournal>>(esiWalletJournal);

            return new PagedModel<V4WalletCharacterJournal> { Model = mapped, MaxPages = raw.MaxPages.GetValueOrDefault(), CurrentPage = page };
        }

        public PagedModel<V1WalletCharacterTransactions> GetCharactersWalletTransaction(SsoToken token, int lastTransactionId)
        {
            StaticMethods.CheckToken(token, WalletScopes.esi_wallet_read_character_wallet_v1);

            string url = StaticConnectionStrings.WalletV4CharactersWalletTransaction(token.CharacterId, lastTransactionId);

            EsiModel raw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1WalletCharacterTransactions> esiWalletTransactions = JsonConvert.DeserializeObject<IList<EsiV1WalletCharacterTransactions>>(raw.Model);

            IList<V1WalletCharacterTransactions> mapped = _mapper.Map<IList<EsiV1WalletCharacterTransactions>, IList<V1WalletCharacterTransactions>>(esiWalletTransactions);

            return new PagedModel<V1WalletCharacterTransactions> { Model = mapped, CurrentPage = lastTransactionId, MaxPages = raw.MaxPages.GetValueOrDefault()};
        }

        public async Task<PagedModel<V1WalletCharacterTransactions>> GetCharactersWalletTransactionAsync(SsoToken token, int lastTransactionId)
        {
            StaticMethods.CheckToken(token, WalletScopes.esi_wallet_read_character_wallet_v1);

            string url = StaticConnectionStrings.WalletV4CharactersWalletTransaction(token.CharacterId, lastTransactionId);

            EsiModel raw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1WalletCharacterTransactions> esiWalletTransactions = JsonConvert.DeserializeObject<IList<EsiV1WalletCharacterTransactions>>(raw.Model);

            IList<V1WalletCharacterTransactions> mapped = _mapper.Map<IList<EsiV1WalletCharacterTransactions>, IList<V1WalletCharacterTransactions>>(esiWalletTransactions);

            return new PagedModel<V1WalletCharacterTransactions> { Model = mapped, CurrentPage = lastTransactionId, MaxPages = raw.MaxPages.GetValueOrDefault()};
        }

        public IList<V1WalletCorporationWallet> GetCorporationWallets(SsoToken token, int corporationId)
        {
            StaticMethods.CheckToken(token, WalletScopes.esi_wallet_read_corporation_wallets_v1);

            string url = StaticConnectionStrings.WalletV1CorporationWallets(corporationId);

            EsiModel raw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 300));

            IList<EsiV1WalletCorporationWallet> esiWallet = JsonConvert.DeserializeObject<IList<EsiV1WalletCorporationWallet>>(raw.Model);

            return _mapper.Map<IList<EsiV1WalletCorporationWallet>, IList<V1WalletCorporationWallet>>(esiWallet);
        }

        public async Task<IList<V1WalletCorporationWallet>> GetCorporationWalletsAsync(SsoToken token, int corporationId)
        {
            StaticMethods.CheckToken(token, WalletScopes.esi_wallet_read_corporation_wallets_v1);

            string url = StaticConnectionStrings.WalletV1CorporationWallets(corporationId);

            EsiModel raw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 300));

            IList<EsiV1WalletCorporationWallet> esiWallet = JsonConvert.DeserializeObject<IList<EsiV1WalletCorporationWallet>>(raw.Model);

            return _mapper.Map<IList<EsiV1WalletCorporationWallet>, IList<V1WalletCorporationWallet>>(esiWallet);
        }

        public PagedModel<V3WalletCorporationJournal> GetCorporationJournal(SsoToken token, int corporationId, int division, int page)
        {
            StaticMethods.CheckToken(token, WalletScopes.esi_wallet_read_corporation_wallets_v1);

            string url = StaticConnectionStrings.WalletV3CorporationDivisionsJournal(corporationId, division, page);

            EsiModel raw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV3WalletCorporationJournal> esiJournal = JsonConvert.DeserializeObject<IList<EsiV3WalletCorporationJournal>>(raw.Model);

            IList<V3WalletCorporationJournal> mapped = _mapper.Map<IList<EsiV3WalletCorporationJournal>, IList<V3WalletCorporationJournal>>(esiJournal);

            return new PagedModel<V3WalletCorporationJournal>{ Model = mapped, MaxPages = raw.MaxPages.GetValueOrDefault(), CurrentPage = page };
        }

        public async Task<PagedModel<V3WalletCorporationJournal>> GetCorporationJournalAsync(SsoToken token, int corporationId, int division, int page)
        {
            StaticMethods.CheckToken(token, WalletScopes.esi_wallet_read_corporation_wallets_v1);

            string url = StaticConnectionStrings.WalletV3CorporationDivisionsJournal(corporationId, division, page);

            EsiModel raw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV3WalletCorporationJournal> esiJournal = JsonConvert.DeserializeObject<IList<EsiV3WalletCorporationJournal>>(raw.Model);

            IList<V3WalletCorporationJournal> mapped = _mapper.Map<IList<EsiV3WalletCorporationJournal>, IList<V3WalletCorporationJournal>>(esiJournal);

            return new PagedModel<V3WalletCorporationJournal> { Model = mapped, MaxPages = raw.MaxPages.GetValueOrDefault(), CurrentPage = page };
        }

        public IList<V1WalletCorporationTransactions> GetCorporationTransactions(SsoToken token, int corporationId, int division, int lastTransactionId)
        {
            StaticMethods.CheckToken(token, WalletScopes.esi_wallet_read_corporation_wallets_v1);

            string url = StaticConnectionStrings.WalletV1CorporationDivisionsTransactions(corporationId, division, lastTransactionId);

            EsiModel raw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1WalletCorporationTransactions> esiTransactions = JsonConvert.DeserializeObject<IList<EsiV1WalletCorporationTransactions>>(raw.Model);

            return _mapper.Map<IList<EsiV1WalletCorporationTransactions>, IList<V1WalletCorporationTransactions>>(esiTransactions);
        }

        public async Task<IList<V1WalletCorporationTransactions>> GetCorporationTransactionsAsync(SsoToken token, int corporationId, int division, int lastTransactionId)
        {
            StaticMethods.CheckToken(token, WalletScopes.esi_wallet_read_corporation_wallets_v1);

            string url = StaticConnectionStrings.WalletV1CorporationDivisionsTransactions(corporationId, division, lastTransactionId);

            EsiModel raw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1WalletCorporationTransactions> esiTransactions = JsonConvert.DeserializeObject<IList<EsiV1WalletCorporationTransactions>>(raw.Model);

            return _mapper.Map<IList<EsiV1WalletCorporationTransactions>, IList<V1WalletCorporationTransactions>>(esiTransactions);
        }
    }
}
