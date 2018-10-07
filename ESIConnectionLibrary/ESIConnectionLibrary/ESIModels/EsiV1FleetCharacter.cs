using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1FleetCharacter
    {
        [JsonProperty(PropertyName = "fleet_id")]
        public long FleetId { get; set; }

        [JsonProperty(PropertyName = "role")]
        public EsiFleetRole Role { get; set; }

        [JsonProperty(PropertyName = "squad_id")]
        public long SquadId { get; set; }

        [JsonProperty(PropertyName = "wing_id")]
        public long WingId { get; set; }
    }
}