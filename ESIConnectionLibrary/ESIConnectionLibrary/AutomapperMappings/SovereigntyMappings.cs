using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.AutomapperMappings
{
    internal class SovereigntyMappings : Profile
    {
        public SovereigntyMappings()
        {
            CreateMap<EsiV1SovereigntyCampaigns, V1SovereigntyCampaigns>();
            CreateMap<EsiV1SovereigntyCampaignsParticipants, V1SovereigntyCampaignsParticipants>();
            CreateMap<EsiV1SovereigntyMap, V1SovereigntyMap>();
            CreateMap<EsiV1SovereigntyStructures, V1SovereigntyStructures>();
        }
    }
}
