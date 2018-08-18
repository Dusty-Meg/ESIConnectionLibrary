using System.Collections.Generic;

namespace ESIConnectionLibrary.PublicModels
{
    public class V1FwCorporationLeaderboardKills
    {
        public IList<V1FwCorporationLeaderboardKillsActiveTotal> ActiveTotal { get; set; }
        public IList<V1FwCorporationLeaderboardKillsLastWeek> LastWeek { get; set; }
        public IList<V1FwCorporationLeaderboardKillsYesterday> Yesterday { get; set; }
    }
}