using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Automapper_Profiles
{
    internal class WarsProfile : Profile
    {
        public WarsProfile()
        {
            CreateMap<EsiV1WarsWar, V1WarsWar>();
            CreateMap<EsiV1WarsWarAggressor, V1WarsWarAggressor>();
            CreateMap<EsiV1WarsWarAllies, V1WarsWarAllies>();
            CreateMap<EsiV1WarsWarDefender, V1WarsWarDefender>();
            CreateMap<EsiV1WarsKillmail, V1WarsKillmail>();
        }
    }
}
