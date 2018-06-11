using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public interface ILatestContactEndpoints
    {
        PagedModel<V2ContactsGetContacts> GetCharactersContacts(SsoToken token, int page);
        Task<PagedModel<V2ContactsGetContacts>> GetCharactersContactsAsync(SsoToken token, int page);
    }
}