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

        public PagedModel<V1MailGetCharactersMail> GetCharactersMail(SsoToken token, int lastMailId)
        {
            return _internalLatestMail.GetCharactersMail(token, lastMailId);
        }

        public async Task<PagedModel<V1MailGetCharactersMail>> GetCharactersMailAsync(SsoToken token, int lastMailId)
        {
            return await _internalLatestMail.GetCharactersMailAsync(token, lastMailId);
        }

        public V1MailGetMail GetMail(SsoToken token, int mailId)
        {
            return _internalLatestMail.GetMail(token, mailId);
        }

        public async Task<V1MailGetMail> GetMailAsync(SsoToken token, int mailId)
        {
            return await _internalLatestMail.GetMailAsync(token, mailId);
        }
    }
}
