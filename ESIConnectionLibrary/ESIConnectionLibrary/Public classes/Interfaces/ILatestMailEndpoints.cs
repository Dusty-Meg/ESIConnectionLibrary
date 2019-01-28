using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public interface ILatestMailEndpoints
    {
        PagedModel<V1MailCharacter> Character(SsoToken token, int lastMailId);
        Task<PagedModel<V1MailCharacter>> CharacterAsync(SsoToken token, int lastMailId);
        void Send(SsoToken token, V1MailSend mail);
        Task SendAsync(SsoToken token, V1MailSend mail);
        void Delete(SsoToken token, int mailId);
        Task DeleteAsync(SsoToken token, int mailId);
        V1MailMail Mail(SsoToken token, int mailId);
        Task<V1MailMail> MailAsync(SsoToken token, int mailId);
        void Metadata(SsoToken token, int mailId, V1MailMetadata metadata);
        Task MetadataAsync(SsoToken token, int mailId, V1MailMetadata metadata);
        V3MailLabelsAndUnreadCount LabelsAndUnreadCount(SsoToken token);
        Task<V3MailLabelsAndUnreadCount> LabelsAndUnreadCountAsync(SsoToken token);
        void CreateLabel(SsoToken token, V2MailCreateLabel labelModel);
        Task CreateLabelAsync(SsoToken token, V2MailCreateLabel labelModel);
        void DeleteLabel(SsoToken token, int labelId);
        Task DeleteLabelAsync(SsoToken token, int labelId);
        IList<V1MailMailingList> MailingLists(SsoToken token);
        Task<IList<V1MailMailingList>> MailingListsAsync(SsoToken token);
    }
}