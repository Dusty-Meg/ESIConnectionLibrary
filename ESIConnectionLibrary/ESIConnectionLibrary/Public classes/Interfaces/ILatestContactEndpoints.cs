using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public interface ILatestContactEndpoints
    {
        PagedModel<V1ContactsGetContacts> GetCharactersContacts(SsoToken token, int characterId, int page);
        Task<PagedModel<V1ContactsGetContacts>> GetCharactersContactsAsync(SsoToken token, int characterId, int page);
    }
}