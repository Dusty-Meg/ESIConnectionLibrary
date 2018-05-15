using System;

namespace ESIConnectionLibrary.PublicModels
{
    public class V1PlanetaryInteractionCharactersPlanets
    {
        public DateTime LastUpdate { get; set; }
        public int NumPins { get; set; }
        public int OwnerId { get; set; }
        public int PlanetId { get; set; }
        public V1PlanetaryInteractionPlanetType PlanetType { get; set; }
        public int SolarSystemId { get; set; }
        public int UpgradeLevel { get; set; }
    }
}