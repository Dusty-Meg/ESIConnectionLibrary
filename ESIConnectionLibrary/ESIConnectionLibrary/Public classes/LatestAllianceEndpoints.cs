using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public class LatestAllianceEndpoints : ILatestAllianceEndpoints
    {
        private readonly IInternalLatestAlliance _internalLatestAlliance;

        public LatestAllianceEndpoints(string userAgent, bool testing = false)
        {
            _internalLatestAlliance = new InternalLatestAlliance(null, userAgent, testing);
        }

        public IList<int> GetActiveAlliances()
        {
            return _internalLatestAlliance.GetActiveAlliances();
        }

        public async Task<IList<int>> GetActiveAlliancesAsync()
        {
            return await _internalLatestAlliance.GetActiveAlliancesAsync();
        }

        public V3GetPublicAlliance GetPublicAllianceInfo(int allianceId)
        {
            return _internalLatestAlliance.GetPublicAllianceInfo(allianceId);
        }

        public async Task<V3GetPublicAlliance> GetPublicAllianceInfoAsync(int allianceId)
        {
            return await _internalLatestAlliance.GetPublicAllianceInfoAsync(allianceId);
        }

        public IList<int> GetAllianceCorporation(int allianceId)
        {
            return _internalLatestAlliance.GetAllianceCorporation(allianceId);
        }

        public async Task<IList<int>> GetAllianceCorporationAsync(int allianceId)
        {
            return await _internalLatestAlliance.GetAllianceCorporationAsync(allianceId);
        }

        public V1AllianceIcons GetAllianceIcons(int allianceId)
        {
            return _internalLatestAlliance.GetAllianceIcons(allianceId);
        }

        public async Task<V1AllianceIcons> GetAllianceIconsAsync(int allianceId)
        {
            return await _internalLatestAlliance.GetAllianceIconsAsync(allianceId);
        }

        public IList<V2AllianceIdsToNames> GetAllianceNamesFromIds(IList<int> allianceIds)
        {
            return _internalLatestAlliance.GetAllianceNamesFromIds(allianceIds);
        }

        public async Task<IList<V2AllianceIdsToNames>> GetAllianceNamesFromIdsAsync(IList<int> allianceIds)
        {
            return await _internalLatestAlliance.GetAllianceNamesFromIdsAsync(allianceIds);
        }
    }
}
