using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public class LatestCloneEndpoints : ILatestCloneEndpoints
    {
        private readonly IInternalLatestClones _internalLatestClones;

        public LatestCloneEndpoints(string userAgent, bool testing = false)
        {
            _internalLatestClones = new InternalLatestClones(null, userAgent, testing);
        }

        internal LatestCloneEndpoints(string userAgent, IWebClient webClient, bool testing = false)
        {
            _internalLatestClones = new InternalLatestClones(webClient, userAgent, testing);
        }

        public V3ClonesClone Clones(SsoToken token)
        {
            return _internalLatestClones.Clones(token);
        }

        public async Task<V3ClonesClone> ClonesAsync(SsoToken token)
        {
            return await _internalLatestClones.ClonesAsync(token);
        }

        public IList<int> ActiveImplants(SsoToken token)
        {
            return _internalLatestClones.ActiveImplants(token);
        }

        public async Task<IList<int>> ActiveImplantsAsync(SsoToken token)
        {
            return await _internalLatestClones.ActiveImplantsAsync(token);
        }
    }
}
