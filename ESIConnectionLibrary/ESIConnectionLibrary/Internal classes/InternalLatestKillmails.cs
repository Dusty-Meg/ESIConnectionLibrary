using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ESIConnectionLibrary.Automapper_Profiles;
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
            IConfigurationProvider provider = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<KillMailsProfile>();
                });

            _webClient = webClient ?? new WebClient(userAgent);
            _mapper = new Mapper(provider);
            _testing = testing;
        }

        public IList<V1KillmailCharacter> Character(SsoToken token, int page)
        {
            StaticMethods.CheckToken(token, KillmailScopes.esi_killmails_read_killmails_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.KillmailsV1Character(token.CharacterId, page), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, 300));

            IList<EsiV1KillmailCharacter> esiModel = JsonConvert.DeserializeObject<IList<EsiV1KillmailCharacter>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1KillmailCharacter>, IList<V1KillmailCharacter>>(esiModel);
        }

        public async Task<IList<V1KillmailCharacter>> CharacterAsync(SsoToken token, int page)
        {
            StaticMethods.CheckToken(token, KillmailScopes.esi_killmails_read_killmails_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.KillmailsV1Character(token.CharacterId, page), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, 300));

            IList<EsiV1KillmailCharacter> esiModel = JsonConvert.DeserializeObject<IList<EsiV1KillmailCharacter>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1KillmailCharacter>, IList<V1KillmailCharacter>>(esiModel);
        }

        public IList<V1KillmailCorporation> Corporation(SsoToken token, int corporationId, int page)
        {
            StaticMethods.CheckToken(token, KillmailScopes.esi_killmails_read_corporation_killmails_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.KillmailsV1Corporation(corporationId, page), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, 300));

            IList<EsiV1KillmailCorporation> esiModel = JsonConvert.DeserializeObject<IList<EsiV1KillmailCorporation>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1KillmailCorporation>, IList<V1KillmailCorporation>>(esiModel);
        }

        public async Task<IList<V1KillmailCorporation>> CorporationAsync(SsoToken token, int corporationId, int page)
        {
            StaticMethods.CheckToken(token, KillmailScopes.esi_killmails_read_corporation_killmails_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.KillmailsV1Corporation(corporationId, page), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, 300));

            IList<EsiV1KillmailCorporation> esiModel = JsonConvert.DeserializeObject<IList<EsiV1KillmailCorporation>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1KillmailCorporation>, IList<V1KillmailCorporation>>(esiModel);
        }

        public V1KillmailKillmail Killmail(int killmailId, string killmailHash)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.KillmailsV1Killmail(killmailId, killmailHash), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, 1209600));

            EsiV1KillmailKillmail esiModel = JsonConvert.DeserializeObject<EsiV1KillmailKillmail>(esiRaw.Model);

            return _mapper.Map<EsiV1KillmailKillmail, V1KillmailKillmail>(esiModel);
        }

        public async Task<V1KillmailKillmail> KillmailAsync(int killmailId, string killmailHash)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.KillmailsV1Killmail(killmailId, killmailHash), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, 1209600));

            EsiV1KillmailKillmail esiModel = JsonConvert.DeserializeObject<EsiV1KillmailKillmail>(esiRaw.Model);

            return _mapper.Map<EsiV1KillmailKillmail, V1KillmailKillmail>(esiModel);
        }
    }
}
