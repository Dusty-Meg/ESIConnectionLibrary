using System.Threading.Tasks;
using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.Internal_classes
{
    internal class InternalLatestKillmails : IInternalLatestKillmails
    {
        private readonly IWebClient _webClient;
        private readonly IMapper _mapper;
        private readonly bool _testing;

        public InternalLatestKillmails(IWebClient webClient, string userAgent, bool testing = false)
        {
            IConfigurationProvider provider = new MapperConfiguration(cfg => { });

            _webClient = webClient ?? new WebClient(userAgent);
            _mapper = new Mapper(provider);
            _testing = testing;
        }

        public V1GetSingleKillmail GetSingleKillmail(int killmailId, string killmailHash)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.KillmailsGetSingleKillmail(killmailId, killmailHash), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, 3600));

            EsiV1Killmail esiV1GetSingleKillmail = JsonConvert.DeserializeObject<EsiV1Killmail>(esiRaw.Model);

            return _mapper.Map<EsiV1Killmail, V1GetSingleKillmail>(esiV1GetSingleKillmail);
        }

        public async Task<V1GetSingleKillmail> GetSingleKillmailAsync(int killmailId, string killmailHash)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.KillmailsGetSingleKillmail(killmailId, killmailHash), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, 3600));

            EsiV1Killmail esiV1GetSingleKillmail = JsonConvert.DeserializeObject<EsiV1Killmail>(esiRaw.Model);

            return _mapper.Map<EsiV1Killmail, V1GetSingleKillmail>(esiV1GetSingleKillmail);
        }
    }
}
