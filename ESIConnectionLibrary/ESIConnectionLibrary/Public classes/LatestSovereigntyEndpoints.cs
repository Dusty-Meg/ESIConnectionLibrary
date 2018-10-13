using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public class LatestSovereigntyEndpoints : ILatestSovereigntyEndpoints
    {
        private readonly IInternalLatestSovereignty _internalLatestSovereignty;

        public LatestSovereigntyEndpoints(string userAgent, bool testing = false)
        {
            _internalLatestSovereignty = new InternalLatestSovereignty(null, userAgent, testing);
        }

        public IList<V1SovereigntyCampaigns> Campaigns()
        {
            return _internalLatestSovereignty.Campaigns();
        }

        public async Task<IList<V1SovereigntyCampaigns>> CampaignsAsync()
        {
            return await _internalLatestSovereignty.CampaignsAsync();
        }

        public IList<V1SovereigntyMap> Map()
        {
            return _internalLatestSovereignty.Map();
        }

        public async Task<IList<V1SovereigntyMap>> MapAsync()
        {
            return await _internalLatestSovereignty.MapAsync();
        }

        public IList<V1SovereigntyStructures> Structures()
        {
            return _internalLatestSovereignty.Structures();
        }

        public async Task<IList<V1SovereigntyStructures>> StructuresAsync()
        {
            return await _internalLatestSovereignty.StructuresAsync();
        }
    }
}
