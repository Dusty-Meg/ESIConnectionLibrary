using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV2FwSystems
    {
        [JsonProperty(PropertyName = "contested")]
        public EsiV2FwSystemsContested Contested { get; set; }

        [JsonProperty(PropertyName = "occupier_faction_id")]
        public int OccupierFactionId { get; set; }

        [JsonProperty(PropertyName = "owner_faction_id")]
        public int OwnerFactionId { get; set; }

        [JsonProperty(PropertyName = "solar_system_id")]
        public int SolarSystemId { get; set; }

        [JsonProperty(PropertyName = "victory_points")]
        public int VictoryPoints { get; set; }

        [JsonProperty(PropertyName = "victory_points_threshold")]
        public int VictoryPointsThreshold { get; set; }
    }
}