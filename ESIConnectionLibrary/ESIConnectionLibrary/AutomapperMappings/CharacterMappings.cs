using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.AutomapperMappings
{
    internal class CharacterMappings : Profile
    {
        public CharacterMappings()
        {
            CreateMap<EsiV1CharacterAffiliations, V1CharacterAffiliations>();
            CreateMap<EsiV1CharactersAssetsNames, V1CharactersAssetsNames>();
            CreateMap<EsiV1CharactersCorporationHistory, V1CharactersCorporationHistory>();
            CreateMap<EsiV1CharactersFatigue, V1CharactersFatigue>();
            CreateMap<EsiV1CharactersMedals, V1CharactersMedals>();
            CreateMap<EsiV1CharactersMedalsGraphics, V1CharactersMedalsGraphics>();
            CreateMap<EsiV1CharactersNames, V1CharactersNames>();
            CreateMap<EsiV2CharactersNotifications, V2CharactersNotifications>();
            CreateMap<EsiV1CharactersNotificationsContacts, V1CharactersNotificationsContacts>();
            CreateMap<EsiV1CharactersResearchAgents, V1CharactersResearchAgents>();
            CreateMap<EsiV1CharacterTitles, V1CharacterTitles>();
            CreateMap<EsiV2CharacterRoles, V2CharacterRoles>();
            CreateMap<EsiV2CharactersBlueprints, V2CharactersBlueprints>();
            CreateMap<EsiV2CharactersPortrait, V2CharactersPortrait>();
            CreateMap<EsiV2CharactersStandings, V2CharactersStandings>();
            CreateMap<EsiV2CharactersStats, V2CharactersStats>();
            CreateMap<EsiV2CharactersStatsCharacter, V2CharactersStatsCharacter>();
            CreateMap<EsiV2CharactersStatsCombat, V2CharactersStatsCombat>();
            CreateMap<EsiV2CharactersStatsIndustry, V2CharactersStatsIndustry>();
            CreateMap<EsiV2CharactersStatsInventory, V2CharactersStatsInventory>();
            CreateMap<EsiV2CharactersStatsIsk, V2CharactersStatsIsk>();
            CreateMap<EsiV2CharactersStatsMarket, V2CharactersStatsMarket>();
            CreateMap<EsiV2CharactersStatsMining, V2CharactersStatsMining>();
            CreateMap<EsiV2CharactersStatsModule, V2CharactersStatsModule>();
            CreateMap<EsiV2CharactersStatsOrbital, V2CharactersStatsOrbital>();
            CreateMap<EsiV2CharactersStatsPve, V2CharactersStatsPve>();
            CreateMap<EsiV2CharactersStatsSocial, V2CharactersStatsSocial>();
            CreateMap<EsiV2CharactersStatsTravel, V2CharactersStatsTravel>();
            CreateMap<EsiV4CharactersPublicInfo, V4CharactersPublicInfo>();
        }
    }
}
