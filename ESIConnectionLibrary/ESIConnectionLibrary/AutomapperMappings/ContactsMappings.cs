using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.AutomapperMappings
{
    internal class ContactsMappings : Profile
    {
        public ContactsMappings()
        {
            CreateMap<EsiV2ContactAlliance, V2ContactAlliance>();
            CreateMap<EsiV1ContactAllianceLabel, V1ContactAllianceLabel>();
            CreateMap<EsiV2ContactCharacter, V2ContactCharacter>();
            CreateMap<EsiV1ContactCharacterLabel, V1ContactCharacterLabel>();
            CreateMap<EsiV2ContactCorporation, V2ContactCorporation>();
            CreateMap<EsiV1ContactCorporationLabel, V1ContactCorporationLabel>();
        }
    }
}
