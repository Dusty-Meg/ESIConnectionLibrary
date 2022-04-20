using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Internal_classes
{
    internal interface IInternalLatestCharacter
    {
        IList<V2CharacterAffiliations> Affiliations(IList<int> characters);
        Task<IList<V2CharacterAffiliations>> AffiliationsAsync(IList<int> characters);
        IList<V3CharactersBlueprints> Blueprints(SsoToken token);
        Task<IList<V3CharactersBlueprints>> BlueprintsAsync(SsoToken token);
        IList<V2CharactersCorporationHistory> CorporationHistory(int characterId);
        Task<IList<V2CharactersCorporationHistory>> CorporationHistoryAsync(int characterId);
        float CspaCost(SsoToken token, IList<int> characters);
        Task<float> CspaCostAsync(SsoToken token, IList<int> characters);
        V2CharactersFatigue Fatigue(SsoToken token);
        Task<V2CharactersFatigue> FatigueAsync(SsoToken token);
        IList<V2CharactersMedals> Medals(SsoToken token);
        Task<IList<V2CharactersMedals>> MedalsAsync(SsoToken token);
        IList<V5CharactersNotifications> Notifications(SsoToken token);
        Task<IList<V5CharactersNotifications>> NotificationsAsync(SsoToken token);
        IList<V2CharactersNotificationsContacts> ContactNotifications(SsoToken token);
        Task<IList<V2CharactersNotificationsContacts>> ContactNotificationsAsync(SsoToken token);
        V2CharactersPortrait Portrait(int characterId);
        Task<V2CharactersPortrait> PortraitAsync(int characterId);
        V5CharactersPublicInfo PublicInfo(int characterId);
        Task<V5CharactersPublicInfo> PublicInfoAsync(int characterId);
        IList<V1CharactersResearchAgents> ResearchAgents(SsoToken token);
        Task<IList<V1CharactersResearchAgents>> ResearchAgentsAsync(SsoToken token);
        V3CharacterRoles Roles(SsoToken token);
        Task<V3CharacterRoles> RolesAsync(SsoToken token);
        IList<V2CharactersStandings> Standings(SsoToken token);
        Task<IList<V2CharactersStandings>> StandingsAsync(SsoToken token);
        IList<V2CharacterTitles> Titles(SsoToken token);
        Task<IList<V2CharacterTitles>> TitlesAsync(SsoToken token);
    }
}