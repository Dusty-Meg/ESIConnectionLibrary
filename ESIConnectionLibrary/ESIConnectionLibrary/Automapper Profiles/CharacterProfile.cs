using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Automapper_Profiles
{
    internal class CharacterProfile : Profile
    {
        public CharacterProfile()
        {
            CreateMap<EsiV1CharacterAffiliations, V1CharacterAffiliations>();
            CreateMap<EsiV2CharacterTitles, V2CharacterTitles>();
            CreateMap<EsiV2CharactersStandings, V2CharactersStandings>();
            CreateMap<EsiV3CharacterRoles, V3CharacterRoles>();
            CreateMap<EsiV2CharactersPortrait, V2CharactersPortrait>();
            CreateMap<EsiV1CharactersNotificationsContacts, V1CharactersNotificationsContacts>();
            CreateMap<EsiV4CharactersNotifications, V5CharactersNotifications>();
            CreateMap<EsiV1CharactersMedals, V1CharactersMedals>();
            CreateMap<EsiV1CharactersMedalsGraphics, V1CharactersMedalsGraphics>();
            CreateMap<EsiV1CharactersFatigue, V1CharactersFatigue>();
            CreateMap<EsiV2CharactersCorporationHistory, V2CharactersCorporationHistory>();
            CreateMap<EsiV2CharactersBlueprints, V2CharactersBlueprints>();
            CreateMap<EsiV1CharactersResearchAgents, V1CharactersResearchAgents>();
            CreateMap<EsiV4CharactersPublicInfo, V4CharactersPublicInfo>();
        }
    }
}
