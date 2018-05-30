using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.AutomapperMappings
{
    internal class StatusMappings : Profile
    {
        public StatusMappings()
        {
            CreateMap<EsiV1Status, V1Status>();
        }
    }
}
