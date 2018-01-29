using System.Collections.Generic;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public interface ILatestUniverseEndpoints
    {
        IList<V2UniverseNames> GetNames(IList<int> ids);
        V3UniverseGetType GetType(long id);
    }
}