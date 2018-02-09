using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public interface ILatestAllianceEndpoints
    {
        IList<int> GetActiveAlliances();
        Task<IList<int>> GetActiveAlliancesAsync();
        IList<int> GetAllianceCorporation(int allianceId);
        Task<IList<int>> GetAllianceCorporationAsync(int allianceId);
        V1AllianceIcons GetAllianceIcons(int allianceId);
        Task<V1AllianceIcons> GetAllianceIconsAsync(int allianceId);
        IList<V2AllianceIdsToNames> GetAllianceNamesFromIds(IList<int> allianceIds);
        Task<IList<V2AllianceIdsToNames>> GetAllianceNamesFromIdsAsync(IList<int> allianceIds);
        V3GetPublicAlliance GetPublicAllianceInfo(int allianceId);
        Task<V3GetPublicAlliance> GetPublicAllianceInfoAsync(int allianceId);
    }
}