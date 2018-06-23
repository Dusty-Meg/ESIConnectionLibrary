using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Internal_classes
{
    internal interface IInternalLatestAlliance
    {
        IList<int> GetActiveAlliances();
        Task<IList<int>> GetActiveAlliancesAsync();
        IList<int> GetAllianceCorporation(int allianceId);
        Task<IList<int>> GetAllianceCorporationAsync(int allianceId);
        V1AllianceIcons GetAllianceIcons(int allianceId);
        Task<V1AllianceIcons> GetAllianceIconsAsync(int allianceId);
        V3GetPublicAlliance GetPublicAllianceInfo(int allianceId);
        Task<V3GetPublicAlliance> GetPublicAllianceInfoAsync(int allianceId);
    }
}