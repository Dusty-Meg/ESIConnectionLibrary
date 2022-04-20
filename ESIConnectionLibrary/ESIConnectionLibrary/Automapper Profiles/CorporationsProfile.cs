using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Automapper_Profiles
{
    internal class CorporationsProfile : Profile
    {
        public CorporationsProfile()
        {
            CreateMap<EsiV1CorporationTitles, V1CorporationTitles>();
            CreateMap<EsiV4CorporationStructures, V4CorporationStructures>();
            CreateMap<EsiV2CorporationStarbase, V2CorporationStarbase>();
            CreateMap<EsiV2CorporationStarbases, V2CorporationStarbases>();
            CreateMap<EsiV1CorporationStandings, V1CorporationStandings>();
            CreateMap<EsiV1CorporationShareholders, V1CorporationShareholders>();
            CreateMap<EsiV1CorporationRolesHistory, V1CorporationRolesHistory>();
            CreateMap<EsiV1CorporationRoles, V1CorporationRoles>();
            CreateMap<EsiV2CorporationMemberTracking, V2CorporationMemberTracking>();
            CreateMap<EsiV1CorporationMembersTitles, V1CorporationMembersTitles>();
            CreateMap<EsiV2CorporationMedalsIssued, V2CorporationMedalsIssued>();
            CreateMap<EsiV2CorporationMedals, V2CorporationMedals>();
            CreateMap<EsiV1CorporationIcons, V1CorporationIcons>();
            CreateMap<EsiV1CorporationFacilities, V1CorporationFacilities>();
            CreateMap<EsiV2CorporationDivisions, V2CorporationDivisions>();
            CreateMap<EsiV2CorporationDivisionsHangar, V2CorporationDivisionsHangar>();
            CreateMap<EsiV2CorporationDivisionsWallet, V2CorporationDivisionsWallet>();
            CreateMap<EsiV3CorporationContainerLogs, V3CorporationContainerLogs>();
            CreateMap<EsiV2CorporationBlueprints, V2CorporationBlueprints>();
            CreateMap<EsiV2CorporationAllianceHistory, V2CorporationAllianceHistory>();
            CreateMap<EsiV4CorporationPublicInfo, V4CorporationPublicInfo>();
        }
    }
}
