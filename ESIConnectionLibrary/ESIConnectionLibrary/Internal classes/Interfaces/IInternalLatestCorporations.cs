using System.Collections.Generic;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Internal_classes
{
    internal interface IInternalLatestCorporations
    {
        IList<V1CorporationsRoles> GetCorporationRoles(SsoToken token, long corporationId);
    }
}