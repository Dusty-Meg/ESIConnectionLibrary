using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public class LatestCharacterEndpoints : ILatestCharacterEndpoints
    {
        private readonly IInternalLatestCharacter _internalLatestCharacter;

        public LatestCharacterEndpoints(string userAgent, bool testing = false)
        {
            _internalLatestCharacter = new InternalLatestCharacter(null, userAgent, testing);
        }

        internal LatestCharacterEndpoints(string userAgent, IWebClient webClient, bool testing = false)
        {
            _internalLatestCharacter = new InternalLatestCharacter(webClient, userAgent, testing);
        }

        public V5CharactersPublicInfo PublicInfo(int characterId)
        {
            return _internalLatestCharacter.PublicInfo(characterId);
        }

        public async Task<V5CharactersPublicInfo> PublicInfoAsync(int characterId)
        {
            return await _internalLatestCharacter.PublicInfoAsync(characterId);
        }

        public IList<V1CharactersResearchAgents> ResearchAgents(SsoToken token)
        {
            return _internalLatestCharacter.ResearchAgents(token);
        }

        public async Task<IList<V1CharactersResearchAgents>> ResearchAgentsAsync(SsoToken token)
        {
            return await _internalLatestCharacter.ResearchAgentsAsync(token);
        }

        public IList<V3CharactersBlueprints> Blueprint(SsoToken token)
        {
            return _internalLatestCharacter.Blueprints(token);
        }

        public async Task<IList<V3CharactersBlueprints>> BlueprintAsync(SsoToken token)
        {
            return await _internalLatestCharacter.BlueprintsAsync(token);
        }

        public IList<V2CharactersCorporationHistory> CorporationHistory(int characterId)
        {
            return _internalLatestCharacter.CorporationHistory(characterId);
        }

        public async Task<IList<V2CharactersCorporationHistory>> CorporationHistoryAsync(int characterId)
        {
            return await _internalLatestCharacter.CorporationHistoryAsync(characterId);
        }

        public float CspaCost(SsoToken token, IList<int> characters)
        {
            return _internalLatestCharacter.CspaCost(token, characters);
        }

        public async Task<float> CspaCostAsync(SsoToken token, IList<int> characters)
        {
            return await _internalLatestCharacter.CspaCostAsync(token, characters);
        }

        public V2CharactersFatigue Fatigue(SsoToken token)
        {
            return _internalLatestCharacter.Fatigue(token);
        }

        public async Task<V2CharactersFatigue> FatigueAsync(SsoToken token)
        {
            return await _internalLatestCharacter.FatigueAsync(token);
        }

        public IList<V2CharactersMedals> Medals(SsoToken token)
        {
            return _internalLatestCharacter.Medals(token);
        }

        public async Task<IList<V2CharactersMedals>> MedalsAsync(SsoToken token)
        {
            return await _internalLatestCharacter.MedalsAsync(token);
        }

        public IList<V5CharactersNotifications> Notifications(SsoToken token)
        {
            return _internalLatestCharacter.Notifications(token);
        }

        public async Task<IList<V5CharactersNotifications>> NotificationsAsync(SsoToken token)
        {
            return await _internalLatestCharacter.NotificationsAsync(token);
        }

        public IList<V2CharactersNotificationsContacts> ContactNotifications(SsoToken token)
        {
            return _internalLatestCharacter.ContactNotifications(token);
        }

        public async Task<IList<V2CharactersNotificationsContacts>> ContactNotificationsAsync(SsoToken token)
        {
            return await _internalLatestCharacter.ContactNotificationsAsync(token);
        }

        public V2CharactersPortrait Portrait(int characterId)
        {
            return _internalLatestCharacter.Portrait(characterId);
        }

        public async Task<V2CharactersPortrait> PortraitAsync(int characterId)
        {
            return await _internalLatestCharacter.PortraitAsync(characterId);
        }

        public V3CharacterRoles Roles(SsoToken token)
        {
            return _internalLatestCharacter.Roles(token);
        }

        public async Task<V3CharacterRoles> RolesAsync(SsoToken token)
        {
            return await _internalLatestCharacter.RolesAsync(token);
        }

        public IList<V2CharactersStandings> Standings(SsoToken token)
        {
            return _internalLatestCharacter.Standings(token);
        }

        public async Task<IList<V2CharactersStandings>> StandingsAsync(SsoToken token)
        {
            return await _internalLatestCharacter.StandingsAsync(token);
        }

        public IList<V2CharacterTitles> Titles(SsoToken token)
        {
            return _internalLatestCharacter.Titles(token);
        }

        public async Task<IList<V2CharacterTitles>> TitlesAsync(SsoToken token)
        {
            return await _internalLatestCharacter.TitlesAsync(token);
        }

        public IList<V2CharacterAffiliations> Affiliations(IList<int> characters)
        {
            return _internalLatestCharacter.Affiliations(characters);
        }

        public async Task<IList<V2CharacterAffiliations>> AffiliationsAsync(IList<int> characters)
        {
            return await _internalLatestCharacter.AffiliationsAsync(characters);
        }
    }
}
