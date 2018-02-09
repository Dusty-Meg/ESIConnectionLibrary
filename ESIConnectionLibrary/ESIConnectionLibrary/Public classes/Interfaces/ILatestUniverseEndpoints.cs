using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public interface ILatestUniverseEndpoints
    {
        IList<V2UniverseNames> GetNames(IList<int> ids);
        Task<IList<V2UniverseNames>> GetNamesAsync(IList<int> ids);
        V3UniverseGetType GetType(long id);
        Task<V3UniverseGetType> GetTypeAsync(long id);
    }
}