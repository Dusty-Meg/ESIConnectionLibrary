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

        public InternalLatestClones(IWebClient webClient, string userAgent)
        {
            IConfigurationProvider provider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ClonesMappings>();
            });

            _webClient = webClient ?? new WebClient(userAgent);
            _mapper = new Mapper(provider);
        }

        public V3CharactersClones GetCharactersClones(SsoToken token)
        {
            StaticMethods.CheckToken(token, CloneScopes.esi_clones_read_clones_v1);

            string url = StaticConnectionStrings.ClonesV3GetCharactersClones(token.CharacterId);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 120));

            EsiV3CharactersClones esiClones = JsonConvert.DeserializeObject<EsiV3CharactersClones>(esiRaw.Model);

            return _mapper.Map<V3CharactersClones>(esiClones);
        }

        public async Task<V3CharactersClones> GetCharactersClonesAsync(SsoToken token)
        {
            StaticMethods.CheckToken(token, CloneScopes.esi_clones_read_clones_v1);

            string url = StaticConnectionStrings.ClonesV3GetCharactersClones(token.CharacterId);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 120));

            EsiV3CharactersClones esiClones = JsonConvert.DeserializeObject<EsiV3CharactersClones>(esiRaw.Model);

            return _mapper.Map<V3CharactersClones>(esiClones);
        }

        public IList<int> GetCharactersActiveImplants(SsoToken token)
        {
            StaticMethods.CheckToken(token, CloneScopes.esi_clones_read_implants_v1);

            string url = StaticConnectionStrings.ClonesV3GetCharactersActiveImplants(token.CharacterId);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 300));

            return JsonConvert.DeserializeObject<IList<int>>(esiRaw.Model);
        }

        public async Task<IList<int>> GetCharactersActiveImplantsAsync(SsoToken token)
        {
            StaticMethods.CheckToken(token, CloneScopes.esi_clones_read_implants_v1);

            string url = StaticConnectionStrings.ClonesV3GetCharactersActiveImplants(token.CharacterId);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 300));

            return JsonConvert.DeserializeObject<IList<int>>(esiRaw.Model);
        }
    }
}
