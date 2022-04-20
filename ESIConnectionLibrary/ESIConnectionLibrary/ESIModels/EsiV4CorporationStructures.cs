using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV4CorporationStructures
    {
        [JsonProperty(PropertyName = "corporation_id")]
        public int CorporationId { get; set; }

        [JsonProperty(PropertyName = "fuel_expires")]
        public DateTime? FuelExpires { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "next_reinforce_apply")]
        public DateTime? NextReinforceApply { get; set; }

        [JsonProperty(PropertyName = "next_reinforce_hour")]
        public int? NextReinforceHour { get; set; }

        [JsonProperty(PropertyName = "profile_id")]
        public int ProfileId { get; set; }

        [JsonProperty(PropertyName = "reinforce_hour")]
        public int ReinforceHour { get; set; }

        [JsonProperty(PropertyName = "services")]
        public IList<EsiV4CorporationStructuresServices> Services { get; set; }

        [JsonProperty(PropertyName = "state")]
        public EsiV4CorporationStructuresState State { get; set; }

        [JsonProperty(PropertyName = "state_timer_end")]
        public DateTime? StateTimerEnd { get; set; }

        [JsonProperty(PropertyName = "state_timer_start")]
        public DateTime? StateTimerStart { get; set; }

        [JsonProperty(PropertyName = "structure_id")]
        public long StructureId { get; set; }

        [JsonProperty(PropertyName = "system_id")]
        public int SystemId { get; set; }

        [JsonProperty(PropertyName = "type_id")]
        public int TypeId { get; set; }

        [JsonProperty(PropertyName = "unanchors_at")]
        public DateTime? UnanchorsAt { get; set; }
    }
}