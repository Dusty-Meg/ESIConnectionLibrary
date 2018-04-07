using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.AutomapperMappings
{
    internal class GeneralMappings : Profile
    {
        public GeneralMappings()
        {
            CreateMap<EsiCharacterRoles, CharacterRoles>();
            CreateMap<EsiChatAccessorType, ChatAccessorType>();
            CreateMap<EsiGender, Gender>();
            CreateMap<EsiLocationFlagCharacter, LocationFlagCharacter>();
            CreateMap<EsiLocationFlagCorporation, LocationFlagCorporation>();
            CreateMap<EsiLocationType, LocationType>();
            CreateMap<EsiMedalsStatus, MedalsStatus>();
            CreateMap<EsiNotificationType, NotificationType>();
            CreateMap<EsiPosition, Position>();
            CreateMap<EsiSenderType, SenderType>();
            CreateMap<EsiStandingFromType, StandingFromType>();
            
        }
    }
}