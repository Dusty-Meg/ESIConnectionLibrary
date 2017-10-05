using System.Collections.Generic;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Internal_classes
{
    internal interface IInternalUniverse
    {
        IList<UniverseNames> GetNames(IList<int> ids);
    }
}