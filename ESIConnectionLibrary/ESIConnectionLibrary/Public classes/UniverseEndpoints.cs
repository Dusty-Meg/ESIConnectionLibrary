using System.Collections.Generic;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public class UniverseEndpoints : IUniverseEndpoints
    {
        private readonly IInternalUniverse _internalUniverse;

        public UniverseEndpoints(string userAgent)
        {
            _internalUniverse = new InternalUniverse(null, userAgent);
        }

        public IList<UniverseNames> GetNames(IList<int> ids)
        {
            return _internalUniverse.GetNames(ids);
        }

        public UniverseGetType GetType(long id)
        {
            return _internalUniverse.GetType(id);
        }
    }
}
