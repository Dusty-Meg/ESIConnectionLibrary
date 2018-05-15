using System;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1PlanetaryInteractionCharactersPlanets
    {
        [JsonProperty(PropertyName = "last_update")]
        public DateTime LastUpdate { get; set; }

        [JsonProperty(PropertyName = "num_pins")]
        public int NumPins { get; set; }

        [JsonProperty(PropertyName = "owner_id")]
        public int OwnerId { get; set; }

        [JsonProperty(PropertyName = "planet_id")]
        public int PlanetId { get; set; }

        [JsonProperty(PropertyName = "planet_type")]
        public EsiV1PlanetaryInteractionPlanetType PlanetType { get; set; }

        [JsonProperty(PropertyName = "solar_system_id")]
        public int SolarSystemId { get; set; }

        [JsonProperty(PropertyName = "upgrade_level")]
        public int UpgradeLevel { get; set; }
    }
}
