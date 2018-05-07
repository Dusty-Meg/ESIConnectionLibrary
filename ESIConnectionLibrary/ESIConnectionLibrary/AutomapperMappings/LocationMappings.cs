using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.AutomapperMappings
{
    internal class LocationMappings : Profile
    {
        public LocationMappings()
        {
            CreateMap<EsiV1LocationCharacterLocation, V1LocationCharacterLocation>();
            CreateMap<EsiV2LocationCharacterOnline, V2LocationCharacterOnline>();
            CreateMap<EsiV1LocationCharacterShip, V1LocationCharacterShip>();
        }
    }
}
