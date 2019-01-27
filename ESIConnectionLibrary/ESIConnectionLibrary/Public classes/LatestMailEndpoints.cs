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

        public V1MailMail Mail(SsoToken token, int mailId)
        {
            return _internalLatestMail.Mail(token, mailId);
        }

        public async Task<V1MailMail> MailAsync(SsoToken token, int mailId)
        {
            return await _internalLatestMail.MailAsync(token, mailId);
        }
    }
}
