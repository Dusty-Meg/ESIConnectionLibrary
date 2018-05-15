using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.AutomapperMappings
{
    internal class WarsMappings : Profile
    {
        public WarsMappings()
        {
            CreateMap<EsiV1WarsWarKillmails, V1WarsWarKillmails>();
            CreateMap<EsiV1WarsIndividualWar, V1WarsIndividualWar>();
            CreateMap<EsiV1WarsIndividualWarAggressor, V1WarsIndividualWarAggressor>();
            CreateMap<EsiV1WarsIndividualWarAllies, V1WarsIndividualWarAllies>();
            CreateMap<EsiV1WarsIndividualWarDefender, V1WarsIndividualWarDefender>();
        }
    }
}
