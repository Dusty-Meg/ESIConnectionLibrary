using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.Internal_classes
{
    internal class InternalLatestWars : IInternalLatestWars
    {
        private readonly IWebClient _webClient;
        private readonly IMapper _mapper;
        private readonly bool _testing;

        public InternalLatestWars(IWebClient webClient, string userAgent, bool testing = false)
        {
            IConfigurationProvider provider = new MapperConfiguration(cfg => { });

            _webClient = webClient ?? new WebClient(userAgent);
            _mapper = new Mapper(provider);
            _testing = testing;
        }

        public IList<int> Wars(int maxWarId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.WarsV1Wars(maxWarId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, 3600));

            return JsonConvert.DeserializeObject<IList<int>>(esiRaw.Model);
        }

        public async Task<IList<int>> WarsAsync(int maxWarId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.WarsV1Wars(maxWarId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, 3600));

            return JsonConvert.DeserializeObject<IList<int>>(esiRaw.Model);
        }

        public V1WarsWar War(int warId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.WarsV1War(warId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, 3600));

            EsiV1WarsWar war = JsonConvert.DeserializeObject<EsiV1WarsWar>(esiRaw.Model);

            return _mapper.Map<V1WarsWar>(war);
        }

        public async Task<V1WarsWar> WarAsync(int warId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.WarsV1War(warId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, 3600));

            EsiV1WarsWar war = JsonConvert.DeserializeObject<EsiV1WarsWar>(esiRaw.Model);

            return _mapper.Map<V1WarsWar>(war);
        }

        public IList<V1WarsKillmail> Killmails(int warId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.WarsV1WarKillmails(warId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, 3600));

            IList<EsiV1WarsKillmail> esiWar = JsonConvert.DeserializeObject<IList<EsiV1WarsKillmail>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1WarsKillmail>, IList<V1WarsKillmail>>(esiWar);
        }

        public async Task<IList<V1WarsKillmail>> KillmailsAsync(int warId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.WarsV1WarKillmails(warId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, 3600));

            IList<EsiV1WarsKillmail> esiWar = JsonConvert.DeserializeObject<IList<EsiV1WarsKillmail>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1WarsKillmail>, IList<V1WarsKillmail>>(esiWar);
        }
    }
}
