using AutoMapper;
using ESIConnectionLibrary.ESIModels;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Automapper_Profiles
{
    internal class MailProfile : Profile
    {
        public MailProfile()
        {
            CreateMap<EsiV1MailCharacter, V1MailCharacter>();
            CreateMap<EsiMailRecipients, MailRecipients>();
            CreateMap<EsiV1MailSend, V1MailSend>();
            CreateMap<EsiV1MailMail, V1MailMail>();
            CreateMap<EsiV1MailMetadata, V1MailMetadata>();
            CreateMap<EsiV3MailLabelsAndUnreadCount, V3MailLabelsAndUnreadCount>();
            CreateMap<EsiV3MailLabelsAndUnreadCountLabels, V3MailLabelsAndUnreadCountLabels>();
            CreateMap<EsiV2MailCreateLabel, V2MailCreateLabel>();
            CreateMap<EsiV1MailMailingList, V1MailMailingList>();
        }
    }
}
