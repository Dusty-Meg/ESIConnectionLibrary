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

        public V4CharactersPublicInfo PublicInfo(int characterId)
        {
            return _internalLatestCharacter.PublicInfo(characterId);
        }

        public async Task<V4CharactersPublicInfo> PublicInfoAsync(int characterId)
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

        public IList<V2CharactersBlueprints> Blueprint(SsoToken token)
        {
            return _internalLatestCharacter.Blueprints(token);
        }

        public async Task<IList<V2CharactersBlueprints>> BlueprintAsync(SsoToken token)
        {
            return await _internalLatestCharacter.BlueprintsAsync(token);
        }

        public IList<V1CharactersCorporationHistory> CorporationHistory(int characterId)
        {
            return _internalLatestCharacter.CorporationHistory(characterId);
        }

        public async Task<IList<V1CharactersCorporationHistory>> CorporationHistoryAsync(int characterId)
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

        public V1CharactersFatigue Fatigue(SsoToken token)
        {
            return _internalLatestCharacter.Fatigue(token);
        }

        public async Task<V1CharactersFatigue> FatigueAsync(SsoToken token)
        {
            return await _internalLatestCharacter.FatigueAsync(token);
        }

        public IList<V1CharactersMedals> Medals(SsoToken token)
        {
            return _internalLatestCharacter.Medals(token);
        }

        public async Task<IList<V1CharactersMedals>> MedalsAsync(SsoToken token)
        {
            return await _internalLatestCharacter.MedalsAsync(token);
        }

        public IList<V4CharactersNotifications> Notifications(SsoToken token)
        {
            return _internalLatestCharacter.Notifications(token);
        }

        public async Task<IList<V4CharactersNotifications>> NotificationsAsync(SsoToken token)
        {
            return await _internalLatestCharacter.NotificationsAsync(token);
        }

        public IList<V1CharactersNotificationsContacts> ContactNotifications(SsoToken token)
        {
            return _internalLatestCharacter.ContactNotifications(token);
        }

        public async Task<IList<V1CharactersNotificationsContacts>> ContactNotificationsAsync(SsoToken token)
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

        public V2CharacterRoles Roles(SsoToken token)
        {
            return _internalLatestCharacter.Roles(token);
        }

        public async Task<V2CharacterRoles> RolesAsync(SsoToken token)
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

        public IList<V2CharactersStats> Stats(SsoToken token)
        {
            return _internalLatestCharacter.Stats(token);
        }

        public async Task<IList<V2CharactersStats>> StatsAsync(SsoToken token)
        {
            return await _internalLatestCharacter.StatsAsync(token);
        }

        public IList<V1CharacterTitles> Titles(SsoToken token)
        {
            return _internalLatestCharacter.Titles(token);
        }

        public async Task<IList<V1CharacterTitles>> TitlesAsync(SsoToken token)
        {
            return await _internalLatestCharacter.TitlesAsync(token);
        }

        public IList<V1CharacterAffiliations> Affiliations(IList<int> characters)
        {
            return _internalLatestCharacter.Affiliations(characters);
        }

        public async Task<IList<V1CharacterAffiliations>> AffiliationsAsync(IList<int> characters)
        {
            return await _internalLatestCharacter.AffiliationsAsync(characters);
        }
    }
}
