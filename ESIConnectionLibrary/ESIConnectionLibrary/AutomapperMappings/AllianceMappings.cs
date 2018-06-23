using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.AutomapperMappings
{
    internal class AllianceMappings : Profile
    {
        public AllianceMappings()
        {
            CreateMap<EsiV1AllianceIcons, V1AllianceIcons>();
            CreateMap<EsiV3GetPublicAlliance, V3GetPublicAlliance>();
        }
    }
}