using System.Collections.Generic;

namespace ESIConnectionLibrary.PublicModels
{
    public class V1FwCharacterLeaderboardVictoryPoints
    {
        public IList<V1FwCharacterLeaderboardVictoryPointsActiveTotal> ActiveTotal { get; set; }
        public IList<V1FwCharacterLeaderboardVictoryPointsLastWeek> LastWeek { get; set; }
        public IList<V1FwCharacterLeaderboardVictoryPointsYesterday> Yesterday { get; set; }
    }
}