using System.Collections.Generic;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Internal_classes
{
    internal interface IInternalLatestAlliance
    {
        IList<int> GetActiveAlliances();
        IList<int> GetAllianceCorporation(int allianceId);
        V1AllianceIcons GetAllianceIcons(int allianceId);
        IList<V2AllianceIdsToNames> GetAllianceNamesFromIds(IList<int> allianceIds);
        V3GetPublicAlliance GetPublicAllianceInfo(int allianceId);
    }
}