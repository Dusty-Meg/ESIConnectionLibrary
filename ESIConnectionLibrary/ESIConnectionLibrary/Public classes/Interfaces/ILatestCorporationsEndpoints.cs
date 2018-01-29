using System.Collections.Generic;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public interface ILatestCorporationsEndpoints
    {
        IList<V1CorporationsRoles> GetCorporationsRoles(SsoToken token, long corporationId);
    }
}