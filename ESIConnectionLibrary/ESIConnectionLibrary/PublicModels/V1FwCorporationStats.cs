using System;

namespace ESIConnectionLibrary.PublicModels
{
    public class V1FwCorporationStats
    {
        public DateTime? EnlistedOn { get; set; }
        public int? FactionId { get; set; }
        public V1FwCorporationKills Kills { get; set; }
        public int? Pilots { get; set; }
        public V1FwCorporationVictoryPoints VictoryPoints { get; set; }
    }
}