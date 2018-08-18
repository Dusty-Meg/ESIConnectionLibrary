using System.Collections.Generic;

namespace ESIConnectionLibrary.PublicModels
{
    public class V1FwFactionLeaderboardVictoryPoints
    {
        public IList<V1FwFactionLeaderboardVictoryPointsActiveTotal> ActiveTotal { get; set; }
        public IList<V1FwFactionLeaderboardVictoryPointsLastWeek> LastWeek { get; set; }
        public IList<V1FwFactionLeaderboardVictoryPointsYesterday> Yesterday { get; set; }
    }
}