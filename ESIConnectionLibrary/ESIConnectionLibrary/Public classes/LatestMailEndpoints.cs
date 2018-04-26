using System.Threading.Tasks;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public class LatestMailEndpoints : ILatestMailEndpoints
    {
        private readonly IInternalLatestMail _internalLatestMail;

        public LatestMailEndpoints(string userAgent)
        {
            _internalLatestMail = new InternalLatestMail(null, userAgent);
        }

        public PagedModel<V1MailGetCharactersMail> GetCharactersMail(SsoToken token, int characterId, int lastMailId)
        {
            return _internalLatestMail.GetCharactersMail(token, characterId, lastMailId);
        }

        public async Task<PagedModel<V1MailGetCharactersMail>> GetCharactersMailAsync(SsoToken token, int characterId, int lastMailId)
        {
            return await _internalLatestMail.GetCharactersMailAsync(token, characterId, lastMailId);
        }

        public V1MailGetMail GetMail(SsoToken token, int characterId, int mailId)
        {
            return _internalLatestMail.GetMail(token, characterId, mailId);
        }

        public async Task<V1MailGetMail> GetMailAsync(SsoToken token, int characterId, int mailId)
        {
            return await _internalLatestMail.GetMailAsync(token, characterId, mailId);
        }
    }
}
