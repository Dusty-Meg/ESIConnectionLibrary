using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Internal_classes
{
    internal interface IInternalLatestCharacter
    {
        IList<V1CharacterAffiliations> GetCharactersAffiliation(IList<int> characters);
        Task<IList<V1CharacterAffiliations>> GetCharactersAffiliationAsync(IList<int> characters);
        IList<V2CharactersBlueprints> GetCharactersBlueprint(SsoToken token);
        Task<IList<V2CharactersBlueprints>> GetCharactersBlueprintAsync(SsoToken token);
        IList<V1CharactersCorporationHistory> GetCharactersCorporationHistory(int characterId);
        Task<IList<V1CharactersCorporationHistory>> GetCharactersCorporationHistoryAsync(int characterId);
        float GetCharactersCspaCost(SsoToken token, IList<int> characters);
        Task<float> GetCharactersCspaCostAsync(SsoToken token, IList<int> characters);
        V1CharactersFatigue GetCharactersFatigue(SsoToken token);
        Task<V1CharactersFatigue> GetCharactersFatigueAsync(SsoToken token);
        IList<V1CharactersMedals> GetCharactersMedals(SsoToken token);
        Task<IList<V1CharactersMedals>> GetCharactersMedalsAsync(SsoToken token);
        IList<V1CharactersNames> GetCharactersNames(IList<int> characters);
        Task<IList<V1CharactersNames>> GetCharactersNamesAsync(IList<int> characters);
        IList<V2CharactersNotifications> GetCharactersNotifications(SsoToken token);
        Task<IList<V2CharactersNotifications>> GetCharactersNotificationsAsync(SsoToken token);
        IList<V1CharactersNotificationsContacts> GetCharactersNotificationsContacts(SsoToken token);
        Task<IList<V1CharactersNotificationsContacts>> GetCharactersNotificationsContactsAsync(SsoToken token);
        V2CharactersPortrait GetCharactersPortrait(int characterId);
        Task<V2CharactersPortrait> GetCharactersPortraitAsync(int characterId);
        V4CharactersPublicInfo GetCharactersPublicInfo(int characterId);
        Task<V4CharactersPublicInfo> GetCharactersPublicInfoAsync(int characterId);
        IList<V1CharactersResearchAgents> GetCharactersResearchAgents(SsoToken token);
        Task<IList<V1CharactersResearchAgents>> GetCharactersResearchAgentsAsync(SsoToken token);
        V2CharacterRoles GetCharactersRoles(SsoToken token);
        Task<V2CharacterRoles> GetCharactersRolesAsync(SsoToken token);
        IList<V2CharactersStandings> GetCharactersStandings(SsoToken token);
        Task<IList<V2CharactersStandings>> GetCharactersStandingsAsync(SsoToken token);
        IList<V2CharactersStats> GetCharactersStats(SsoToken token);
        Task<IList<V2CharactersStats>> GetCharactersStatsAsync(SsoToken token);
        IList<V1CharacterTitles> GetCharactersTitles(SsoToken token);
        Task<IList<V1CharacterTitles>> GetCharactersTitlesAsync(SsoToken token);
    }
}