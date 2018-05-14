using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Internal_classes
{
    internal interface IInternalLatestMail
    {
        PagedModel<V1MailGetCharactersMail> GetCharactersMail(SsoToken token, int lastMailId);
        Task<PagedModel<V1MailGetCharactersMail>> GetCharactersMailAsync(SsoToken token, int lastMailId);
        V1MailGetMail GetMail(SsoToken token, int mailId);
        Task<V1MailGetMail> GetMailAsync(SsoToken token, int mailId);
    }
}