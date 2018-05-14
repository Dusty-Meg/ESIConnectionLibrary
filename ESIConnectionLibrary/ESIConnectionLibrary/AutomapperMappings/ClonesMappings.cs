using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.AutomapperMappings
{
    internal class ClonesMappings : Profile
    {
        public ClonesMappings()
        {
            CreateMap<EsiV3CharactersClones, V3CharactersClones>();
            CreateMap<EsiV3CharactersClonesJumpClone, V3CharactersClonesJumpClone>();
            CreateMap<EsiV3CharactersClonesHomeLocation, V3CharactersClonesHomeLocation>();
        }
    }
}