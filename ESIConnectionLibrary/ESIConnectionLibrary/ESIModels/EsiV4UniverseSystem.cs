using System.Collections.Generic;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV4UniverseSystem
    {
        [JsonProperty(PropertyName = "constellation_id")]
        public int ConstellationId { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "planets")]
        public IList<EsiV3UniverseSystemPlanets> Planets { get; set; }

        [JsonProperty(PropertyName = "position")]
        public EsiPosition Position { get; set; }

        [JsonProperty(PropertyName = "security_class")]
        public string SecurityClass { get; set; }

        [JsonProperty(PropertyName = "security_status")]
        public float SecurityStatus { get; set; }

        [JsonProperty(PropertyName = "star_id")]
        public int? StarId { get; set; }

        [JsonProperty(PropertyName = "stargates")]
        public IList<int> Stargates { get; set; }

        [JsonProperty(PropertyName = "stations")]
        public IList<int> Stations { get; set; }

        [JsonProperty(PropertyName = "system_id")]
        public int SystemId { get; set; }
    }
}