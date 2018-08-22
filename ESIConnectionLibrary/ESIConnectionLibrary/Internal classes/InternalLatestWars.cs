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

        public IList<int> GetWars(int maxWarId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.WarsV1Wars(maxWarId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, 3600));

            return JsonConvert.DeserializeObject<IList<int>>(esiRaw.Model);
        }

        public async Task<IList<int>> GetWarsAsync(int maxWarId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.WarsV1Wars(maxWarId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, 3600));

            return JsonConvert.DeserializeObject<IList<int>>(esiRaw.Model);
        }

        public V1WarsIndividualWar GetIndividualWar(int warId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.WarsV1War(warId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, 3600));

            EsiV1WarsIndividualWar esiWar = JsonConvert.DeserializeObject<EsiV1WarsIndividualWar>(esiRaw.Model);

            return _mapper.Map<V1WarsIndividualWar>(esiWar);
        }

        public async Task<V1WarsIndividualWar> GetIndividualWarAsync(int warId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.WarsV1War(warId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, 3600));

            EsiV1WarsIndividualWar esiWar = JsonConvert.DeserializeObject<EsiV1WarsIndividualWar>(esiRaw.Model);

            return _mapper.Map<V1WarsIndividualWar>(esiWar);
        }

        public IList<V1WarsWarKillmails> GetIndividualWarsKillmails(int warId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.WarsV1WarKillmails(warId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, 3600));

            IList<EsiV1WarsWarKillmails> esiWar = JsonConvert.DeserializeObject<IList<EsiV1WarsWarKillmails>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1WarsWarKillmails>, IList<V1WarsWarKillmails>>(esiWar);
        }

        public async Task<IList<V1WarsWarKillmails>> GetIndividualWarsKillmailsAsync(int warId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.WarsV1WarKillmails(warId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, 3600));

            IList<EsiV1WarsWarKillmails> esiWar = JsonConvert.DeserializeObject<IList<EsiV1WarsWarKillmails>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1WarsWarKillmails>, IList<V1WarsWarKillmails>>(esiWar);
        }
    }
}
