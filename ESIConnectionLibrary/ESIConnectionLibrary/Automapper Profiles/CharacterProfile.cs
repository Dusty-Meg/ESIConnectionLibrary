using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Automapper_Profiles
{
    internal class CharacterProfile : Profile
    {
        public CharacterProfile()
        {
            CreateMap<EsiV2CharacterAffiliations, V2CharacterAffiliations>();
            CreateMap<EsiV2CharacterTitles, V2CharacterTitles>();
            CreateMap<EsiV2CharactersStandings, V2CharactersStandings>();
            CreateMap<EsiV3CharacterRoles, V3CharacterRoles>();
            CreateMap<EsiV2CharactersPortrait, V2CharactersPortrait>();
            CreateMap<EsiV2CharactersNotificationsContacts, V2CharactersNotificationsContacts>();
            CreateMap<EsiV6CharactersNotifications, V6CharactersNotifications>();
            CreateMap<EsiV2CharactersMedals, V2CharactersMedals>();
            CreateMap<EsiV2CharactersMedalsGraphics, V2CharactersMedalsGraphics>();
            CreateMap<EsiV2CharactersFatigue, V2CharactersFatigue>();
            CreateMap<EsiV2CharactersCorporationHistory, V2CharactersCorporationHistory>();
            CreateMap<EsiV3CharactersBlueprints, V3CharactersBlueprints>();
            CreateMap<EsiV2CharactersResearchAgents, V2CharactersResearchAgents>();
            CreateMap<EsiV5CharactersPublicInfo, V5CharactersPublicInfo>();
        }
    }
}
