using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public class CorporationsEndpoints : ICorporationsEndpoints
    {
        private readonly IInternalCorporations _internalCorporations;

        public CorporationsEndpoints(string userAgent)
        {
            _internalCorporations = new InternalCorporations(null, userAgent);
        }

        public IList<CorporationsRoles> GetCorporationsRoles(SsoToken token, long corporationId)
        {
            return _internalCorporations.GetCorporationRoles(token, corporationId);
        }
    }
}
