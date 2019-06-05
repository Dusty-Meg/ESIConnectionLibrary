using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Automapper_Profiles
{
    internal class FittingsProfile : Profile
    {
        public FittingsProfile()
        {
            CreateMap<EsiV2FittingsCharacter, V2FittingsCharacter>();
            CreateMap<EsiV2FittingsCharacterItem, V2FittingsCharacterItem>();
        }
    }
}
