using System.Collections.Generic;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public interface ILatestAllianceEndpoints
    {
        IList<int> GetActiveAlliances();
        IList<int> GetAllianceCorporation(int allianceId);
        V1AllianceIcons GetAllianceIcons(int allianceId);
        IList<V2AllianceIdsToNames> GetAllianceNamesFromIds(IList<int> allianceIds);
        V3GetPublicAlliance GetPublicAllianceInfo(int allianceId);
    }
}