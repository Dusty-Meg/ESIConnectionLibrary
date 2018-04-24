using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.AutomapperMappings
{
    internal class MarketMappings : Profile
    {
        public MarketMappings()
        {
            CreateMap<EsiV1MarketGroupInformation, V1MarketGroupInformation>();
        }
    }
}
