using System.Threading.Tasks;
using ESIConnectionLibrary.Exceptions;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public class LatestContactEndpoints : ILatestContactEndpoints
    {
        private readonly IInternalLatestContacts _internalLatestContacts;

        public LatestContactEndpoints(string userAgent, bool testing = false)
        {
            _internalLatestContacts = new InternalLatestContacts(null, userAgent, testing);
        }

        public PagedModel<V2ContactsGetContacts> GetCharactersContacts(SsoToken token, int page)
        {
            if (page < 1)
            {
                throw new ESIException("Pages below 1 is not allowed!");
            }

            return _internalLatestContacts.GetCharactersContacts(token, page);
        }

        public async Task<PagedModel<V2ContactsGetContacts>> GetCharactersContactsAsync(SsoToken token, int page)
        {
            if (page < 1)
            {
                throw new ESIException("Pages below 1 is not allowed!");
            }

            return await _internalLatestContacts.GetCharactersContactsAsync(token, page);
        }
    }
}
