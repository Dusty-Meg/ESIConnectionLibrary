using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ESIConnectionLibrary.Automapper_Profiles;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.Internal_classes
{
    internal class InternalLatestCharacter : IInternalLatestCharacter
    {
        private readonly IWebClient _webClient;
        private readonly IMapper _mapper;
        private readonly bool _testing;

        public InternalLatestCharacter(IWebClient webClient, string userAgent, bool testing = false)
        {
            IConfigurationProvider provider = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<CharacterProfile>();
                });

            _webClient = webClient ?? new WebClient(userAgent);
            _mapper = new Mapper(provider);
            _testing = testing;
        }

        public V5CharactersPublicInfo PublicInfo(int characterId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.EsiV5CharactersPublicInfo(characterId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, 3600));

            EsiV5CharactersPublicInfo esiV5PublicInfo = JsonConvert.DeserializeObject<EsiV5CharactersPublicInfo>(esiRaw.Model);

            return _mapper.Map<EsiV5CharactersPublicInfo, V5CharactersPublicInfo>(esiV5PublicInfo);
        }

        public async Task<V5CharactersPublicInfo> PublicInfoAsync(int characterId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.EsiV5CharactersPublicInfo(characterId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, 3600));

            EsiV5CharactersPublicInfo esiV5PublicInfo = JsonConvert.DeserializeObject<EsiV5CharactersPublicInfo>(esiRaw.Model);

            return _mapper.Map<EsiV5CharactersPublicInfo, V5CharactersPublicInfo>(esiV5PublicInfo);
        }

        public IList<V1CharactersResearchAgents> ResearchAgents(SsoToken token)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_read_agents_research_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.EsiV1CharactersResearchAgents(token.CharacterId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1CharactersResearchAgents> esiV1CharactersResearchAgents = JsonConvert.DeserializeObject<IList<EsiV1CharactersResearchAgents>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1CharactersResearchAgents>, IList<V1CharactersResearchAgents>>(esiV1CharactersResearchAgents);
        }

        public async Task<IList<V1CharactersResearchAgents>> ResearchAgentsAsync(SsoToken token)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_read_agents_research_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.EsiV1CharactersResearchAgents(token.CharacterId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1CharactersResearchAgents> esiV1CharactersResearchAgents = JsonConvert.DeserializeObject<IList<EsiV1CharactersResearchAgents>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1CharactersResearchAgents>, IList<V1CharactersResearchAgents>>(esiV1CharactersResearchAgents);
        }

        public IList<V3CharactersBlueprints> Blueprints(SsoToken token)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_read_blueprints_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.EsiV3CharactersBlueprints(token.CharacterId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV3CharactersBlueprints> esiv3CharactersBlueprints = JsonConvert.DeserializeObject<IList<EsiV3CharactersBlueprints>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV3CharactersBlueprints>, IList<V3CharactersBlueprints>>(esiv3CharactersBlueprints);
        }

        public async Task<IList<V3CharactersBlueprints>> BlueprintsAsync(SsoToken token)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_read_blueprints_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.EsiV3CharactersBlueprints(token.CharacterId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV3CharactersBlueprints> esiv3CharactersBlueprints = JsonConvert.DeserializeObject<IList<EsiV3CharactersBlueprints>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV3CharactersBlueprints>, IList<V3CharactersBlueprints>>(esiv3CharactersBlueprints);
        }

        public IList<V2CharactersCorporationHistory> CorporationHistory(int characterId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.EsiV2CharactersCorporationHistory(characterId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, 3600));

            IList<EsiV2CharactersCorporationHistory> esiV2CharactersCorporationHistory = JsonConvert.DeserializeObject<IList<EsiV2CharactersCorporationHistory>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV2CharactersCorporationHistory>, IList<V2CharactersCorporationHistory>>(esiV2CharactersCorporationHistory);
        }

        public async Task<IList<V2CharactersCorporationHistory>> CorporationHistoryAsync(int characterId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.EsiV2CharactersCorporationHistory(characterId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, 3600));

            IList<EsiV2CharactersCorporationHistory> esiV2CharactersCorporationHistory = JsonConvert.DeserializeObject<IList<EsiV2CharactersCorporationHistory>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV2CharactersCorporationHistory>, IList<V2CharactersCorporationHistory>>(esiV2CharactersCorporationHistory);
        }

        public float CspaCost(SsoToken token, IList<int> characters)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_read_contacts_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.EsiV5CharactersCspa(token.CharacterId), _testing);

            string jsonObject = JsonConvert.SerializeObject(characters);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Post(StaticMethods.CreateHeaders(token), url, jsonObject));

            float esiV5CharactersCspa = JsonConvert.DeserializeObject<float>(esiRaw.Model);

            return esiV5CharactersCspa;
        }

        public async Task<float> CspaCostAsync(SsoToken token, IList<int> characters)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_read_contacts_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.EsiV5CharactersCspa(token.CharacterId), _testing);

            string jsonObject = JsonConvert.SerializeObject(characters);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.PostAsync(StaticMethods.CreateHeaders(token), url, jsonObject));

            float esiV5CharactersCspa = JsonConvert.DeserializeObject<float>(esiRaw.Model);

            return esiV5CharactersCspa;
        }

        public V2CharactersFatigue Fatigue(SsoToken token)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_read_fatigue_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.EsiV2CharactersFatigue(token.CharacterId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 300));

            EsiV2CharactersFatigue esiV2CharactersFatigue = JsonConvert.DeserializeObject<EsiV2CharactersFatigue>(esiRaw.Model);

            return _mapper.Map<EsiV2CharactersFatigue, V2CharactersFatigue>(esiV2CharactersFatigue);
        }

        public async Task<V2CharactersFatigue> FatigueAsync(SsoToken token)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_read_fatigue_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.EsiV2CharactersFatigue(token.CharacterId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 300));

            EsiV2CharactersFatigue esiV2CharactersFatigue = JsonConvert.DeserializeObject<EsiV2CharactersFatigue>(esiRaw.Model);

            return _mapper.Map<EsiV2CharactersFatigue, V2CharactersFatigue>(esiV2CharactersFatigue);
        }

        public IList<V2CharactersMedals> Medals(SsoToken token)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_read_medals_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.EsiV2CharactersMedals(token.CharacterId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV2CharactersMedals> esiV2CharactersMedals = JsonConvert.DeserializeObject<IList<EsiV2CharactersMedals>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV2CharactersMedals>, IList<V2CharactersMedals>>(esiV2CharactersMedals);
        }

        public async Task<IList<V2CharactersMedals>> MedalsAsync(SsoToken token)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_read_medals_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.EsiV2CharactersMedals(token.CharacterId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV2CharactersMedals> esiV2CharactersMedals = JsonConvert.DeserializeObject<IList<EsiV2CharactersMedals>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV2CharactersMedals>, IList<V2CharactersMedals>>(esiV2CharactersMedals);
        }

        public IList<V5CharactersNotifications> Notifications(SsoToken token)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_read_notifications_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.EsiV5CharactersNotifications(token.CharacterId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 600));

            IList<EsiV4CharactersNotifications> esiV1Notifications = JsonConvert.DeserializeObject<IList<EsiV4CharactersNotifications>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV4CharactersNotifications>, IList<V5CharactersNotifications>>(esiV1Notifications);
        }

        public async Task<IList<V5CharactersNotifications>> NotificationsAsync(SsoToken token)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_read_notifications_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.EsiV5CharactersNotifications(token.CharacterId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 600));

            IList<EsiV4CharactersNotifications> esiV1Notifications = JsonConvert.DeserializeObject<IList<EsiV4CharactersNotifications>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV4CharactersNotifications>, IList<V5CharactersNotifications>>(esiV1Notifications);
        }

        public IList<V1CharactersNotificationsContacts> ContactNotifications(SsoToken token)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_read_notifications_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.EsiV1CharactersNotificationsContacts(token.CharacterId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 600));

            IList<EsiV1CharactersNotificationsContacts> esiV1CharactersNotificationsContacts = JsonConvert.DeserializeObject<IList<EsiV1CharactersNotificationsContacts>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1CharactersNotificationsContacts>, IList<V1CharactersNotificationsContacts>>(esiV1CharactersNotificationsContacts);
        }

        public async Task<IList<V1CharactersNotificationsContacts>> ContactNotificationsAsync(SsoToken token)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_read_notifications_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.EsiV1CharactersNotificationsContacts(token.CharacterId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 600));

            IList<EsiV1CharactersNotificationsContacts> esiV1CharactersNotificationsContacts = JsonConvert.DeserializeObject<IList<EsiV1CharactersNotificationsContacts>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV1CharactersNotificationsContacts>, IList<V1CharactersNotificationsContacts>>(esiV1CharactersNotificationsContacts);
        }

        public V2CharactersPortrait Portrait(int characterId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.EsiV2CharactersPortrait(characterId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, 3600));

            EsiV2CharactersPortrait esiV2CharactersPortrait = JsonConvert.DeserializeObject<EsiV2CharactersPortrait>(esiRaw.Model);

            return _mapper.Map<EsiV2CharactersPortrait, V2CharactersPortrait>(esiV2CharactersPortrait);
        }

        public async Task<V2CharactersPortrait> PortraitAsync(int characterId)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.EsiV2CharactersPortrait(characterId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, 3600));

            EsiV2CharactersPortrait esiV2CharactersPortrait = JsonConvert.DeserializeObject<EsiV2CharactersPortrait>(esiRaw.Model);

            return _mapper.Map<EsiV2CharactersPortrait, V2CharactersPortrait>(esiV2CharactersPortrait);
        }

        public V3CharacterRoles Roles(SsoToken token)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_read_corporation_roles_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.EsiV3CharacterRoles(token.CharacterId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            EsiV3CharacterRoles esiV3CharacterRoles = JsonConvert.DeserializeObject<EsiV3CharacterRoles>(esiRaw.Model);

            return _mapper.Map<EsiV3CharacterRoles, V3CharacterRoles>(esiV3CharacterRoles);
        }

        public async Task<V3CharacterRoles> RolesAsync(SsoToken token)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_read_corporation_roles_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.EsiV3CharacterRoles(token.CharacterId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            EsiV3CharacterRoles esiV3CharacterRoles = JsonConvert.DeserializeObject<EsiV3CharacterRoles>(esiRaw.Model);

            return _mapper.Map<EsiV3CharacterRoles, V3CharacterRoles>(esiV3CharacterRoles);
        }

        public IList<V2CharactersStandings> Standings(SsoToken token)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_read_standings_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.EsiV2CharactersStandings(token.CharacterId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV2CharactersStandings> esiV2CharactersStandings = JsonConvert.DeserializeObject<IList<EsiV2CharactersStandings>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV2CharactersStandings>, IList<V2CharactersStandings>>(esiV2CharactersStandings);
        }

        public async Task<IList<V2CharactersStandings>> StandingsAsync(SsoToken token)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_read_standings_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.EsiV2CharactersStandings(token.CharacterId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV2CharactersStandings> esiV2CharactersStandings = JsonConvert.DeserializeObject<IList<EsiV2CharactersStandings>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV2CharactersStandings>, IList<V2CharactersStandings>>(esiV2CharactersStandings);
        }

        public IList<V2CharacterTitles> Titles(SsoToken token)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_read_titles_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.EsiV2CharacterTitles(token.CharacterId), _testing);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV2CharacterTitles> esiV2CharacterTitles = JsonConvert.DeserializeObject<IList<EsiV2CharacterTitles>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV2CharacterTitles>, IList<V2CharacterTitles>>(esiV2CharacterTitles);
        }

        public async Task<IList<V2CharacterTitles>> TitlesAsync(SsoToken token)
        {
            StaticMethods.CheckToken(token, CharacterScopes.esi_characters_read_titles_v1);

            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.EsiV2CharacterTitles(token.CharacterId), _testing);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV2CharacterTitles> esiV2CharacterTitles = JsonConvert.DeserializeObject<IList<EsiV2CharacterTitles>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV2CharacterTitles>, IList<V2CharacterTitles>>(esiV2CharacterTitles);
        }

        public IList<V2CharacterAffiliations> Affiliations(IList<int> characters)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.EsiV2CharacterAffiliations(), _testing);

            string jsonObject = JsonConvert.SerializeObject(characters);

            EsiModel esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Post(StaticMethods.CreateHeaders(), url, jsonObject, 3600));

            IList<EsiV2CharacterAffiliations> esiV2CharacterAffiliations = JsonConvert.DeserializeObject<IList<EsiV2CharacterAffiliations>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV2CharacterAffiliations>, IList<V2CharacterAffiliations>>(esiV2CharacterAffiliations);
        }

        public async Task<IList<V2CharacterAffiliations>> AffiliationsAsync(IList<int> characters)
        {
            string url = StaticConnectionStrings.CheckTestingUrl(StaticConnectionStrings.EsiV2CharacterAffiliations(), _testing);

            string jsonObject = JsonConvert.SerializeObject(characters);

            EsiModel esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.PostAsync(StaticMethods.CreateHeaders(), url, jsonObject, 3600));

            IList<EsiV2CharacterAffiliations> esiV2CharacterAffiliations = JsonConvert.DeserializeObject<IList<EsiV2CharacterAffiliations>>(esiRaw.Model);

            return _mapper.Map<IList<EsiV2CharacterAffiliations>, IList<V2CharacterAffiliations>>(esiV2CharacterAffiliations);
        }
    }
}
