using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Automapper_Profiles
{
    internal class AllianceProfile : Profile
    {
        public AllianceProfile()
        {
            CreateMap<EsiV3AlliancePublicInfo, V3AlliancePublicInfo>();
            CreateMap<EsiV1AllianceIcons, V1AllianceIcons>();
        }
    }
}
