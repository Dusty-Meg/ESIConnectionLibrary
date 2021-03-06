﻿using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Automapper_Profiles
{
    internal class CorporationsProfile : Profile
    {
        public CorporationsProfile()
        {
            CreateMap<EsiV1CorporationTitles, V1CorporationTitles>();
            CreateMap<EsiV3CorporationStructures, V3CorporationStructures>();
            CreateMap<EsiV1CorporationStarbase, V1CorporationStarbase>();
            CreateMap<EsiV1CorporationStarbases, V1CorporationStarbases>();
            CreateMap<EsiV1CorporationStandings, V1CorporationStandings>();
            CreateMap<EsiV1CorporationShareholders, V1CorporationShareholders>();
            CreateMap<EsiV1CorporationRolesHistory, V1CorporationRolesHistory>();
            CreateMap<EsiV1CorporationRoles, V1CorporationRoles>();
            CreateMap<EsiV1CorporationMemberTracking, V1CorporationMemberTracking>();
            CreateMap<EsiV1CorporationMembersTitles, V1CorporationMembersTitles>();
            CreateMap<EsiV1CorporationMedalsIssued, V1CorporationMedalsIssued>();
            CreateMap<EsiV1CorporationMedals, V1CorporationMedals>();
            CreateMap<EsiV1CorporationIcons, V1CorporationIcons>();
            CreateMap<EsiV1CorporationFacilities, V1CorporationFacilities>();
            CreateMap<EsiV1CorporationDivisions, V1CorporationDivisions>();
            CreateMap<EsiV1CorporationDivisionsHangar, V1CorporationDivisionsHangar>();
            CreateMap<EsiV1CorporationDivisionsWallet, V1CorporationDivisionsWallet>();
            CreateMap<EsiV2CorporationContainerLogs, V2CorporationContainerLogs>();
            CreateMap<EsiV2CorporationBlueprints, V2CorporationBlueprints>();
            CreateMap<EsiV2CorporationAllianceHistory, V2CorporationAllianceHistory>();
            CreateMap<EsiV4CorporationPublicInfo, V4CorporationPublicInfo>();
        }
    }
}
