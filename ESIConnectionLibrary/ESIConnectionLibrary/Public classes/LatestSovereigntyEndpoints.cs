using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public class LatestSovereigntyEndpoints : ILatestSovereigntyEndpoints
    {
        private readonly IInternalLatestSovereignty _internalLatestSovereignty;

        public LatestSovereigntyEndpoints(string userAgent)
        {
            _internalLatestSovereignty = new InternalLatestSovereignty(null, userAgent);
        }

        public IList<V1SovereigntyCampaigns> GetCampaigns()
        {
            return _internalLatestSovereignty.GetCampaigns();
        }

        public async Task<IList<V1SovereigntyCampaigns>> GetCampaignsAsync()
        {
            return await _internalLatestSovereignty.GetCampaignsAsync();
        }

        public IList<V1SovereigntyMap> GetMap()
        {
            return _internalLatestSovereignty.GetMap();
        }

        public async Task<IList<V1SovereigntyMap>> GetMapAsync()
        {
            return await _internalLatestSovereignty.GetMapAsync();
        }

        public IList<V1SovereigntyStructures> GetStructures()
        {
            return _internalLatestSovereignty.GetStructures();
        }

        public async Task<IList<V1SovereigntyStructures>> GetStructuresAsync()
        {
            return await _internalLatestSovereignty.GetStructuresAsync();
        }
    }
}
