using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public class LatestMailEndpoints : ILatestMailEndpoints
    {
        private readonly IInternalLatestMail _internalLatestMail;

        public LatestMailEndpoints(string userAgent, bool testing = false)
        {
            _internalLatestMail = new InternalLatestMail(null, userAgent, testing);
        }

        public PagedModel<V1MailCharacter> Character(SsoToken token, int lastMailId)
        {
            return _internalLatestMail.Character(token, lastMailId);
        }

        public async Task<PagedModel<V1MailCharacter>> CharacterAsync(SsoToken token, int lastMailId)
        {
            return await _internalLatestMail.CharacterAsync(token, lastMailId);
        }

        public void Send(SsoToken token, V1MailSend mail)
        {
            _internalLatestMail.Send(token, mail);
        }

        public async Task SendAsync(SsoToken token, V1MailSend mail)
        {
            await _internalLatestMail.SendAsync(token, mail);
        }

        public void Delete(SsoToken token, int mailId)
        {
            _internalLatestMail.Delete(token, mailId);
        }

        public async Task DeleteAsync(SsoToken token, int mailId)
        {
            await _internalLatestMail.DeleteAsync(token, mailId);
        }

        public V1MailMail Mail(SsoToken token, int mailId)
        {
            return _internalLatestMail.Mail(token, mailId);
        }

        public async Task<V1MailMail> MailAsync(SsoToken token, int mailId)
        {
            return await _internalLatestMail.MailAsync(token, mailId);
        }

        public void Metadata(SsoToken token, int mailId, V1MailMetadata metadata)
        {
            _internalLatestMail.Metadata(token, mailId, metadata);
        }

        public async Task MetadataAsync(SsoToken token, int mailId, V1MailMetadata metadata)
        {
            await _internalLatestMail.MetadataAsync(token, mailId, metadata);
        }

        public V3MailLabelsAndUnreadCount LabelsAndUnreadCount(SsoToken token)
        {
            return _internalLatestMail.LabelsAndUnreadCount(token);
        }

        public async Task<V3MailLabelsAndUnreadCount> LabelsAndUnreadCountAsync(SsoToken token)
        {
            return await _internalLatestMail.LabelsAndUnreadCountAsync(token);
        }

        public void CreateLabel(SsoToken token, V2MailCreateLabel labelModel)
        {
            _internalLatestMail.CreateLabel(token, labelModel);
        }

        public async Task CreateLabelAsync(SsoToken token, V2MailCreateLabel labelModel)
        {
            await _internalLatestMail.CreateLabelAsync(token, labelModel);
        }

        public void DeleteLabel(SsoToken token, int labelId)
        {
            _internalLatestMail.DeleteLabel(token, labelId);
        }

        public async Task DeleteLabelAsync(SsoToken token, int labelId)
        {
            await _internalLatestMail.DeleteLabelAsync(token, labelId);
        }

        public IList<V1MailMailingList> MailingLists(SsoToken token)
        {
            return _internalLatestMail.MailingLists(token);
        }

        public async Task<IList<V1MailMailingList>> MailingListsAsync(SsoToken token)
        {
            return await _internalLatestMail.MailingListsAsync(token);
        }
    }
}
