using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Internal_classes
{
    internal interface IInternalLatestSovereignty
    {
        IList<V1SovereigntyCampaigns> Campaigns();
        Task<IList<V1SovereigntyCampaigns>> CampaignsAsync();
        IList<V1SovereigntyMap> Map();
        Task<IList<V1SovereigntyMap>> MapAsync();
        IList<V1SovereigntyStructures> Structures();
        Task<IList<V1SovereigntyStructures>> StructuresAsync();
    }
}