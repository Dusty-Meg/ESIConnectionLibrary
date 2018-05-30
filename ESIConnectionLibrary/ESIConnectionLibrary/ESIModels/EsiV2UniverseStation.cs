using System.Collections.Generic;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV2UniverseStation
    {
        [JsonProperty(PropertyName = "max_dockable_ship_volume")]
        public float MaxDockableShipVolume { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "office_rental_cost")]
        public float OfficeRentalCost { get; set; }

        [JsonProperty(PropertyName = "owner")]
        public int? Owner { get; set; }

        [JsonProperty(PropertyName = "position")]
        public EsiPosition Position { get; set; }

        [JsonProperty(PropertyName = "race_id")]
        public int? RaceId { get; set; }

        [JsonProperty(PropertyName = "reprocessing_efficiency")]
        public float ReprocessingEfficiency { get; set; }

        [JsonProperty(PropertyName = "reprocessing_stations_take")]
        public float ReprocessingStationsTake { get; set; }

        [JsonProperty(PropertyName = "services")]
        public IList<EsiV2UniverseStationServices> Services { get; set; }

        [JsonProperty(PropertyName = "station_id")]
        public int StationId { get; set; }

        [JsonProperty(PropertyName = "system_id")]
        public int SystemId { get; set; }

        [JsonProperty(PropertyName = "type_id")]
        public int TypeId { get; set; }
    }
}