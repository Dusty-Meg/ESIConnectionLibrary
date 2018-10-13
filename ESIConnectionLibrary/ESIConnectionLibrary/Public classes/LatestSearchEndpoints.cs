using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public class LatestSearchEndpoints : ILatestSearchEndpoints
    {
        private readonly IInternalLatestSearch _internalLatestSearch;

        public LatestSearchEndpoints(string userAgent, bool testing = false)
        {
            _internalLatestSearch = new InternalLatestSearch(null, userAgent, testing);
        }

        public V3SearchAuthSearch CharacterSearch(SsoToken token, IList<V3SearchAuthSearchCategories> categories, string search, bool strict)
        {
            return _internalLatestSearch.CharacterSearch(token, categories, search, strict);
        }

        public async Task<V3SearchAuthSearch> CharacterSearchAsync(SsoToken token, IList<V3SearchAuthSearchCategories> categories, string search, bool strict)
        {
            return await _internalLatestSearch.CharacterSearchAsync(token, categories, search, strict);
        }

        public V2SearchSearch Search(IList<V2SearchSearchCategories> categories, string search, bool strict)
        {
            return _internalLatestSearch.Search(categories, search, strict);
        }

        public async Task<V2SearchSearch> SearchAsync(IList<V2SearchSearchCategories> categories, string search, bool strict)
        {
            return await _internalLatestSearch.SearchAsync(categories, search, strict);
        }
    }
}
