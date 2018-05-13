using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public interface ILatestMailEndpoints
    {
        PagedModel<V1MailGetCharactersMail> GetCharactersMail(SsoToken token, int characterId, int lastMailId);
        Task<PagedModel<V1MailGetCharactersMail>> GetCharactersMailAsync(SsoToken token, int characterId, int lastMailId);
        V1MailGetMail GetMail(SsoToken token, int characterId, int mailId);
        Task<V1MailGetMail> GetMailAsync(SsoToken token, int characterId, int mailId);
    }
}