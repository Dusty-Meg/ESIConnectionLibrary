using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Automapper_Profiles
{
    internal class LocationProfile : Profile
    {
        public LocationProfile()
        {
            CreateMap<EsiV1LocationLocation, V1LocationLocation>();
            CreateMap<EsiV2LocationOnline, V2LocationOnline>();
            CreateMap<EsiV1LocationShip, V1LocationShip>();
        }
    }
}
