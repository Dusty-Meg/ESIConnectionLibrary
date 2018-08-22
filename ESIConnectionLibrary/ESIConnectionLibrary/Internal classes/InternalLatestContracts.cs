using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.Internal_classes
{
    internal class InternalLatestContracts : IInternalLatestContracts
    {
        private readonly IWebClient _webClient;
        private readonly IMapper _mapper;
        private readonly bool _testing;

        public InternalLatestContracts(IWebClient webClient, string userAgent, bool testing = false)
        {
            IConfigurationProvider provider = new MapperConfiguration(cfg => { });

            _webClient = webClient ?? new WebClient(userAgent);
            _mapper = new Mapper(provider);
            _testing = testing;
        }

        public PagedModel<V1ContractsCharacter> Character(SsoToken token, int page)
        {
            StaticMethods.CheckToken(token, ContractScopes.esi_contracts_read_character_contracts_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.ContractsV1Character(token.CharacterId, page), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 300));

            IList<EsiV1ContractsCharacter> esiModel = JsonConvert.DeserializeObject<IList<EsiV1ContractsCharacter>>(esiRaw.Model);

            IList<V1ContractsCharacter> mapped = _mapper.Map<IList<EsiV1ContractsCharacter>, IList<V1ContractsCharacter>>(esiModel);

            return new PagedModel<V1ContractsCharacter> {Model = mapped, MaxPages = esiRaw.MaxPages, CurrentPage = page};
        }

        public async Task<PagedModel<V1ContractsCharacter>> CharacterAsync(SsoToken token, int page)
        {
            StaticMethods.CheckToken(token, ContractScopes.esi_contracts_read_character_contracts_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.ContractsV1Character(token.CharacterId, page), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 300));

            IList<EsiV1ContractsCharacter> esiModel = JsonConvert.DeserializeObject<IList<EsiV1ContractsCharacter>>(esiRaw.Model);

            IList<V1ContractsCharacter> mapped = _mapper.Map<IList<EsiV1ContractsCharacter>, IList<V1ContractsCharacter>>(esiModel);

            return new PagedModel<V1ContractsCharacter> { Model = mapped, MaxPages = esiRaw.MaxPages, CurrentPage = page };
        }

        public IList<V1ContractsCharacterBids> CharacterBids(SsoToken token, int contractId)
        {
            StaticMethods.CheckToken(token, ContractScopes.esi_contracts_read_character_contracts_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.ContractsV1CharacterBids(token.CharacterId, contractId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 300));

            IList<EsiV1ContractsCharacterBids> esiModel = JsonConvert.DeserializeObject<IList<EsiV1ContractsCharacterBids>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1ContractsCharacterBids>, IList<V1ContractsCharacterBids>>(esiModel);
        }

        public async Task<IList<V1ContractsCharacterBids>> CharacterBidsAsync(SsoToken token, int contractId)
        {
            StaticMethods.CheckToken(token, ContractScopes.esi_contracts_read_character_contracts_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.ContractsV1CharacterBids(token.CharacterId, contractId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 300));

            IList<EsiV1ContractsCharacterBids> esiModel = JsonConvert.DeserializeObject<IList<EsiV1ContractsCharacterBids>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1ContractsCharacterBids>, IList<V1ContractsCharacterBids>>(esiModel);
        }

        public IList<V1ContractsCharacterItems> CharacterItems(SsoToken token, int contractId)
        {
            StaticMethods.CheckToken(token, ContractScopes.esi_contracts_read_character_contracts_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.ContractsV1CharacterItems(token.CharacterId, contractId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1ContractsCharacterItems> esiModel = JsonConvert.DeserializeObject<IList<EsiV1ContractsCharacterItems>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1ContractsCharacterItems>, IList<V1ContractsCharacterItems>>(esiModel);
        }

        public async Task<IList<V1ContractsCharacterItems>> CharacterItemsAsync(SsoToken token, int contractId)
        {
            StaticMethods.CheckToken(token, ContractScopes.esi_contracts_read_character_contracts_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.ContractsV1CharacterItems(token.CharacterId, contractId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1ContractsCharacterItems> esiModel = JsonConvert.DeserializeObject<IList<EsiV1ContractsCharacterItems>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1ContractsCharacterItems>, IList<V1ContractsCharacterItems>>(esiModel);
        }

        public PagedModel<V1ContractsCorporation> Corporation(SsoToken token, int corporationId, int page)
        {
            StaticMethods.CheckToken(token, ContractScopes.esi_contracts_read_corporation_contracts_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.ContractsV1Corporation(corporationId, page), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 300));

            IList<EsiV1ContractsCorporation> esiModel = JsonConvert.DeserializeObject<IList<EsiV1ContractsCorporation>>(esiRaw.Model);

            IList<V1ContractsCorporation> mapped = _mapper.Map<IList<EsiV1ContractsCorporation>, IList<V1ContractsCorporation>>(esiModel);

            return new PagedModel<V1ContractsCorporation> { Model = mapped, MaxPages = esiRaw.MaxPages, CurrentPage = page };
        }

        public async Task<PagedModel<V1ContractsCorporation>> CorporationAsync(SsoToken token, int corporationId, int page)
        {
            StaticMethods.CheckToken(token, ContractScopes.esi_contracts_read_corporation_contracts_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.ContractsV1Corporation(corporationId, page), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 300));

            IList<EsiV1ContractsCorporation> esiModel = JsonConvert.DeserializeObject<IList<EsiV1ContractsCorporation>>(esiRaw.Model);

            IList<V1ContractsCorporation> mapped = _mapper.Map<IList<EsiV1ContractsCorporation>, IList<V1ContractsCorporation>>(esiModel);

            return new PagedModel<V1ContractsCorporation> { Model = mapped, MaxPages = esiRaw.MaxPages, CurrentPage = page };
        }

        public IList<V1ContractsCorporationBids> CorporationBids(SsoToken token, int corporationId, int contractId)
        {
            StaticMethods.CheckToken(token, ContractScopes.esi_contracts_read_corporation_contracts_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.ContractsV1CorporationBids(corporationId, contractId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1ContractsCorporationBids> esiModel = JsonConvert.DeserializeObject<IList<EsiV1ContractsCorporationBids>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1ContractsCorporationBids>, IList<V1ContractsCorporationBids>>(esiModel);
        }

        public async Task<IList<V1ContractsCorporationBids>> CorporationBidsAsync(SsoToken token, int corporationId, int contractId)
        {
            StaticMethods.CheckToken(token, ContractScopes.esi_contracts_read_corporation_contracts_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.ContractsV1CorporationBids(corporationId, contractId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1ContractsCorporationBids> esiModel = JsonConvert.DeserializeObject<IList<EsiV1ContractsCorporationBids>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1ContractsCorporationBids>, IList<V1ContractsCorporationBids>>(esiModel);
        }

        public IList<V1ContractsCorporationItems> CorporationItems(SsoToken token, int corporationId, int contractId)
        {
            StaticMethods.CheckToken(token, ContractScopes.esi_contracts_read_corporation_contracts_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.ContractsV1CorporationItems(corporationId, contractId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1ContractsCorporationItems> esiModel = JsonConvert.DeserializeObject<IList<EsiV1ContractsCorporationItems>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1ContractsCorporationItems>, IList<V1ContractsCorporationItems>>(esiModel);
        }

        public async Task<IList<V1ContractsCorporationItems>> CorporationItemsAsync(SsoToken token, int corporationId, int contractId)
        {
            StaticMethods.CheckToken(token, ContractScopes.esi_contracts_read_corporation_contracts_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.ContractsV1CorporationItems(corporationId, contractId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1ContractsCorporationItems> esiModel = JsonConvert.DeserializeObject<IList<EsiV1ContractsCorporationItems>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1ContractsCorporationItems>, IList<V1ContractsCorporationItems>>(esiModel);
        }
    }
}
