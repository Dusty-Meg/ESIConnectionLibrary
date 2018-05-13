using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.AutomapperMappings
{
    internal class MailMappings : Profile
    {
        public MailMappings()
        {
            CreateMap<EsiV1MailGetCharactersMail, V1MailGetCharactersMail>();
            CreateMap<EsiV1MailGetCharactersMailRecipients, EsiV1MailGetCharactersMailRecipients>();
            CreateMap<EsiV1MailGetMail, V1MailGetMail>();
        }
    }
}
