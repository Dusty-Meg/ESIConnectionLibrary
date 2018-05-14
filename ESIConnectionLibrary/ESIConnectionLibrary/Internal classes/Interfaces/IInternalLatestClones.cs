using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Internal_classes
{
    internal interface IInternalLatestClones
    {
        IList<int> GetCharactersActiveImplants(SsoToken token);
        Task<IList<int>> GetCharactersActiveImplantsAsync(SsoToken token);
        V3CharactersClones GetCharactersClones(SsoToken token);
        Task<V3CharactersClones> GetCharactersClonesAsync(SsoToken token);
    }
}