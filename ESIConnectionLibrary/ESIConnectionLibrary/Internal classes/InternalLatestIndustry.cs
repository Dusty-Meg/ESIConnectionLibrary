using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.Internal_classes
{
    internal class InternalLatestIndustry : IInternalLatestIndustry
    {
        private readonly IWebClient _webClient;
        private readonly IMapper _mapper;
        private readonly bool _testing;

        public InternalLatestIndustry(IWebClient webClient, string userAgent, bool testing = false)
        {
            IConfigurationProvider provider = new MapperConfiguration(cfg => { });

            _webClient = webClient ?? new WebClient(userAgent);
            _mapper = new Mapper(provider);
            _testing = testing;
        }

        public IList<V1IndustryCharacter> Character(SsoToken token, bool includeCompletedJobs)
        {
            StaticMethods.CheckToken(token, IndustryScopes.esi_industry_read_character_jobs_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.IndustryV1CharacterJobs(token.CharacterId, includeCompletedJobs), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 300));

            IList<EsiV1IndustryCharacter> esiModel = JsonConvert.DeserializeObject<IList<EsiV1IndustryCharacter>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1IndustryCharacter>, IList<V1IndustryCharacter>>(esiModel);
        }

        public async Task<IList<V1IndustryCharacter>> CharacterAsync(SsoToken token, bool includeCompletedJobs)
        {
            StaticMethods.CheckToken(token, IndustryScopes.esi_industry_read_character_jobs_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.IndustryV1CharacterJobs(token.CharacterId, includeCompletedJobs), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 300));

            IList<EsiV1IndustryCharacter> esiModel = JsonConvert.DeserializeObject<IList<EsiV1IndustryCharacter>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1IndustryCharacter>, IList<V1IndustryCharacter>>(esiModel);
        }

        public IList<V1IndustryCharacterMining> CharacterMining(SsoToken token, int page)
        {
            StaticMethods.CheckToken(token, IndustryScopes.esi_industry_read_character_mining_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.IndustryV1CharacterMining(token.CharacterId, page), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 600));

            IList<EsiV1IndustryCharacterMining> esiModel = JsonConvert.DeserializeObject<IList<EsiV1IndustryCharacterMining>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1IndustryCharacterMining>, IList<V1IndustryCharacterMining>>(esiModel);
        }

        public async Task<IList<V1IndustryCharacterMining>> CharacterMiningAsync(SsoToken token, int page)
        {
            StaticMethods.CheckToken(token, IndustryScopes.esi_industry_read_character_mining_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.IndustryV1CharacterMining(token.CharacterId, page), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 600));

            IList<EsiV1IndustryCharacterMining> esiModel = JsonConvert.DeserializeObject<IList<EsiV1IndustryCharacterMining>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1IndustryCharacterMining>, IList<V1IndustryCharacterMining>>(esiModel);
        }

        public IList<V1IndustryCorporationExtractions> CorporationExtractions(SsoToken token, int corporationId, int page)
        {
            StaticMethods.CheckToken(token, IndustryScopes.esi_industry_read_corporation_mining_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.IndustryV1CorporationExtractions(corporationId, page), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 1800));

            IList<EsiV1IndustryCorporationExtractions> esiModel = JsonConvert.DeserializeObject<IList<EsiV1IndustryCorporationExtractions>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1IndustryCorporationExtractions>, IList<V1IndustryCorporationExtractions>>(esiModel);
        }

        public async Task<IList<V1IndustryCorporationExtractions>> CorporationExtractionsAsync(SsoToken token, int corporationId, int page)
        {
            StaticMethods.CheckToken(token, IndustryScopes.esi_industry_read_corporation_mining_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.IndustryV1CorporationExtractions(corporationId, page), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 1800));

            IList<EsiV1IndustryCorporationExtractions> esiModel = JsonConvert.DeserializeObject<IList<EsiV1IndustryCorporationExtractions>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1IndustryCorporationExtractions>, IList<V1IndustryCorporationExtractions>>(esiModel);
        }

        public IList<V1IndustryCorporationObservers> CorporationObservers(SsoToken token, int corporationId, int page)
        {
            StaticMethods.CheckToken(token, IndustryScopes.esi_industry_read_corporation_mining_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.IndustryV1CorporationObservers(corporationId, page), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1IndustryCorporationObservers> esiModel = JsonConvert.DeserializeObject<IList<EsiV1IndustryCorporationObservers>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1IndustryCorporationObservers>, IList<V1IndustryCorporationObservers>>(esiModel);
        }

        public async Task<IList<V1IndustryCorporationObservers>> CorporationObserversAsync(SsoToken token, int corporationId, int page)
        {
            StaticMethods.CheckToken(token, IndustryScopes.esi_industry_read_corporation_mining_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.IndustryV1CorporationObservers(corporationId, page), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1IndustryCorporationObservers> esiModel = JsonConvert.DeserializeObject<IList<EsiV1IndustryCorporationObservers>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1IndustryCorporationObservers>, IList<V1IndustryCorporationObservers>>(esiModel);
        }

        public IList<V1IndustryCorporationObserver> CorporationObserver(SsoToken token, int corporationId, long observerId, int page)
        {
            StaticMethods.CheckToken(token, IndustryScopes.esi_industry_read_corporation_mining_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.IndustryV1CorporationObserver(corporationId, observerId, page), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1IndustryCorporationObserver> esiModel = JsonConvert.DeserializeObject<IList<EsiV1IndustryCorporationObserver>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1IndustryCorporationObserver>, IList<V1IndustryCorporationObserver>>(esiModel);
        }

        public async Task<IList<V1IndustryCorporationObserver>> CorporationObserverAsync(SsoToken token, int corporationId, long observerId, int page)
        {
            StaticMethods.CheckToken(token, IndustryScopes.esi_industry_read_corporation_mining_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.IndustryV1CorporationObserver(corporationId, observerId, page), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1IndustryCorporationObserver> esiModel = JsonConvert.DeserializeObject<IList<EsiV1IndustryCorporationObserver>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1IndustryCorporationObserver>, IList<V1IndustryCorporationObserver>>(esiModel);
        }

        public IList<V1IndustryCorporation> Corporation(SsoToken token, int corporationId, bool includeCompleted, int page)
        {
            StaticMethods.CheckToken(token, IndustryScopes.esi_industry_read_corporation_jobs_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.IndustryV1CorporationJobs(corporationId, includeCompleted, page), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 300));

            IList<EsiV1IndustryCorporation> esiModel = JsonConvert.DeserializeObject<IList<EsiV1IndustryCorporation>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1IndustryCorporation>, IList<V1IndustryCorporation>>(esiModel);
        }

        public async Task<IList<V1IndustryCorporation>> CorporationAsync(SsoToken token, int corporationId, bool includeCompleted, int page)
        {
            StaticMethods.CheckToken(token, IndustryScopes.esi_industry_read_corporation_jobs_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.IndustryV1CorporationJobs(corporationId, includeCompleted, page), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 300));

            IList<EsiV1IndustryCorporation> esiModel = JsonConvert.DeserializeObject<IList<EsiV1IndustryCorporation>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1IndustryCorporation>, IList<V1IndustryCorporation>>(esiModel);
        }

        public IList<V1IndustryFacility> Facilities()
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.IndustryV1Facilities(), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, 3600));

            IList<EsiV1IndustryFacility> esiModel = JsonConvert.DeserializeObject<IList<EsiV1IndustryFacility>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1IndustryFacility>, IList<V1IndustryFacility>>(esiModel);
        }

        public async Task<IList<V1IndustryFacility>> FacilitiesAsync()
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.IndustryV1Facilities(), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, 3600));

            IList<EsiV1IndustryFacility> esiModel = JsonConvert.DeserializeObject<IList<EsiV1IndustryFacility>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1IndustryFacility>, IList<V1IndustryFacility>>(esiModel);
        }

        public IList<V1IndustrySystem> Systems()
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.IndustryV1Systems(), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, 3600));

            IList<EsiV1IndustrySystem> esiModel = JsonConvert.DeserializeObject<IList<EsiV1IndustrySystem>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1IndustrySystem>, IList<V1IndustrySystem>>(esiModel);
        }

        public async Task<IList<V1IndustrySystem>> SystemsAsync()
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.IndustryV1Systems(), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, 3600));

            IList<EsiV1IndustrySystem> esiModel = JsonConvert.DeserializeObject<IList<EsiV1IndustrySystem>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1IndustrySystem>, IList<V1IndustrySystem>>(esiModel);
        }
    }
}
