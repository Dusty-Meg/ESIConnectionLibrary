using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public interface ILatestCorporationsEndpoints
    {
        IList<V1CorporationsRoles> GetCorporationsRoles(SsoToken token, long corporationId);
        Task<IList<V1CorporationsRoles>> GetCorporationsRolesAsync(SsoToken token, long corporationId);
    }
}