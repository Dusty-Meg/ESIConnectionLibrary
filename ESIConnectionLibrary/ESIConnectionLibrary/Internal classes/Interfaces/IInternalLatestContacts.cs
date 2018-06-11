using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Internal_classes
{
    internal interface IInternalLatestContacts
    {
        PagedModel<V2ContactsGetContacts> GetCharactersContacts(SsoToken token, int page);
        Task<PagedModel<V2ContactsGetContacts>> GetCharactersContactsAsync(SsoToken token, int page);
    }
}