using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Automapper_Profiles
{
    internal class OpportunitiesProfile : Profile
    {
        public OpportunitiesProfile()
        {
            CreateMap<EsiV1OpportunitiesCharacter, V1OpportunitiesCharacter>();
            CreateMap<EsiV1OpportunitiesGroup, V1OpportunitiesGroup>();
            CreateMap<EsiV1OpportunitiesTask, V1OpportunitiesTask>();
        }
    }
}
