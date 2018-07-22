using System;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV2CorporationContainerLogs
    {
        [JsonProperty(PropertyName = "action")]
        public EsiV2CorporationContainerLogAction Action { get; set; }

        [JsonProperty(PropertyName = "character_id")]
        public int CharacterId { get; set; }

        [JsonProperty(PropertyName = "container_id")]
        public long ContainerId { get; set; }

        [JsonProperty(PropertyName = "container_type_id")]
        public int ContainerTypeId { get; set; }

        [JsonProperty(PropertyName = "location_flag")]
        public EsiLocationFlagCorporation LocationFlag { get; set; }

        [JsonProperty(PropertyName = "location_id")]
        public long LocationId { get; set; }

        [JsonProperty(PropertyName = "logged_at")]
        public DateTime LoggedAt { get; set; }

        [JsonProperty(PropertyName = "new_config_bitmask")]
        public int? NewConfigBitmask { get; set; }

        [JsonProperty(PropertyName = "old_config_bitmask")]
        public int? OldConfigBitmask { get; set; }

        [JsonProperty(PropertyName = "password_type")]
        public EsiV2CorporationContainerLogPasswordType? PasswordType { get; set; }

        [JsonProperty(PropertyName = "quantity")]
        public int? Quantity { get; set; }

        [JsonProperty(PropertyName = "type_id")]
        public int? TypeId { get; set; }
    }
}