using System.Collections.Generic;

namespace ESIConnectionLibrary.PublicModels
{
    public class V1FwCharacterLeaderboardKills
    {
        public IList<V1FwCharacterLeaderboardKillsActiveTotal> ActiveTotal { get; set; }
        public IList<V1FwCharacterLeaderboardKillsLastWeek> LastWeek { get; set; }
        public IList<V1FwCharacterLeaderboardKillsYesterday> Yesterday { get; set; }
    }
}