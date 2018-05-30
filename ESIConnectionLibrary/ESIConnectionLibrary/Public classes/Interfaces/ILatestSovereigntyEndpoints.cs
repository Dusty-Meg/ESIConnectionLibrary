using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public interface ILatestSovereigntyEndpoints
    {
        IList<V1SovereigntyCampaigns> GetCampaigns();
        Task<IList<V1SovereigntyCampaigns>> GetCampaignsAsync();
        IList<V1SovereigntyMap> GetMap();
        Task<IList<V1SovereigntyMap>> GetMapAsync();
        IList<V1SovereigntyStructures> GetStructures();
        Task<IList<V1SovereigntyStructures>> GetStructuresAsync();
    }
}