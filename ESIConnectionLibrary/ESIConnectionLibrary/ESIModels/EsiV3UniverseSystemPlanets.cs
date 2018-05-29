using System.Collections.Generic;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV3UniverseSystemPlanets
    {
        [JsonProperty(PropertyName = "asteroid_belts")]
        public IList<int> AsteroidBelts { get; set; }

        [JsonProperty(PropertyName = "moons")]
        public IList<int> Moons { get; set; }

        [JsonProperty(PropertyName = "planet_id")]
        public int PlanetId { get; set; }
    }
}