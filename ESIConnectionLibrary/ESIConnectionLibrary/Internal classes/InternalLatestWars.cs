using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ESIConnectionLibrary.AutomapperMappings;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.Internal_classes
{
    internal class InternalLatestWars : IInternalLatestWars
    {
        private readonly IWebClient _webClient;
        private readonly IMapper _mapper;

        public InternalLatestWars(IWebClient webClient, string userAgent)
        {
            IConfigurationProvider provider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<WarsMappings>();
            });

            _webClient = webClient ?? new WebClient(userAgent);
            _mapper = new Mapper(provider);
        }

        public IList<int> GetWars(int maxWarId)
        {
            string url = StaticConnectionStrings.WarsV1Wars(maxWarId);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, 3600));

            return JsonConvert.DeserializeObject<IList<int>>(esiRaw.Model);
        }

        public async Task<IList<int>> GetWarsAsync(int maxWarId)
        {
            string url = StaticConnectionStrings.WarsV1Wars(maxWarId);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, 3600));

            return JsonConvert.DeserializeObject<IList<int>>(esiRaw.Model);
        }

        public V1WarsIndividualWar GetIndividualWar(int warId)
        {
            string url = StaticConnectionStrings.WarsV1War(warId);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, 3600));

            EsiV1WarsIndividualWar esiWar = JsonConvert.DeserializeObject<EsiV1WarsIndividualWar>(esiRaw.Model);

            return _mapper.Map<V1WarsIndividualWar>(esiWar);
        }

        public async Task<V1WarsIndividualWar> GetIndividualWarAsync(int warId)
        {
            string url = StaticConnectionStrings.WarsV1War(warId);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, 3600));

            EsiV1WarsIndividualWar esiWar = JsonConvert.DeserializeObject<EsiV1WarsIndividualWar>(esiRaw.Model);

            return _mapper.Map<V1WarsIndividualWar>(esiWar);
        }

        public IList<V1WarsWarKillmails> GetIndividualWarsKillmails(int warId)
        {
            string url = StaticConnectionStrings.WarsV1WarKillmails(warId);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, 3600));

            IList<EsiV1WarsWarKillmails> esiWar = JsonConvert.DeserializeObject<IList<EsiV1WarsWarKillmails>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1WarsWarKillmails>, IList<V1WarsWarKillmails>>(esiWar);
        }

        public async Task<IList<V1WarsWarKillmails>> GetIndividualWarsKillmailsAsync(int warId)
        {
            string url = StaticConnectionStrings.WarsV1WarKillmails(warId);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, 3600));

            IList<EsiV1WarsWarKillmails> esiWar = JsonConvert.DeserializeObject<IList<EsiV1WarsWarKillmails>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1WarsWarKillmails>, IList<V1WarsWarKillmails>>(esiWar);
        }
    }
}
