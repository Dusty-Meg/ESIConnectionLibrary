using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Internal_classes
{
    internal interface IInternalLatestContacts
    {
        PagedModel<V1ContactsGetContacts> GetCharactersContacts(SsoToken token, int page);
        Task<PagedModel<V1ContactsGetContacts>> GetCharactersContactsAsync(SsoToken token, int page);
    }
}