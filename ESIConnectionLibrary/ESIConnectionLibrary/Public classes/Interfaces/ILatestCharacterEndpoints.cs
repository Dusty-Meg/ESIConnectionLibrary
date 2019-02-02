using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public interface ILatestCharacterEndpoints
    {
        IList<V1CharacterAffiliations> Affiliations(IList<int> characters);
        Task<IList<V1CharacterAffiliations>> AffiliationsAsync(IList<int> characters);
        IList<V2CharactersBlueprints> Blueprint(SsoToken token);
        Task<IList<V2CharactersBlueprints>> BlueprintAsync(SsoToken token);
        IList<V1CharactersCorporationHistory> CorporationHistory(int characterId);
        Task<IList<V1CharactersCorporationHistory>> CorporationHistoryAsync(int characterId);
        float CspaCost(SsoToken token, IList<int> characters);
        Task<float> CspaCostAsync(SsoToken token, IList<int> characters);
        V1CharactersFatigue Fatigue(SsoToken token);
        Task<V1CharactersFatigue> FatigueAsync(SsoToken token);
        IList<V1CharactersMedals> Medals(SsoToken token);
        Task<IList<V1CharactersMedals>> MedalsAsync(SsoToken token);
        IList<V4CharactersNotifications> Notifications(SsoToken token);
        Task<IList<V4CharactersNotifications>> NotificationsAsync(SsoToken token);
        IList<V1CharactersNotificationsContacts> ContactNotifications(SsoToken token);
        Task<IList<V1CharactersNotificationsContacts>> ContactNotificationsAsync(SsoToken token);
        V2CharactersPortrait Portrait(int characterId);
        Task<V2CharactersPortrait> PortraitAsync(int characterId);
        V4CharactersPublicInfo PublicInfo(int characterId);
        Task<V4CharactersPublicInfo> PublicInfoAsync(int characterId);
        IList<V1CharactersResearchAgents> ResearchAgents(SsoToken token);
        Task<IList<V1CharactersResearchAgents>> ResearchAgentsAsync(SsoToken token);
        V2CharacterRoles Roles(SsoToken token);
        Task<V2CharacterRoles> RolesAsync(SsoToken token);
        IList<V2CharactersStandings> Standings(SsoToken token);
        Task<IList<V2CharactersStandings>> StandingsAsync(SsoToken token);
        IList<V2CharactersStats> Stats(SsoToken token);
        Task<IList<V2CharactersStats>> StatsAsync(SsoToken token);
        IList<V1CharacterTitles> Titles(SsoToken token);
        Task<IList<V1CharacterTitles>> TitlesAsync(SsoToken token);
    }
}