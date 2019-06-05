using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Automapper_Profiles
{
    internal class StatusProfile : Profile
    {
        public StatusProfile()
        {
            CreateMap<EsiV1Status, V1Status>();
        }
    }
}
