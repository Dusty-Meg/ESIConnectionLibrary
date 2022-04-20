using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Automapper_Profiles
{
    internal class CorporationsProfile : Profile
    {
        public CorporationsProfile()
        {
            CreateMap<EsiV2CorporationTitles, V2CorporationTitles>();
            CreateMap<EsiV4CorporationStructures, V4CorporationStructures>();
            CreateMap<EsiV2CorporationStarbase, V2CorporationStarbase>();
            CreateMap<EsiV2CorporationStarbases, V2CorporationStarbases>();
            CreateMap<EsiV2CorporationStandings, V2CorporationStandings>();
            CreateMap<EsiV1CorporationShareholders, V1CorporationShareholders>();
            CreateMap<EsiV2CorporationRolesHistory, V2CorporationRolesHistory>();
            CreateMap<EsiV2CorporationRoles, V2CorporationRoles>();
            CreateMap<EsiV2CorporationMemberTracking, V2CorporationMemberTracking>();
            CreateMap<EsiV2CorporationMembersTitles, V2CorporationMembersTitles>();
            CreateMap<EsiV2CorporationMedalsIssued, V2CorporationMedalsIssued>();
            CreateMap<EsiV2CorporationMedals, V2CorporationMedals>();
            CreateMap<EsiV2CorporationIcons, V2CorporationIcons>();
            CreateMap<EsiV2CorporationFacilities, V2CorporationFacilities>();
            CreateMap<EsiV2CorporationDivisions, V2CorporationDivisions>();
            CreateMap<EsiV2CorporationDivisionsHangar, V2CorporationDivisionsHangar>();
            CreateMap<EsiV2CorporationDivisionsWallet, V2CorporationDivisionsWallet>();
            CreateMap<EsiV3CorporationContainerLogs, V3CorporationContainerLogs>();
            CreateMap<EsiV3CorporationBlueprints, V3CorporationBlueprints>();
            CreateMap<EsiV3CorporationAllianceHistory, V3CorporationAllianceHistory>();
            CreateMap<EsiV5CorporationPublicInfo, V5CorporationPublicInfo>();
        }
    }
}
