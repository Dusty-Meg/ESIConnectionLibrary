using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Automapper_Profiles
{
    internal class SovereigntyProfile : Profile
    {
        public SovereigntyProfile()
        {
            CreateMap<EsiV1SovereigntyCampaigns, V1SovereigntyCampaigns>();
            CreateMap<EsiV1SovereigntyCampaignsParticipants, V1SovereigntyCampaignsParticipants>();
            CreateMap<EsiV1SovereigntyMap, V1SovereigntyMap>();
            CreateMap<EsiV1SovereigntyStructures, V1SovereigntyStructures>();
        }
    }
}
