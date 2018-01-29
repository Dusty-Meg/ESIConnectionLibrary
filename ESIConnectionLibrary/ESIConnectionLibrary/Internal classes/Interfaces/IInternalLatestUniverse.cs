using System.Collections.Generic;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Internal_classes
{
    internal interface IInternalLatestUniverse
    {
        IList<V2UniverseNames> GetNames(IList<int> ids);
        V3UniverseGetType GetType(long id);
    }
}