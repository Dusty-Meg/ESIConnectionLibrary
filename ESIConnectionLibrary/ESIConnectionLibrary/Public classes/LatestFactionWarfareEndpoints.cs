using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.Internal_classes;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public class LatestFactionWarfareEndpoints : ILatestFactionWarfareEndpoints
    {
        private readonly IInternalLatestFactionWarfare _internalLatestFactionWarfare;

        public LatestFactionWarfareEndpoints(string userAgent, bool testing = false)
        {
            _internalLatestFactionWarfare = new InternalLatestFactionWarfare(null, userAgent, testing);
        }

        public V1FwCharacterStats CharacterStats(SsoToken token)
        {
            return _internalLatestFactionWarfare.CharacterStats(token);
        }

        public async Task<V1FwCharacterStats> CharacterStatsAsync(SsoToken token)
        {
            return await _internalLatestFactionWarfare.CharacterStatsAsync(token);
        }

        public V1FwCorporationStats CorporationStats(SsoToken token, int corporationId)
        {
            return _internalLatestFactionWarfare.CorporationStats(token, corporationId);
        }

        public async Task<V1FwCorporationStats> CorporationStatsAsync(SsoToken token, int corporationId)
        {
            return await _internalLatestFactionWarfare.CorporationStatsAsync(token, corporationId);
        }

        public V1FwFactionLeaderboard FactionLeaderboard()
        {
            return _internalLatestFactionWarfare.FactionLeaderboard();
        }

        public async Task<V1FwFactionLeaderboard> FactionLeaderboardAsync()
        {
            return await _internalLatestFactionWarfare.FactionLeaderboardAsync();
        }

        public V1FwCharacterLeaderboard CharacterLeaderboard()
        {
            return _internalLatestFactionWarfare.CharacterLeaderboard();
        }

        public async Task<V1FwCharacterLeaderboard> CharacterLeaderboardAsync()
        {
            return await _internalLatestFactionWarfare.CharacterLeaderboardAsync();
        }

        public V1FwCorporationLeaderboard CorporationLeaderboard()
        {
            return _internalLatestFactionWarfare.CorporationLeaderboard();
        }

        public async Task<V1FwCorporationLeaderboard> CorporationLeaderboardAsync()
        {
            return await _internalLatestFactionWarfare.CorporationLeaderboardAsync();
        }

        public IList<V1FwFactionStats> FactionStats()
        {
            return _internalLatestFactionWarfare.FactionStats();
        }

        public async Task<IList<V1FwFactionStats>> FactionStatsAsync()
        {
            return await _internalLatestFactionWarfare.FactionStatsAsync();
        }

        public IList<V2FwSystems> Systems()
        {
            return _internalLatestFactionWarfare.Systems();
        }

        public async Task<IList<V2FwSystems>> SystemsAsync()
        {
            return await _internalLatestFactionWarfare.SystemsAsync();
        }

        public IList<V1FwWars> Wars()
        {
            return _internalLatestFactionWarfare.Wars();
        }

        public async Task<IList<V1FwWars>> WarsAsync()
        {
            return await _internalLatestFactionWarfare.WarsAsync();
        }
    }
}
