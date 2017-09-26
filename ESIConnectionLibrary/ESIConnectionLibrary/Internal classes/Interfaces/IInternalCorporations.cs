using System.Collections.Generic;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Internal_classes
{
    internal interface IInternalCorporations
    {
        IList<CorporationsRoles> GetCorporationRoles(SsoToken token, long corporationId);
    }
}