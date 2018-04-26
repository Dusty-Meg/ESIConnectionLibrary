using System.Threading.Tasks;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public class LatestContactEndpoints : ILatestContactEndpoints
    {
        private readonly IInternalLatestContacts _internalLatestContacts;

        public LatestContactEndpoints(string userAgent)
        {
            _internalLatestContacts = new InternalLatestContacts(null, userAgent);
        }

        public PagedModel<V1ContactsGetContacts> GetCharactersContacts(SsoToken token, int characterId, int page)
        {
            return _internalLatestContacts.GetCharactersContacts(token, characterId, page);
        }

        public async Task<PagedModel<V1ContactsGetContacts>> GetCharactersContactsAsync(SsoToken token, int characterId, int page)
        {
            return await _internalLatestContacts.GetCharactersContactsAsync(token, characterId, page);
        }
    }
}
