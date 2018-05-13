using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Internal_classes
{
    internal interface IInternalLatestCorporations
    {
        IList<V1CorporationsRoles> GetCorporationRoles(SsoToken token, long corporationId);
        Task<IList<V1CorporationsRoles>> GetCorporationRolesAsync(SsoToken token, long corporationId);
        IList<V1CorporationMemberTitle> GetCorporationMemberTitles(SsoToken token, long corporationId);
        Task<IList<V1CorporationMemberTitle>> GetCorporationMemberTitlesAsync(SsoToken token, long corporationId);
        IList<V1CorporationTitles> GetCorporationTitles(SsoToken token, long corporationId);
        Task<IList<V1CorporationTitles>> GetCorporationTitlesAsync(SsoToken token, long corporationId);
    }
}