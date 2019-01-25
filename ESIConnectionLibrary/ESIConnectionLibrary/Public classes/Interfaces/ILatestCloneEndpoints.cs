using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public interface ILatestCloneEndpoints
    {
        IList<int> ActiveImplants(SsoToken token);
        Task<IList<int>> ActiveImplantsAsync(SsoToken token);
        V3ClonesClone Clones(SsoToken token);
        Task<V3ClonesClone> ClonesAsync(SsoToken token);
    }
}