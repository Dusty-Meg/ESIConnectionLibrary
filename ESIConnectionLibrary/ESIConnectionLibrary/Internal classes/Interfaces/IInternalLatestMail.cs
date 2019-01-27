using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Internal_classes
{
    internal interface IInternalLatestMail
    {
        PagedModel<V1MailCharacter> Character(SsoToken token, int lastMailId);
        Task<PagedModel<V1MailCharacter>> CharacterAsync(SsoToken token, int lastMailId);
        V1MailMail Mail(SsoToken token, int mailId);
        Task<V1MailMail> MailAsync(SsoToken token, int mailId);
    }
}