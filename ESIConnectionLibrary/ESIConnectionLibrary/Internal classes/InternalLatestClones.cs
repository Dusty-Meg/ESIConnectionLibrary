using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ESIConnectionLibrary.AutomapperMappings;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.Internal_classes
{
    internal class InternalLatestClones : IInternalLatestClones
    {
        private readonly IWebClient _webClient;
        private readonly IMapper _mapper;
        private readonly bool _testing;

        public InternalLatestClones(IWebClient webClient, string userAgent, bool testing = false)
        {
            IConfigurationProvider provider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ClonesMappings>();
            });

            _webClient = webClient ?? new WebClient(userAgent);
            _mapper = new Mapper(provider);
            _testing = testing;
        }

        public V3CharactersClones GetCharactersClones(SsoToken token)
        {
            StaticMethods.CheckToken(token, CloneScopes.esi_clones_read_clones_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.ClonesV3GetCharactersClones(token.CharacterId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 120));

            EsiV3CharactersClones esiClones = JsonConvert.DeserializeObject<EsiV3CharactersClones>(esiRaw.Model);

            return _mapper.Map<V3CharactersClones>(esiClones);
        }

        public async Task<V3CharactersClones> GetCharactersClonesAsync(SsoToken token)
        {
            StaticMethods.CheckToken(token, CloneScopes.esi_clones_read_clones_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.ClonesV3GetCharactersClones(token.CharacterId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 120));

            EsiV3CharactersClones esiClones = JsonConvert.DeserializeObject<EsiV3CharactersClones>(esiRaw.Model);

            return _mapper.Map<V3CharactersClones>(esiClones);
        }

        public IList<int> GetCharactersActiveImplants(SsoToken token)
        {
            StaticMethods.CheckToken(token, CloneScopes.esi_clones_read_implants_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.ClonesV3GetCharactersActiveImplants(token.CharacterId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 300));

            return JsonConvert.DeserializeObject<IList<int>>(esiRaw.Model);
        }

        public async Task<IList<int>> GetCharactersActiveImplantsAsync(SsoToken token)
        {
            StaticMethods.CheckToken(token, CloneScopes.esi_clones_read_implants_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.ClonesV3GetCharactersActiveImplants(token.CharacterId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 300));

            return JsonConvert.DeserializeObject<IList<int>>(esiRaw.Model);
        }
    }
}
