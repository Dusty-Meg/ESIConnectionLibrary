using System.Collections.Generic;
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

        public V3UniverseGetType GetType(long id)
        {
            return _internalLatestUniverse.GetType(id);
        }
    }
}
