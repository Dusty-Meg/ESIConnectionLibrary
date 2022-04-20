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
            CreateMap<EsiV1CharacterTitles, V1CharacterTitles>();
            CreateMap<EsiV2CharactersStandings, V2CharactersStandings>();
            CreateMap<EsiV2CharacterRoles, V2CharacterRoles>();
            CreateMap<EsiV2CharactersPortrait, V2CharactersPortrait>();
            CreateMap<EsiV1CharactersNotificationsContacts, V1CharactersNotificationsContacts>();
            CreateMap<EsiV4CharactersNotifications, V5CharactersNotifications>();
            CreateMap<EsiV1CharactersMedals, V1CharactersMedals>();
            CreateMap<EsiV1CharactersMedalsGraphics, V1CharactersMedalsGraphics>();
            CreateMap<EsiV1CharactersFatigue, V1CharactersFatigue>();
            CreateMap<EsiV1CharactersCorporationHistory, V1CharactersCorporationHistory>();
            CreateMap<EsiV2CharactersBlueprints, V2CharactersBlueprints>();
            CreateMap<EsiV1CharactersResearchAgents, V1CharactersResearchAgents>();
            CreateMap<EsiV4CharactersPublicInfo, V4CharactersPublicInfo>();
        }
    }
}
