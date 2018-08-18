namespace ESIConnectionLibrary.PublicModels
{
    public class V2FwSystems
    {
        public V2FwSystemsContested Contested { get; set; }
        public int OccupierFactionId { get; set; }
        public int OwnerFactionId { get; set; }
        public int SolarSystemId { get; set; }
        public int VictoryPoints { get; set; }
        public int VictoryPointsThreshold { get; set; }
    }
}