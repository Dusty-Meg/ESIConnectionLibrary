using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.AutomapperMappings
{
    internal class GeneralMappings : Profile
    {
        public GeneralMappings()
        {
            CreateMap<EsiLocationFlagCharacter, LocationFlagCharacter>();
            CreateMap<EsiLocationFlagCorporation, LocationFlagCorporation>();
            CreateMap<EsiLocationType, LocationType>();
            CreateMap<EsiPosition, Position>();
        }
    }
}