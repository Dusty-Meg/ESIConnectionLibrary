namespace ESIConnectionLibrary.PublicModels
{
    public class V1UniverseStargate
    {
        public V1UniverseStargateDestination Destination { get; set; }
        public string Name { get; set; }
        public Position Position { get; set; }
        public int StargateId { get; set; }
        public int SystemId { get; set; }
        public int TypeId { get; set; }
    }
}