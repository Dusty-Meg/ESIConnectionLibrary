using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public class LatestCorporationsEndpoints : ILatestCorporationsEndpoints
    {
        private readonly IInternalLatestCorporations _internalLatestCorporations;

        public LatestCorporationsEndpoints(string userAgent)
        {
            _internalLatestCorporations = new InternalLatestCorporations(null, userAgent);
        }

        public IList<V1CorporationsRoles> GetCorporationsRoles(SsoToken token, long corporationId)
        {
            return _internalLatestCorporations.GetCorporationRoles(token, corporationId);
        }

        public async Task<IList<V1CorporationsRoles>> GetCorporationsRolesAsync(SsoToken token, long corporationId)
        {
            return await _internalLatestCorporations.GetCorporationRolesAsync(token, corporationId);
        }

        public IList<V1CorporationMemberTitle> GetCorporationMemberTitles(SsoToken token, long corporationId)
        {
            return _internalLatestCorporations.GetCorporationMemberTitles(token, corporationId);
        }

        public async Task<IList<V1CorporationMemberTitle>> GetCorporationMemberTitlesAsync(SsoToken token, long corporationId)
        {
            return await _internalLatestCorporations.GetCorporationMemberTitlesAsync(token, corporationId);
        }

        public IList<V1CorporationTitles> GetCorporationTitles(SsoToken token, long corporationId)
        {
            return _internalLatestCorporations.GetCorporationTitles(token, corporationId);
        }

        public async Task<IList<V1CorporationTitles>> GetCorporationTitlesAsync(SsoToken token, long corporationId)
        {
            return await _internalLatestCorporations.GetCorporationTitlesAsync(token, corporationId);
        }
    }
}
