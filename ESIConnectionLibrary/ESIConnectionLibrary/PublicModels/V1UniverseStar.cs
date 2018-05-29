namespace ESIConnectionLibrary.PublicModels
{
    public class V1UniverseStar
    {
        public long Age { get; set; }
        public float Luminosity { get; set; }
        public string Name { get; set; }
        public long Radius { get; set; }
        public int SolarSystemId { get; set; }
        public V1UniverseStarSpectralClass SpectralClass { get; set; }
        public int Temperature { get; set; }
        public int TypeId { get; set; }
    }
}