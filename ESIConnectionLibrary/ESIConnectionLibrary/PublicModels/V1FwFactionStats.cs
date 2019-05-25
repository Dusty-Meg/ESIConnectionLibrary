namespace ESIConnectionLibrary.PublicModels
{
    public class V1FwFactionStats
    {
        public int FactionId { get; set; }
        public V1FwFactionStatsKills Kills { get; set; }
        public int Pilots { get; set; }
        public int SystemsControlled { get; set; }
        public V1FwFactionStatsVictoryPoints VictoryPoints { get; set; }
    }
}