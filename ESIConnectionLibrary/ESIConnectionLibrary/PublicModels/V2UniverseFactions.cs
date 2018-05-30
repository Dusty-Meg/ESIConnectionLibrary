namespace ESIConnectionLibrary.PublicModels
{
    public class V2UniverseFactions
    {
        public int? CorporationId { get; set; }
        public string Description { get; set; }
        public int FactionId { get; set; }
        public bool IsUnique { get; set; }
        public int? MilitiaCorporationId { get; set; }
        public string Name { get; set; }
        public float SizeFactor { get; set; }
        public int? SolarSystemId { get; set; }
        public int StationCount { get; set; }
        public int StationSystemCount { get; set; }
    }
}