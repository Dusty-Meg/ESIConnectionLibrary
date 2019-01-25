using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Internal_classes
{
    internal interface IInternalLatestClones
    {
        IList<int> ActiveImplants(SsoToken token);
        Task<IList<int>> ActiveImplantsAsync(SsoToken token);
        V3ClonesClone Clones(SsoToken token);
        Task<V3ClonesClone> ClonesAsync(SsoToken token);
    }
}