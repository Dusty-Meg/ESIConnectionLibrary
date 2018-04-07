﻿using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ESIConnectionLibrary.AutomapperMappings;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.Internal_classes
{
    internal class InternalLatestCharacter : IInternalLatestCharacter
    {
        private readonly IWebClient _webClient;
        private readonly IMapper _mapper;

        public InternalLatestCharacter(IWebClient webClient, string userAgent)
        {
            IConfigurationProvider provider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CharacterMappings>();
                cfg.AddProfile<GeneralMappings>();
            });

            _webClient = webClient ?? new WebClient(userAgent);
            _mapper = new Mapper(provider);
        }

        public V4CharactersPublicInfo GetCharactersPublicInfo(int characterId)
        {
            string url = StaticConnectionStrings.EsiV4CharactersPublicInfo(characterId);

            string esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, 3600));

            EsiV4CharactersPublicInfo esiV4PublicInfo = JsonConvert.DeserializeObject<EsiV4CharactersPublicInfo>(esiRaw);

            return _mapper.Map<EsiV4CharactersPublicInfo, V4CharactersPublicInfo>(esiV4PublicInfo);
        }

        public async Task<V4CharactersPublicInfo> GetCharactersPublicInfoAsync(int characterId)
        {
            string url = StaticConnectionStrings.EsiV4CharactersPublicInfo(characterId);

            string esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, 3600));

            EsiV4CharactersPublicInfo esiV4PublicInfo = JsonConvert.DeserializeObject<EsiV4CharactersPublicInfo>(esiRaw);

            return _mapper.Map<EsiV4CharactersPublicInfo, V4CharactersPublicInfo>(esiV4PublicInfo);
        }

        public IList<V1CharactersResearchAgents> GetCharactersResearchAgents(SsoToken token, int characterId)
        {
            StaticMethods.CheckToken(token, Scopes.esi_characters_read_agents_research_v1);

            string url = StaticConnectionStrings.EsiV1CharactersResearchAgents(characterId);

            string esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1CharactersResearchAgents> esiV1CharactersResearchAgents = JsonConvert.DeserializeObject<IList<EsiV1CharactersResearchAgents>>(esiRaw);

            return _mapper.Map<IList<EsiV1CharactersResearchAgents>, IList<V1CharactersResearchAgents>>(esiV1CharactersResearchAgents);
        }

        public async Task<IList<V1CharactersResearchAgents>> GetCharactersResearchAgentsAsync(SsoToken token, int characterId)
        {
            StaticMethods.CheckToken(token, Scopes.esi_characters_read_agents_research_v1);

            string url = StaticConnectionStrings.EsiV1CharactersResearchAgents(characterId);

            string esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1CharactersResearchAgents> esiV1CharactersResearchAgents = JsonConvert.DeserializeObject<IList<EsiV1CharactersResearchAgents>>(esiRaw);

            return _mapper.Map<IList<EsiV1CharactersResearchAgents>, IList<V1CharactersResearchAgents>>(esiV1CharactersResearchAgents);
        }

        public IList<V2CharactersBlueprints> GetCharactersBlueprint(SsoToken token, int characterId)
        {
            StaticMethods.CheckToken(token, Scopes.esi_characters_read_blueprints_v1);

            string url = StaticConnectionStrings.EsiV2CharactersBlueprints(characterId);

            string esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV2CharactersBlueprints> esiv2CharactersBlueprints = JsonConvert.DeserializeObject<IList<EsiV2CharactersBlueprints>>(esiRaw);

            return _mapper.Map<IList<EsiV2CharactersBlueprints>, IList<V2CharactersBlueprints>>(esiv2CharactersBlueprints);
        }

        public async Task<IList<V2CharactersBlueprints>> GetCharactersBlueprintAsync(SsoToken token, int characterId)
        {
            StaticMethods.CheckToken(token, Scopes.esi_characters_read_blueprints_v1);

            string url = StaticConnectionStrings.EsiV2CharactersBlueprints(characterId);

            string esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync(async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV2CharactersBlueprints> esiv2CharactersBlueprints = JsonConvert.DeserializeObject<IList<EsiV2CharactersBlueprints>>(esiRaw);

            return _mapper.Map<IList<EsiV2CharactersBlueprints>, IList<V2CharactersBlueprints>>(esiv2CharactersBlueprints);
        }

        public IList<V1CharactersChatChannels> GetCharactersChatChannels(SsoToken token, int characterId)
        {
            StaticMethods.CheckToken(token, Scopes.esi_characters_read_chat_channels_v1);

            string url = StaticConnectionStrings.EsiV1CharactersChatChannels(characterId);

            string esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 300));

            IList<EsiV1CharactersChatChannels> esiV1ChatChannels = JsonConvert.DeserializeObject<IList<EsiV1CharactersChatChannels>>(esiRaw);

            return _mapper.Map<IList<EsiV1CharactersChatChannels>, IList<V1CharactersChatChannels>>(esiV1ChatChannels);
        }

        public async Task<IList<V1CharactersChatChannels>> GetCharactersChatChannelsAsync(SsoToken token, int characterId)
        {
            StaticMethods.CheckToken(token, Scopes.esi_characters_read_chat_channels_v1);

            string url = StaticConnectionStrings.EsiV1CharactersChatChannels(characterId);

            string esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 300));

            IList<EsiV1CharactersChatChannels> esiV1ChatChannels = JsonConvert.DeserializeObject<IList<EsiV1CharactersChatChannels>>(esiRaw);

            return _mapper.Map<IList<EsiV1CharactersChatChannels>, IList<V1CharactersChatChannels>>(esiV1ChatChannels);
        }

        public IList<V1CharactersCorporationHistory> GetCharactersCorporationHistory(int characterId)
        {
            string url = StaticConnectionStrings.EsiV1CharactersCorporationHistory(characterId);

            string esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, 3600));

            IList<EsiV1CharactersCorporationHistory> esiV1CharactersCorporationHistory = JsonConvert.DeserializeObject<IList<EsiV1CharactersCorporationHistory>>(esiRaw);

            return _mapper.Map<IList<EsiV1CharactersCorporationHistory>, IList<V1CharactersCorporationHistory>>(esiV1CharactersCorporationHistory);
        }

        public async Task<IList<V1CharactersCorporationHistory>> GetCharactersCorporationHistoryAsync(int characterId)
        {
            string url = StaticConnectionStrings.EsiV1CharactersCorporationHistory(characterId);

            string esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, 3600));

            IList<EsiV1CharactersCorporationHistory> esiV1CharactersCorporationHistory = JsonConvert.DeserializeObject<IList<EsiV1CharactersCorporationHistory>>(esiRaw);

            return _mapper.Map<IList<EsiV1CharactersCorporationHistory>, IList<V1CharactersCorporationHistory>>(esiV1CharactersCorporationHistory);
        }

        public float GetCharactersCspaCost(SsoToken token, int characterId, IList<int> characters)
        {
            StaticMethods.CheckToken(token, Scopes.esi_characters_read_contacts_v1);

            string url = StaticConnectionStrings.EsiV4CharactersCspa(characterId);

            string jsonObject = JsonConvert.SerializeObject(characters);

            string esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Post(StaticMethods.CreateHeaders(token), url, jsonObject));

            float esiV4CharactersCspa = JsonConvert.DeserializeObject<float>(esiRaw);

            return esiV4CharactersCspa;
        }

        public async Task<float> GetCharactersCspaCostAsync(SsoToken token, int characterId, IList<int> characters)
        {
            StaticMethods.CheckToken(token, Scopes.esi_characters_read_contacts_v1);

            string url = StaticConnectionStrings.EsiV4CharactersCspa(characterId);

            string jsonObject = JsonConvert.SerializeObject(characters);

            string esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.PostAsync(StaticMethods.CreateHeaders(token), url, jsonObject));

            float esiV4CharactersCspa = JsonConvert.DeserializeObject<float>(esiRaw);

            return esiV4CharactersCspa;
        }

        public V1CharactersFatigue GetCharactersFatigue(SsoToken token, int characterId)
        {
            StaticMethods.CheckToken(token, Scopes.esi_characters_read_fatigue_v1);

            string url = StaticConnectionStrings.EsiV1CharactersFatigue(characterId);

            string esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 300));

            EsiV1CharactersFatigue esiV1CharactersFatigue = JsonConvert.DeserializeObject<EsiV1CharactersFatigue>(esiRaw);

            return _mapper.Map<EsiV1CharactersFatigue, V1CharactersFatigue>(esiV1CharactersFatigue);
        }

        public async Task<V1CharactersFatigue> GetCharactersFatigueAsync(SsoToken token, int characterId)
        {
            StaticMethods.CheckToken(token, Scopes.esi_characters_read_fatigue_v1);

            string url = StaticConnectionStrings.EsiV1CharactersFatigue(characterId);

            string esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 300));

            EsiV1CharactersFatigue esiV1CharactersFatigue = JsonConvert.DeserializeObject<EsiV1CharactersFatigue>(esiRaw);

            return _mapper.Map<EsiV1CharactersFatigue, V1CharactersFatigue>(esiV1CharactersFatigue);
        }

        public IList<V1CharactersMedals> GetCharactersMedals(SsoToken token, int characterId)
        {
            StaticMethods.CheckToken(token, Scopes.esi_characters_read_medals_v1);

            string url = StaticConnectionStrings.EsiV1CharactersMedals(characterId);

            string esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1CharactersMedals> esiV1CharactersMedals = JsonConvert.DeserializeObject<IList<EsiV1CharactersMedals>>(esiRaw);

            return _mapper.Map<IList<EsiV1CharactersMedals>, IList<V1CharactersMedals>>(esiV1CharactersMedals);
        }

        public async Task<IList<V1CharactersMedals>> GetCharactersMedalsAsync(SsoToken token, int characterId)
        {
            StaticMethods.CheckToken(token, Scopes.esi_characters_read_medals_v1);

            string url = StaticConnectionStrings.EsiV1CharactersMedals(characterId);

            string esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1CharactersMedals> esiV1CharactersMedals = JsonConvert.DeserializeObject<IList<EsiV1CharactersMedals>>(esiRaw);

            return _mapper.Map<IList<EsiV1CharactersMedals>, IList<V1CharactersMedals>>(esiV1CharactersMedals);
        }

        public IList<V2CharactersNotifications> GetCharactersNotifications(SsoToken token, int characterId)
        {
            StaticMethods.CheckToken(token, Scopes.esi_characters_read_notifications_v1);

            string url = StaticConnectionStrings.EsiV2CharactersNotifications(characterId);

            string esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 600));

            IList<EsiV2CharactersNotifications> esiV1Notifications = JsonConvert.DeserializeObject<IList<EsiV2CharactersNotifications>>(esiRaw);

            return _mapper.Map<IList<EsiV2CharactersNotifications>, IList<V2CharactersNotifications>>(esiV1Notifications);
        }

        public async Task<IList<V2CharactersNotifications>> GetCharactersNotificationsAsync(SsoToken token, int characterId)
        {
            StaticMethods.CheckToken(token, Scopes.esi_characters_read_notifications_v1);

            string url = StaticConnectionStrings.EsiV2CharactersNotifications(characterId);

            string esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 600));

            IList<EsiV2CharactersNotifications> esiV1Notifications = JsonConvert.DeserializeObject<IList<EsiV2CharactersNotifications>>(esiRaw);

            return _mapper.Map<IList<EsiV2CharactersNotifications>, IList<V2CharactersNotifications>>(esiV1Notifications);
        }

        public IList<V1CharactersNotificationsContacts> GetCharactersNotificationsContacts(SsoToken token, int characterId)
        {
            StaticMethods.CheckToken(token, Scopes.esi_characters_read_notifications_v1);

            string url = StaticConnectionStrings.EsiV1CharactersNotificationsContacts(characterId);

            string esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 600));

            IList<EsiV1CharactersNotificationsContacts> esiV1CharactersNotificationsContacts = JsonConvert.DeserializeObject<IList<EsiV1CharactersNotificationsContacts>>(esiRaw);

            return _mapper.Map<IList<EsiV1CharactersNotificationsContacts>, IList<V1CharactersNotificationsContacts>>(esiV1CharactersNotificationsContacts);
        }

        public async Task<IList<V1CharactersNotificationsContacts>> GetCharactersNotificationsContactsAsync(SsoToken token, int characterId)
        {
            StaticMethods.CheckToken(token, Scopes.esi_characters_read_notifications_v1);

            string url = StaticConnectionStrings.EsiV1CharactersNotificationsContacts(characterId);

            string esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 600));

            IList<EsiV1CharactersNotificationsContacts> esiV1CharactersNotificationsContacts = JsonConvert.DeserializeObject<IList<EsiV1CharactersNotificationsContacts>>(esiRaw);

            return _mapper.Map<IList<EsiV1CharactersNotificationsContacts>, IList<V1CharactersNotificationsContacts>>(esiV1CharactersNotificationsContacts);
        }

        public V2CharactersPortrait GetCharactersPortrait(int characterId)
        {
            string url = StaticConnectionStrings.EsiV2CharactersPortrait(characterId);

            string esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, 3600));

            EsiV2CharactersPortrait esiV2CharactersPortrait = JsonConvert.DeserializeObject<EsiV2CharactersPortrait>(esiRaw);

            return _mapper.Map<EsiV2CharactersPortrait, V2CharactersPortrait>(esiV2CharactersPortrait);
        }

        public async Task<V2CharactersPortrait> GetCharactersPortraitAsync(int characterId)
        {
            string url = StaticConnectionStrings.EsiV2CharactersPortrait(characterId);

            string esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, 3600));

            EsiV2CharactersPortrait esiV2CharactersPortrait = JsonConvert.DeserializeObject<EsiV2CharactersPortrait>(esiRaw);

            return _mapper.Map<EsiV2CharactersPortrait, V2CharactersPortrait>(esiV2CharactersPortrait);
        }

        public V2CharacterRoles GetCharactersRoles(SsoToken token, int characterId)
        {
            StaticMethods.CheckToken(token, Scopes.esi_characters_read_corporation_roles_v1);

            string url = StaticConnectionStrings.EsiV2CharacterRoles(characterId);

            string esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            EsiV2CharacterRoles esiV2CharacterRoles = JsonConvert.DeserializeObject<EsiV2CharacterRoles>(esiRaw);

            return _mapper.Map<EsiV2CharacterRoles, V2CharacterRoles>(esiV2CharacterRoles);
        }

        public async Task<V2CharacterRoles> GetCharactersRolesAsync(SsoToken token, int characterId)
        {
            StaticMethods.CheckToken(token, Scopes.esi_characters_read_corporation_roles_v1);

            string url = StaticConnectionStrings.EsiV2CharacterRoles(characterId);

            string esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            EsiV2CharacterRoles esiV2CharacterRoles = JsonConvert.DeserializeObject<EsiV2CharacterRoles>(esiRaw);

            return _mapper.Map<EsiV2CharacterRoles, V2CharacterRoles>(esiV2CharacterRoles);
        }

        public IList<V2CharactersStandings> GetCharactersStandings(SsoToken token, int characterId)
        {
            StaticMethods.CheckToken(token, Scopes.esi_characters_read_standings_v1);

            string url = StaticConnectionStrings.EsiV2CharactersStandings(characterId);

            string esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV2CharactersStandings> esiV2CharactersStandings = JsonConvert.DeserializeObject<IList<EsiV2CharactersStandings>>(esiRaw);

            return _mapper.Map<IList<EsiV2CharactersStandings>, IList<V2CharactersStandings>>(esiV2CharactersStandings);
        }

        public async Task<IList<V2CharactersStandings>> GetCharactersStandingsAsync(SsoToken token, int characterId)
        {
            StaticMethods.CheckToken(token, Scopes.esi_characters_read_standings_v1);

            string url = StaticConnectionStrings.EsiV2CharactersStandings(characterId);

            string esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV2CharactersStandings> esiV2CharactersStandings = JsonConvert.DeserializeObject<IList<EsiV2CharactersStandings>>(esiRaw);

            return _mapper.Map<IList<EsiV2CharactersStandings>, IList<V2CharactersStandings>>(esiV2CharactersStandings);
        }

        public IList<V2CharactersStats> GetCharactersStats(SsoToken token, int characterId)
        {
            StaticMethods.CheckToken(token, Scopes.esi_characterstats_read_v1);

            string url = StaticConnectionStrings.EsiV2CharactersStats(characterId);

            string esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 86400));

            IList<EsiV2CharactersStats> esiV2CharactersStats = JsonConvert.DeserializeObject<IList<EsiV2CharactersStats>>(esiRaw);

            return _mapper.Map<IList<EsiV2CharactersStats>, IList<V2CharactersStats>>(esiV2CharactersStats);
        }

        public async Task<IList<V2CharactersStats>> GetCharactersStatsAsync(SsoToken token, int characterId)
        {
            StaticMethods.CheckToken(token, Scopes.esi_characterstats_read_v1);

            string url = StaticConnectionStrings.EsiV2CharactersStats(characterId);

            string esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 86400));

            IList<EsiV2CharactersStats> esiV2CharactersStats = JsonConvert.DeserializeObject<IList<EsiV2CharactersStats>>(esiRaw);

            return _mapper.Map<IList<EsiV2CharactersStats>, IList<V2CharactersStats>>(esiV2CharactersStats);
        }

        public IList<V1CharacterTitles> GetCharactersTitles(SsoToken token, int characterId)
        {
            StaticMethods.CheckToken(token, Scopes.esi_characters_read_titles_v1);

            string url = StaticConnectionStrings.EsiV1CharacterTitles(characterId);

            string esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1CharacterTitles> esiV1CharacterTitles = JsonConvert.DeserializeObject<IList<EsiV1CharacterTitles>>(esiRaw);

            return _mapper.Map<IList<EsiV1CharacterTitles>, IList<V1CharacterTitles>>(esiV1CharacterTitles);
        }

        public async Task<IList<V1CharacterTitles>> GetCharactersTitlesAsync(SsoToken token, int characterId)
        {
            StaticMethods.CheckToken(token, Scopes.esi_characters_read_titles_v1);

            string url = StaticConnectionStrings.EsiV1CharacterTitles(characterId);

            string esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(token), url, 3600));

            IList<EsiV1CharacterTitles> esiV1CharacterTitles = JsonConvert.DeserializeObject<IList<EsiV1CharacterTitles>>(esiRaw);

            return _mapper.Map<IList<EsiV1CharacterTitles>, IList<V1CharacterTitles>>(esiV1CharacterTitles);
        }

        public IList<V1CharacterAffiliations> GetCharactersAffiliation(IList<int> characters)
        {
            string url = StaticConnectionStrings.EsiV1CharacterAffiliations();

            string jsonObject = JsonConvert.SerializeObject(characters);

            string esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Post(StaticMethods.CreateHeaders(), url, jsonObject, 3600));

            IList<EsiV1CharacterAffiliations> esiV1CharacterAffiliations = JsonConvert.DeserializeObject<IList<EsiV1CharacterAffiliations>>(esiRaw);

            return _mapper.Map<IList<EsiV1CharacterAffiliations>, IList<V1CharacterAffiliations>>(esiV1CharacterAffiliations);
        }

        public async Task<IList<V1CharacterAffiliations>> GetCharactersAffiliationAsync(IList<int> characters)
        {
            string url = StaticConnectionStrings.EsiV1CharacterAffiliations();

            string jsonObject = JsonConvert.SerializeObject(characters);

            string esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.PostAsync(StaticMethods.CreateHeaders(), url, jsonObject, 3600));

            IList<EsiV1CharacterAffiliations> esiV1CharacterAffiliations = JsonConvert.DeserializeObject<IList<EsiV1CharacterAffiliations>>(esiRaw);

            return _mapper.Map<IList<EsiV1CharacterAffiliations>, IList<V1CharacterAffiliations>>(esiV1CharacterAffiliations);
        }

        public IList<V1CharactersNames> GetCharactersNames(IList<int> characters)
        {
            string url = StaticConnectionStrings.EsiV1CharactersNames(characters);

            string esiRaw = PollyPolicies.WebExceptionRetryWithFallback.Execute(() => _webClient.Get(StaticMethods.CreateHeaders(), url, 3600));

            IList<EsiV1CharactersNames> esiV1CharactersNames = JsonConvert.DeserializeObject<IList<EsiV1CharactersNames>>(esiRaw);

            return _mapper.Map<IList<EsiV1CharactersNames>, IList<V1CharactersNames>>(esiV1CharactersNames);
        }

        public async Task<IList<V1CharactersNames>> GetCharactersNamesAsync(IList<int> characters)
        {
            string url = StaticConnectionStrings.EsiV1CharactersNames(characters);

            string esiRaw = await PollyPolicies.WebExceptionRetryWithFallbackAsync.ExecuteAsync( async () => await _webClient.GetAsync(StaticMethods.CreateHeaders(), url, 3600));

            IList<EsiV1CharactersNames> esiV1CharactersNames = JsonConvert.DeserializeObject<IList<EsiV1CharactersNames>>(esiRaw);

            return _mapper.Map<IList<EsiV1CharactersNames>, IList<V1CharactersNames>>(esiV1CharactersNames);
        }
    }
}
