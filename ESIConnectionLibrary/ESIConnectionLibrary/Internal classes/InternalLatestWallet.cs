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

        public double GetCharactersWallet(SsoToken token, int characterId)
        {
            StaticMethods.CheckToken(token, WalletScopes.esi_wallet_read_character_wallet_v1);

            string url = StaticConnectionStrings.WalletV1CharactersWallet(characterId);

            string raw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 120));

            return JsonConvert.DeserializeObject<double>(raw);
        }

        public async Task<double> GetCharactersWalletAsync(SsoToken token, int characterId)
        {
            StaticMethods.CheckToken(token, WalletScopes.esi_wallet_read_character_wallet_v1);

            string url = StaticConnectionStrings.WalletV1CharactersWallet(characterId);

            string raw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 120));

            return JsonConvert.DeserializeObject<double>(raw);
        }

        public PagedModel<V4WalletCharacterJournal> GetCharactersWalletJournal(SsoToken token, int characterId, int page)
        {
            StaticMethods.CheckToken(token, WalletScopes.esi_wallet_read_character_wallet_v1);

            string url = StaticConnectionStrings.WalletV4CharactersWalletJournal(characterId, page);

            PagedJson raw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.GetPaged(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV4WalletCharacterJournal> esiWalletJournal = JsonConvert.DeserializeObject<IList<EsiV4WalletCharacterJournal>>(raw.Response);

            IList<V4WalletCharacterJournal> mapped = _mapper.Map<IList<EsiV4WalletCharacterJournal>, IList<V4WalletCharacterJournal>>(esiWalletJournal);

            return new PagedModel<V4WalletCharacterJournal>{ Model = mapped, MaxPages = raw.MaxPages.GetValueOrDefault(), CurrentPage = page };
        }

        public async Task<PagedModel<V4WalletCharacterJournal>> GetCharactersWalletJournalAsync(SsoToken token, int characterId, int page)
        {
            StaticMethods.CheckToken(token, WalletScopes.esi_wallet_read_character_wallet_v1);

            string url = StaticConnectionStrings.WalletV4CharactersWalletJournal(characterId, page);

            PagedJson raw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetPagedAsync(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV4WalletCharacterJournal> esiWalletJournal = JsonConvert.DeserializeObject<IList<EsiV4WalletCharacterJournal>>(raw.Response);

            IList<V4WalletCharacterJournal> mapped = _mapper.Map<IList<EsiV4WalletCharacterJournal>, IList<V4WalletCharacterJournal>>(esiWalletJournal);

            return new PagedModel<V4WalletCharacterJournal> { Model = mapped, MaxPages = raw.MaxPages.GetValueOrDefault(), CurrentPage = page };
        }

        public PagedModel<V1WalletCharacterTransactions> GetCharactersWalletTransaction(SsoToken token, int characterId, int lastTransactionId)
        {
            StaticMethods.CheckToken(token, WalletScopes.esi_wallet_read_character_wallet_v1);

            string url = StaticConnectionStrings.WalletV4CharactersWalletTransaction(characterId, lastTransactionId);

            PagedJson raw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.GetPaged(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1WalletCharacterTransactions> esiWalletTransactions = JsonConvert.DeserializeObject<IList<EsiV1WalletCharacterTransactions>>(raw.Response);

            IList<V1WalletCharacterTransactions> mapped = _mapper.Map<IList<EsiV1WalletCharacterTransactions>, IList<V1WalletCharacterTransactions>>(esiWalletTransactions);

            return new PagedModel<V1WalletCharacterTransactions> { Model = mapped, CurrentPage = lastTransactionId };
        }

        public async Task<PagedModel<V1WalletCharacterTransactions>> GetCharactersWalletTransactionAsync(SsoToken token, int characterId, int lastTransactionId)
        {
            StaticMethods.CheckToken(token, WalletScopes.esi_wallet_read_character_wallet_v1);

            string url = StaticConnectionStrings.WalletV4CharactersWalletTransaction(characterId, lastTransactionId);

            PagedJson raw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetPagedAsync(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1WalletCharacterTransactions> esiWalletTransactions = JsonConvert.DeserializeObject<IList<EsiV1WalletCharacterTransactions>>(raw.Response);

            IList<V1WalletCharacterTransactions> mapped = _mapper.Map<IList<EsiV1WalletCharacterTransactions>, IList<V1WalletCharacterTransactions>>(esiWalletTransactions);

            return new PagedModel<V1WalletCharacterTransactions> { Model = mapped, CurrentPage = lastTransactionId };
        }
    }
}
