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

        internal LatestAllianceEndpoints(string userAgent, IWebClient webClient)
        {
            _internalLatestAlliance = new InternalLatestAlliance(webClient, userAgent);
        }

        public IList<int> Alliances()
        {
            return _internalLatestAlliance.Alliances();
        }

        public async Task<IList<int>> AlliancesAsync()
        {
            return await _internalLatestAlliance.AlliancesAsync();
        }

        public V3AlliancePublicInfo PublicInfo(int allianceId)
        {
            return _internalLatestAlliance.PublicInfo(allianceId);
        }

        public async Task<V3AlliancePublicInfo> PublicInfoAsync(int allianceId)
        {
            return await _internalLatestAlliance.PublicInfoAsync(allianceId);
        }

        public IList<int> Corporations(int allianceId)
        {
            return _internalLatestAlliance.Corporations(allianceId);
        }

        public async Task<IList<int>> CorporationsAsync(int allianceId)
        {
            return await _internalLatestAlliance.CorporationsAsync(allianceId);
        }

        public V1AllianceIcons Icons(int allianceId)
        {
            return _internalLatestAlliance.Icons(allianceId);
        }

        public async Task<V1AllianceIcons> IconsAsync(int allianceId)
        {
            return await _internalLatestAlliance.IconsAsync(allianceId);
        }
    }
}
