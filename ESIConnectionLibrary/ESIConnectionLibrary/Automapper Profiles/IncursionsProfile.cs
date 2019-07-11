using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Automapper_Profiles
{
    internal class IncursionsProfile : Profile
    {
        public IncursionsProfile()
        {
            CreateMap<EsiV1Incursion, V1Incursion>();
        }
    }
}
