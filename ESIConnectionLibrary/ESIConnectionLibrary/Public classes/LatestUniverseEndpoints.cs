using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public class LatestUniverseEndpoints : ILatestUniverseEndpoints
    {
        private readonly IInternalLatestUniverse _internalLatestUniverse;

        public LatestUniverseEndpoints(string userAgent)
        {
            _internalLatestUniverse = new InternalLatestUniverse(null, userAgent);
        }

        public IList<V2UniverseNames> GetNames(IList<int> ids)
        {
            return _internalLatestUniverse.GetNames(ids);
        }

        public async Task<IList<V2UniverseNames>> GetNamesAsync(IList<int> ids)
        {
            return await _internalLatestUniverse.GetNamesAsync(ids);
        }

        public V3UniverseType GetType(int id)
        {
            return _internalLatestUniverse.GetType(id);
        }

        public async Task<V3UniverseType> GetTypeAsync(int id)
        {
            return await _internalLatestUniverse.GetTypeAsync(id);
        }
    }
}
