using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.AutomapperMappings
{
    internal class CorporationRolesMappings : Profile
    {
        public CorporationRolesMappings()
        {
            CreateMap<EsiV1CorporationsRoles, V1CorporationsRoles>();
            CreateMap<EsiV1CorporationTitles, V1CorporationTitles>();
            CreateMap<EsiV1CorporationMemberTitle, V1CorporationMemberTitle>();
        }
    }
}
