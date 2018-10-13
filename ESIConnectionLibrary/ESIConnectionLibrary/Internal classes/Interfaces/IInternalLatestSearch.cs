using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Internal_classes
{
    internal interface IInternalLatestSearch
    {
        V3SearchAuthSearch CharacterSearch(SsoToken token, IList<V3SearchAuthSearchCategories> categories, string search, bool strict);
        Task<V3SearchAuthSearch> CharacterSearchAsync(SsoToken token, IList<V3SearchAuthSearchCategories> categories, string search, bool strict);
        V2SearchSearch Search(IList<V2SearchSearchCategories> categories, string search, bool strict);
        Task<V2SearchSearch> SearchAsync(IList<V2SearchSearchCategories> categories, string search, bool strict);
    }
}