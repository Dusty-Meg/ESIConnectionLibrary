using System.Collections.Generic;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public interface IUniverseEndpoints
    {
        IList<UniverseNames> GetNames(IList<int> ids);
    }
}