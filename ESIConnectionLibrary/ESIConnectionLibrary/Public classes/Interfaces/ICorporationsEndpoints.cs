using System.Collections.Generic;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public interface ICorporationsEndpoints
    {
        IList<CorporationsRoles> GetCorporationsRoles(SsoToken token, long corporationId);
    }
}