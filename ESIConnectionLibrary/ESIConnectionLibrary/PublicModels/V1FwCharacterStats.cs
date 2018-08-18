using System;

namespace ESIConnectionLibrary.PublicModels
{
    public class V1FwCharacterStats
    {
        public int? CurrentRank { get; set; }
        public DateTime? EnlistedOn { get; set; }
        public int? FactionId { get; set; }
        public int? HighestRank { get; set; }
        public V1FwCharacterStatsKills Kills { get; set; }
        public V1FwCharacterStatsVictoryPoints VictoryPoints { get; set; }
    }
}