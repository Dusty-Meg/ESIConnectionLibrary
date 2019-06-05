using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Automapper_Profiles
{
    internal class SearchProfile : Profile
    {
        public SearchProfile()
        {
            CreateMap<EsiV3SearchAuthSearch, V3SearchAuthSearch>();
            CreateMap<EsiV2SearchSearch, V2SearchSearch>();
        }
    }
}
