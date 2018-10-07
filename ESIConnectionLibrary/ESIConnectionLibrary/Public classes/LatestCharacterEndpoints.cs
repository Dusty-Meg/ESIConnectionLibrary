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

        public V4CharactersPublicInfo GetCharactersPublicInfo(int characterId)
        {
            return _internalLatestCharacter.GetCharactersPublicInfo(characterId);
        }

        public async Task<V4CharactersPublicInfo> GetCharactersPublicInfoAsync(int characterId)
        {
            return await _internalLatestCharacter.GetCharactersPublicInfoAsync(characterId);
        }

        public IList<V1CharactersResearchAgents> GetCharactersResearchAgents(SsoToken token)
        {
            return _internalLatestCharacter.GetCharactersResearchAgents(token);
        }

        public async Task<IList<V1CharactersResearchAgents>> GetCharactersResearchAgentsAsync(SsoToken token)
        {
            return await _internalLatestCharacter.GetCharactersResearchAgentsAsync(token);
        }

        public IList<V2CharactersBlueprints> GetCharactersBlueprint(SsoToken token)
        {
            return _internalLatestCharacter.GetCharactersBlueprint(token);
        }

        public async Task<IList<V2CharactersBlueprints>> GetCharactersBlueprintAsync(SsoToken token)
        {
            return await _internalLatestCharacter.GetCharactersBlueprintAsync(token);
        }

        public IList<V1CharactersCorporationHistory> GetCharactersCorporationHistory(int characterId)
        {
            return _internalLatestCharacter.GetCharactersCorporationHistory(characterId);
        }

        public async Task<IList<V1CharactersCorporationHistory>> GetCharactersCorporationHistoryAsync(int characterId)
        {
            return await _internalLatestCharacter.GetCharactersCorporationHistoryAsync(characterId);
        }

        public float GetCharactersCspaCost(SsoToken token, IList<int> characters)
        {
            return _internalLatestCharacter.GetCharactersCspaCost(token, characters);
        }

        public async Task<float> GetCharactersCspaCostAsync(SsoToken token, IList<int> characters)
        {
            return await _internalLatestCharacter.GetCharactersCspaCostAsync(token, characters);
        }

        public V1CharactersFatigue GetCharactersFatigue(SsoToken token)
        {
            return _internalLatestCharacter.GetCharactersFatigue(token);
        }

        public async Task<V1CharactersFatigue> GetCharactersFatigueAsync(SsoToken token)
        {
            return await _internalLatestCharacter.GetCharactersFatigueAsync(token);
        }

        public IList<V1CharactersMedals> GetCharactersMedals(SsoToken token)
        {
            return _internalLatestCharacter.GetCharactersMedals(token);
        }

        public async Task<IList<V1CharactersMedals>> GetCharactersMedalsAsync(SsoToken token)
        {
            return await _internalLatestCharacter.GetCharactersMedalsAsync(token);
        }

        public IList<V3CharactersNotifications> GetCharactersNotifications(SsoToken token)
        {
            return _internalLatestCharacter.GetCharactersNotifications(token);
        }

        public async Task<IList<V3CharactersNotifications>> GetCharactersNotificationsAsync(SsoToken token)
        {
            return await _internalLatestCharacter.GetCharactersNotificationsAsync(token);
        }

        public IList<V1CharactersNotificationsContacts> GetCharactersNotificationsContacts(SsoToken token)
        {
            return _internalLatestCharacter.GetCharactersNotificationsContacts(token);
        }

        public async Task<IList<V1CharactersNotificationsContacts>> GetCharactersNotificationsContactsAsync(SsoToken token)
        {
            return await _internalLatestCharacter.GetCharactersNotificationsContactsAsync(token);
        }

        public V2CharactersPortrait GetCharactersPortrait(int characterId)
        {
            return _internalLatestCharacter.GetCharactersPortrait(characterId);
        }

        public async Task<V2CharactersPortrait> GetCharactersPortraitAsync(int characterId)
        {
            return await _internalLatestCharacter.GetCharactersPortraitAsync(characterId);
        }

        public V2CharacterRoles GetCharactersRoles(SsoToken token)
        {
            return _internalLatestCharacter.GetCharactersRoles(token);
        }

        public async Task<V2CharacterRoles> GetCharactersRolesAsync(SsoToken token)
        {
            return await _internalLatestCharacter.GetCharactersRolesAsync(token);
        }

        public IList<V2CharactersStandings> GetCharactersStandings(SsoToken token)
        {
            return _internalLatestCharacter.GetCharactersStandings(token);
        }

        public async Task<IList<V2CharactersStandings>> GetCharactersStandingsAsync(SsoToken token)
        {
            return await _internalLatestCharacter.GetCharactersStandingsAsync(token);
        }

        public IList<V2CharactersStats> GetCharactersStats(SsoToken token)
        {
            return _internalLatestCharacter.GetCharactersStats(token);
        }

        public async Task<IList<V2CharactersStats>> GetCharactersStatsAsync(SsoToken token)
        {
            return await _internalLatestCharacter.GetCharactersStatsAsync(token);
        }

        public IList<V1CharacterTitles> GetCharactersTitles(SsoToken token)
        {
            return _internalLatestCharacter.GetCharactersTitles(token);
        }

        public async Task<IList<V1CharacterTitles>> GetCharactersTitlesAsync(SsoToken token)
        {
            return await _internalLatestCharacter.GetCharactersTitlesAsync(token);
        }

        public IList<V1CharacterAffiliations> GetCharactersAffiliation(IList<int> characters)
        {
            return _internalLatestCharacter.GetCharactersAffiliation(characters);
        }

        public async Task<IList<V1CharacterAffiliations>> GetCharactersAffiliationAsync(IList<int> characters)
        {
            return await _internalLatestCharacter.GetCharactersAffiliationAsync(characters);
        }
    }
}
