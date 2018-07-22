namespace ESIConnectionLibrary.PublicModels
{
    public class V2UniverseStructure
    {
        public string Name { get; set; }
        public int OwnerId { get; set; }
        public Position Position { get; set; }
        public int SolarSystemId { get; set; }
        public int? TypeId { get; set; }
    }
}