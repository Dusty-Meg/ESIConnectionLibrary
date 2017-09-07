using AutoMapper;
using ESIConnectionLibrary.AutomapperMappings;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.Internal_classes
{
    internal class InternalKillmails : IInternalKillmails
    {
        private readonly IWebClient _webClient;
        private readonly IMapper _mapper;

        public InternalKillmails(IWebClient webClient, string userAgent)
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

        public GetSingleKillmail GetSingleKillmail(int killmailId, string killmailHash)
        {
            string url = StaticConnectionStrings.KillmailsGetSingleKillmail(killmailId, killmailHash);

            string esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, 3600));

            EsiKillmail esiGetSingleKillmail = JsonConvert.DeserializeObject<EsiKillmail>(esiRaw);

            return _mapper.Map<EsiKillmail, GetSingleKillmail>(esiGetSingleKillmail);
        }
    }
}
