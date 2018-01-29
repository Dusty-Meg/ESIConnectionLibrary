using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.AutomapperMappings
{
    internal class GetFleetMappings : Profile
    {
        public GetFleetMappings()
        {
            CreateMap<EsiGetFleet, GetFleet>();
        }
    }
}
