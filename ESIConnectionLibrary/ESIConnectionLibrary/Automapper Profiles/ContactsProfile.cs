using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Automapper_Profiles
{
    internal class ContactsProfile : Profile
    {
        public ContactsProfile()
        {
            CreateMap<EsiV2ContactAlliance, V2ContactAlliance>();
            CreateMap<EsiV1ContactCorporationLabel, V1ContactCorporationLabel>();
            CreateMap<EsiV2ContactCorporation, V2ContactCorporation>();
            CreateMap<EsiV1ContactCharacterLabel, V1ContactCharacterLabel>();
            CreateMap<EsiV2ContactCharacter, V2ContactCharacter>();
            CreateMap<EsiV1ContactAllianceLabel, V1ContactAllianceLabel>();
        }
    }
}
