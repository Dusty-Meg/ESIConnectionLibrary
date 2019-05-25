using System.Collections.Generic;
using System.Threading.Tasks;
using ESIConnectionLibrary.PublicModels;

namespace ESIConnectionLibrary.Public_classes
{
    public interface ILatestFactionWarfareEndpoints
    {
        V1FwCharacterStats CharacterStats(SsoToken token);
        Task<V1FwCharacterStats> CharacterStatsAsync(SsoToken token);
        V1FwCorporationStats CorporationStats(SsoToken token, int corporationId);
        Task<V1FwCorporationStats> CorporationStatsAsync(SsoToken token, int corporationId);
        V1FwFactionLeaderboard FactionLeaderboard();
        Task<V1FwFactionLeaderboard> FactionLeaderboardAsync();
        V1FwCharacterLeaderboard CharacterLeaderboard();
        Task<V1FwCharacterLeaderboard> CharacterLeaderboardAsync();
        V1FwCorporationLeaderboard CorporationLeaderboard();
        Task<V1FwCorporationLeaderboard> CorporationLeaderboardAsync();
        IList<V1FwFactionStats> FactionStats();
        Task<IList<V1FwFactionStats>> FactionStatsAsync();
        IList<V2FwSystems> Systems();
        Task<IList<V2FwSystems>> SystemsAsync();
        IList<V1FwWars> Wars();
        Task<IList<V1FwWars>> WarsAsync();
    }
}