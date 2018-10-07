using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1FleetMemberMove
    {
        [JsonProperty(PropertyName = "role")]
        public EsiFleetRole Role { get; set; }

        [JsonProperty(PropertyName = "squad_id")]
        public long? SquadId { get; set; }

        [JsonProperty(PropertyName = "wing_id")]
        public long? WingId { get; set; }
    }
}