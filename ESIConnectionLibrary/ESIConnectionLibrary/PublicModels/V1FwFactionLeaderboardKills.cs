using System.Collections.Generic;

namespace ESIConnectionLibrary.PublicModels
{
    public class V1FwFactionLeaderboardKills
    {
        public IList<V1FwFactionLeaderboardKillsActiveTotal> ActiveTotal { get; set; }
        public IList<V1FwFactionLeaderboardKillsLastWeek> LastWeek { get; set; }
        public IList<V1FwFactionLeaderboardKillsYesterday> Yesterday { get; set; }
    }
}