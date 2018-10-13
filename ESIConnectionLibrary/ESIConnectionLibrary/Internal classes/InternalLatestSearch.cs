using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.Internal_classes
{
    internal class InternalLatestSearch : IInternalLatestSearch
    {
        private readonly IWebClient _webClient;
        private readonly IMapper _mapper;
        private readonly bool _testing;

        public InternalLatestSearch(IWebClient webClient, string userAgent, bool testing = false)
        {
            IConfigurationProvider provider = new MapperConfiguration(cfg => { });

            _webClient = webClient ?? new WebClient(userAgent);
            _mapper = new Mapper(provider);
            _testing = testing;
        }

        public V3SearchAuthSearch CharacterSearch(SsoToken token, IList<V3SearchAuthSearchCategories> categories, string search, bool strict)
        {
            StaticMethods.CheckToken(token, SearchScopes.esi_search_search_structures_v1);

            IList<EsiV3SearchAuthSearchCategories> esiCategories = _mapper.Map<IList<V3SearchAuthSearchCategories>, IList<EsiV3SearchAuthSearchCategories>>(categories);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.SearchV3AuthSearch(token.CharacterId, search, strict, JsonConvert.SerializeObject(esiCategories)), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            EsiV3SearchAuthSearch esiModel = JsonConvert.DeserializeObject<EsiV3SearchAuthSearch>(esiRaw.Model);

            return _mapper.Map<V3SearchAuthSearch>(esiModel);
        }

        public async Task<V3SearchAuthSearch> CharacterSearchAsync(SsoToken token, IList<V3SearchAuthSearchCategories> categories, string search, bool strict)
        {
            StaticMethods.CheckToken(token, SearchScopes.esi_search_search_structures_v1);

            IList<EsiV3SearchAuthSearchCategories> esiCategories = _mapper.Map<IList<V3SearchAuthSearchCategories>, IList<EsiV3SearchAuthSearchCategories>>(categories);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.SearchV3AuthSearch(token.CharacterId, search, strict, JsonConvert.SerializeObject(esiCategories)), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            EsiV3SearchAuthSearch esiModel = JsonConvert.DeserializeObject<EsiV3SearchAuthSearch>(esiRaw.Model);

            return _mapper.Map<V3SearchAuthSearch>(esiModel);
        }

        public V2SearchSearch Search(IList<V2SearchSearchCategories> categories, string search, bool strict)
        {
            IList<EsiV2SearchSearchCategories> esiCategories = _mapper.Map<IList<V2SearchSearchCategories>, IList<EsiV2SearchSearchCategories>>(categories);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.SearchV2Search(search, strict, JsonConvert.SerializeObject(esiCategories)), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, 3600));

            EsiV2SearchSearch esiModel = JsonConvert.DeserializeObject<EsiV2SearchSearch>(esiRaw.Model);

            return _mapper.Map<V2SearchSearch>(esiModel);
        }

        public async Task<V2SearchSearch> SearchAsync(IList<V2SearchSearchCategories> categories, string search, bool strict)
        {
            IList<EsiV2SearchSearchCategories> esiCategories = _mapper.Map<IList<V2SearchSearchCategories>, IList<EsiV2SearchSearchCategories>>(categories);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.SearchV2Search(search, strict, JsonConvert.SerializeObject(esiCategories)), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, 3600));

            EsiV2SearchSearch esiModel = JsonConvert.DeserializeObject<EsiV2SearchSearch>(esiRaw.Model);

            return _mapper.Map<V2SearchSearch>(esiModel);
        }
    }
}
