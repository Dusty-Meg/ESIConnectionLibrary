using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Internal_classes
{
    internal interface IInternalLatestAlliance
    {
        IList<int> Alliances();
        Task<IList<int>> AlliancesAsync();
        IList<int> Corporations(int allianceId);
        Task<IList<int>> CorporationsAsync(int allianceId);
        V1AllianceIcons Icons(int allianceId);
        Task<V1AllianceIcons> IconsAsync(int allianceId);
        V3AlliancePublicInfo PublicInfo(int allianceId);
        Task<V3AlliancePublicInfo> PublicInfoAsync(int allianceId);
    }
}