using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}
