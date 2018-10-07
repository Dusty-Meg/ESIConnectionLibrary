using System;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1FleetMember
    {
        [JsonProperty(PropertyName = "character_id")]
        public int CharacterId { get; set; }

        [JsonProperty(PropertyName = "join_time")]
        public DateTime JoinTime { get; set; }

        [JsonProperty(PropertyName = "role")]
        public EsiFleetRole Role { get; set; }

        [JsonProperty(PropertyName = "role_name")]
        public string RoleName { get; set; }

        [JsonProperty(PropertyName = "ship_type_id")]
        public int ShipTypeId { get; set; }

        [JsonProperty(PropertyName = "solar_system_id")]
        public int SolarSystemId { get; set; }

        [JsonProperty(PropertyName = "squad_id")]
        public long SquadId { get; set; }

        [JsonProperty(PropertyName = "station_id")]
        public long? StationId { get; set; }

        [JsonProperty(PropertyName = "takes_fleet_warp")]
        public bool TakesFleetWarp { get; set; }

        [JsonProperty(PropertyName = "wing_id")]
        public long WingId { get; set; }
    }
}