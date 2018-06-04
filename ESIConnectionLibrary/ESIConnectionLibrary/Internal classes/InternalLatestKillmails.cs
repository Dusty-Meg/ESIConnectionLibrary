using System.Threading.Tasks;
using AutoMapper;
using ESIConnectionLibrary.AutomapperMappings;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.Internal_classes
{
    internal class InternalLatestKillmails : IInternalLatestKillmails
    {
        private readonly IWebClient _webClient;
        private readonly IMapper _mapper;

        public InternalLatestKillmails(IWebClient webClient, string userAgent)
        {
            IConfigurationProvider provider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<GetSingleKillmailMappings>();
                cfg.AddProfile<GetSingleKillmailVictimMappings>();
                cfg.AddProfile<GetSingleKillmailPositionMappings>();
                cfg.AddProfile<GetSingleKillmailItemMappings>();
                cfg.AddProfile<GetSingleKillmailAttackerMappings>();
            });

            _webClient = webClient ?? new WebClient(userAgent);
            _mapper = new Mapper(provider);
        }

        public V1GetSingleKillmail GetSingleKillmail(int killmailId, string killmailHash)
        {
            string url = StaticConnectionStrings.KillmailsGetSingleKillmail(killmailId, killmailHash);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, 3600));

            EsiV1Killmail esiV1GetSingleKillmail = JsonConvert.DeserializeObject<EsiV1Killmail>(esiRaw.Model);

            return _mapper.Map<EsiV1Killmail, V1GetSingleKillmail>(esiV1GetSingleKillmail);
        }

        public async Task<V1GetSingleKillmail> GetSingleKillmailAsync(int killmailId, string killmailHash)
        {
            string url = StaticConnectionStrings.KillmailsGetSingleKillmail(killmailId, killmailHash);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, 3600));

            EsiV1Killmail esiV1GetSingleKillmail = JsonConvert.DeserializeObject<EsiV1Killmail>(esiRaw.Model);

            return _mapper.Map<EsiV1Killmail, V1GetSingleKillmail>(esiV1GetSingleKillmail);
        }
    }
}
