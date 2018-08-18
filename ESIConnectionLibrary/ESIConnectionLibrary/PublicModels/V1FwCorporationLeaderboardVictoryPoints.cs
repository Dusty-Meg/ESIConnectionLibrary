using System.Collections.Generic;

namespace ESIConnectionLibrary.PublicModels
{
    public class V1FwCorporationLeaderboardVictoryPoints
    {
        public IList<V1FwCorporationLeaderboardVictoryPointsActiveTotal> ActiveTotal { get; set; }
        public IList<V1FwCorporationLeaderboardVictoryPointsLastWeek> LastWeek { get; set; }
        public IList<V1FwCorporationLeaderboardVictoryPointsYesterday> Yesterday { get; set; }
    }
}