using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Automapper_Profiles
{
    internal class ClonesProfile : Profile
    {
        public ClonesProfile()
        {
            CreateMap<EsiV3ClonesClone, V3ClonesClone>();
            CreateMap<EsiV3ClonesJumpClone, V3ClonesJumpClone>();
            CreateMap<EsiV3ClonesHomeLocation, V3ClonesHomeLocation>();
        }
    }
}
