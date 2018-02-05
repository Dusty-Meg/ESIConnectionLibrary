using System.Collections.Generic;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public class LatestAllianceEndpoints : ILatestAllianceEndpoints
    {
        private readonly IInternalLatestAlliance _internalLatestAlliance;

        public LatestAllianceEndpoints(string userAgent)
        {
            _internalLatestAlliance = new InternalLatestAlliance(null, userAgent);
        }

        public IList<int> GetActiveAlliances()
        {
            return _internalLatestAlliance.GetActiveAlliances();
        }

        public V3GetPublicAlliance GetPublicAllianceInfo(int allianceId)
        {
            return _internalLatestAlliance.GetPublicAllianceInfo(allianceId);
        }

        public IList<int> GetAllianceCorporation(int allianceId)
        {
            return _internalLatestAlliance.GetAllianceCorporation(allianceId);
        }

        public V1AllianceIcons GetAllianceIcons(int allianceId)
        {
            return _internalLatestAlliance.GetAllianceIcons(allianceId);
        }

        public IList<V2AllianceIdsToNames> GetAllianceNamesFromIds(IList<int> allianceIds)
        {
            return _internalLatestAlliance.GetAllianceNamesFromIds(allianceIds);
        }
    }
}
