namespace ESIConnectionLibrary.PublicModels
{
    public class V1UniversePlanet
    {
        public string Name { get; set; }
        public int PlanetId { get; set; }
        public Position Position { get; set; }
        public int SystemId { get; set; }
        public int TypeId { get; set; }
    }
}