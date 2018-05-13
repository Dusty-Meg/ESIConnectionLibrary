using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public class LatestCharacterEndpoints : ILatestCharacterEndpoints
    {
        private readonly IInternalLatestCharacter _internalLatestCharacter;

        public LatestCharacterEndpoints(string userAgent)
        {
            _internalLatestCharacter = new InternalLatestCharacter(null, userAgent);
        }

        public V4CharactersPublicInfo GetCharactersPublicInfo(int characterId)
        {
            return _internalLatestCharacter.GetCharactersPublicInfo(characterId);
        }

        public async Task<V4CharactersPublicInfo> GetCharactersPublicInfoAsync(int characterId)
        {
            return await _internalLatestCharacter.GetCharactersPublicInfoAsync(characterId);
        }

        public IList<V1CharactersResearchAgents> GetCharactersResearchAgents(SsoToken token, int characterId)
        {
            return _internalLatestCharacter.GetCharactersResearchAgents(token, characterId);
        }

        public async Task<IList<V1CharactersResearchAgents>> GetCharactersResearchAgentsAsync(SsoToken token, int characterId)
        {
            return await _internalLatestCharacter.GetCharactersResearchAgentsAsync(token, characterId);
        }

        public IList<V2CharactersBlueprints> GetCharactersBlueprint(SsoToken token, int characterId)
        {
            return _internalLatestCharacter.GetCharactersBlueprint(token, characterId);
        }

        public async Task<IList<V2CharactersBlueprints>> GetCharactersBlueprintAsync(SsoToken token, int characterId)
        {
            return await _internalLatestCharacter.GetCharactersBlueprintAsync(token, characterId);
        }

        public IList<V1CharactersChatChannels> GetCharactersChatChannels(SsoToken token, int characterId)
        {
            return _internalLatestCharacter.GetCharactersChatChannels(token, characterId);
        }

        public async Task<IList<V1CharactersChatChannels>> GetCharactersChatChannelsAsync(SsoToken token, int characterId)
        {
            return await _internalLatestCharacter.GetCharactersChatChannelsAsync(token, characterId);
        }

        public IList<V1CharactersCorporationHistory> GetCharactersCorporationHistory(int characterId)
        {
            return _internalLatestCharacter.GetCharactersCorporationHistory(characterId);
        }

        public async Task<IList<V1CharactersCorporationHistory>> GetCharactersCorporationHistoryAsync(int characterId)
        {
            return await _internalLatestCharacter.GetCharactersCorporationHistoryAsync(characterId);
        }

        public float GetCharactersCspaCost(SsoToken token, int characterId, IList<int> characters)
        {
            return _internalLatestCharacter.GetCharactersCspaCost(token, characterId, characters);
        }

        public async Task<float> GetCharactersCspaCostAsync(SsoToken token, int characterId, IList<int> characters)
        {
            return await _internalLatestCharacter.GetCharactersCspaCostAsync(token, characterId, characters);
        }

        public V1CharactersFatigue GetCharactersFatigue(SsoToken token, int characterId)
        {
            return _internalLatestCharacter.GetCharactersFatigue(token, characterId);
        }

        public async Task<V1CharactersFatigue> GetCharactersFatigueAsync(SsoToken token, int characterId)
        {
            return await _internalLatestCharacter.GetCharactersFatigueAsync(token, characterId);
        }

        public IList<V1CharactersMedals> GetCharactersMedals(SsoToken token, int characterId)
        {
            return _internalLatestCharacter.GetCharactersMedals(token, characterId);
        }

        public async Task<IList<V1CharactersMedals>> GetCharactersMedalsAsync(SsoToken token, int characterId)
        {
            return await _internalLatestCharacter.GetCharactersMedalsAsync(token, characterId);
        }

        public IList<V2CharactersNotifications> GetCharactersNotifications(SsoToken token, int characterId)
        {
            return _internalLatestCharacter.GetCharactersNotifications(token, characterId);
        }

        public async Task<IList<V2CharactersNotifications>> GetCharactersNotificationsAsync(SsoToken token, int characterId)
        {
            return await _internalLatestCharacter.GetCharactersNotificationsAsync(token, characterId);
        }

        public IList<V1CharactersNotificationsContacts> GetCharactersNotificationsContacts(SsoToken token, int characterId)
        {
            return _internalLatestCharacter.GetCharactersNotificationsContacts(token, characterId);
        }

        public async Task<IList<V1CharactersNotificationsContacts>> GetCharactersNotificationsContactsAsync(SsoToken token, int characterId)
        {
            return await _internalLatestCharacter.GetCharactersNotificationsContactsAsync(token, characterId);
        }

        public V2CharactersPortrait GetCharactersPortrait(int characterId)
        {
            return _internalLatestCharacter.GetCharactersPortrait(characterId);
        }

        public async Task<V2CharactersPortrait> GetCharactersPortraitAsync(int characterId)
        {
            return await _internalLatestCharacter.GetCharactersPortraitAsync(characterId);
        }

        public V2CharacterRoles GetCharactersRoles(SsoToken token, int characterId)
        {
            return _internalLatestCharacter.GetCharactersRoles(token, characterId);
        }

        public async Task<V2CharacterRoles> GetCharactersRolesAsync(SsoToken token, int characterId)
        {
            return await _internalLatestCharacter.GetCharactersRolesAsync(token, characterId);
        }

        public IList<V2CharactersStandings> GetCharactersStandings(SsoToken token, int characterId)
        {
            return _internalLatestCharacter.GetCharactersStandings(token, characterId);
        }

        public async Task<IList<V2CharactersStandings>> GetCharactersStandingsAsync(SsoToken token, int characterId)
        {
            return await _internalLatestCharacter.GetCharactersStandingsAsync(token, characterId);
        }

        public IList<V2CharactersStats> GetCharactersStats(SsoToken token, int characterId)
        {
            return _internalLatestCharacter.GetCharactersStats(token, characterId);
        }

        public async Task<IList<V2CharactersStats>> GetCharactersStatsAsync(SsoToken token, int characterId)
        {
            return await _internalLatestCharacter.GetCharactersStatsAsync(token, characterId);
        }

        public IList<V1CharacterTitles> GetCharactersTitles(SsoToken token, int characterId)
        {
            return _internalLatestCharacter.GetCharactersTitles(token, characterId);
        }

        public async Task<IList<V1CharacterTitles>> GetCharactersTitlesAsync(SsoToken token, int characterId)
        {
            return await _internalLatestCharacter.GetCharactersTitlesAsync(token, characterId);
        }

        public IList<V1CharacterAffiliations> GetCharactersAffiliation(IList<int> characters)
        {
            return _internalLatestCharacter.GetCharactersAffiliation(characters);
        }

        public async Task<IList<V1CharacterAffiliations>> GetCharactersAffiliationAsync(IList<int> characters)
        {
            return await _internalLatestCharacter.GetCharactersAffiliationAsync(characters);
        }

        public IList<V1CharactersNames> GetCharactersNames(IList<int> characters)
        {
            return _internalLatestCharacter.GetCharactersNames(characters);
        }

        public async Task<IList<V1CharactersNames>> GetCharactersNamesAsync(IList<int> characters)
        {
            return await _internalLatestCharacter.GetCharactersNamesAsync(characters);
        }

    }
}
