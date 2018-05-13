using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public interface ILatestCharacterEndpoints
    {
        IList<V1CharacterAffiliations> GetCharactersAffiliation(IList<int> characters);
        Task<IList<V1CharacterAffiliations>> GetCharactersAffiliationAsync(IList<int> characters);
        IList<V2CharactersBlueprints> GetCharactersBlueprint(SsoToken token, int characterId);
        Task<IList<V2CharactersBlueprints>> GetCharactersBlueprintAsync(SsoToken token, int characterId);
        IList<V1CharactersChatChannels> GetCharactersChatChannels(SsoToken token, int characterId);
        Task<IList<V1CharactersChatChannels>> GetCharactersChatChannelsAsync(SsoToken token, int characterId);
        IList<V1CharactersCorporationHistory> GetCharactersCorporationHistory(int characterId);
        Task<IList<V1CharactersCorporationHistory>> GetCharactersCorporationHistoryAsync(int characterId);
        float GetCharactersCspaCost(SsoToken token, int characterId, IList<int> characters);
        Task<float> GetCharactersCspaCostAsync(SsoToken token, int characterId, IList<int> characters);
        V1CharactersFatigue GetCharactersFatigue(SsoToken token, int characterId);
        Task<V1CharactersFatigue> GetCharactersFatigueAsync(SsoToken token, int characterId);
        IList<V1CharactersMedals> GetCharactersMedals(SsoToken token, int characterId);
        Task<IList<V1CharactersMedals>> GetCharactersMedalsAsync(SsoToken token, int characterId);
        IList<V2CharactersNotifications> GetCharactersNotifications(SsoToken token, int characterId);
        Task<IList<V2CharactersNotifications>> GetCharactersNotificationsAsync(SsoToken token, int characterId);
        IList<V1CharactersNotificationsContacts> GetCharactersNotificationsContacts(SsoToken token, int characterId);
        Task<IList<V1CharactersNotificationsContacts>> GetCharactersNotificationsContactsAsync(SsoToken token, int characterId);
        V2CharactersPortrait GetCharactersPortrait(int characterId);
        Task<V2CharactersPortrait> GetCharactersPortraitAsync(int characterId);
        V4CharactersPublicInfo GetCharactersPublicInfo(int characterId);
        Task<V4CharactersPublicInfo> GetCharactersPublicInfoAsync(int characterId);
        IList<V1CharactersNames> GetCharactersNames(IList<int> characters);
        IList<V1CharactersResearchAgents> GetCharactersResearchAgents(SsoToken token, int characterId);
        Task<IList<V1CharactersNames>> GetCharactersNamesAsync(IList<int> characters);
        Task<IList<V1CharactersResearchAgents>> GetCharactersResearchAgentsAsync(SsoToken token, int characterId);
        V2CharacterRoles GetCharactersRoles(SsoToken token, int characterId);
        Task<V2CharacterRoles> GetCharactersRolesAsync(SsoToken token, int characterId);
        IList<V2CharactersStandings> GetCharactersStandings(SsoToken token, int characterId);
        Task<IList<V2CharactersStandings>> GetCharactersStandingsAsync(SsoToken token, int characterId);
        IList<V2CharactersStats> GetCharactersStats(SsoToken token, int characterId);
        Task<IList<V2CharactersStats>> GetCharactersStatsAsync(SsoToken token, int characterId);
        IList<V1CharacterTitles> GetCharactersTitles(SsoToken token, int characterId);
        Task<IList<V1CharacterTitles>> GetCharactersTitlesAsync(SsoToken token, int characterId);
    }
}