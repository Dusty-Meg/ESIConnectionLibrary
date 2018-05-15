using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1WarsIndividualWarDefender
    {
        [JsonProperty(PropertyName = "alliance_id")]
        public int? AllianceId { get; set; }

        [JsonProperty(PropertyName = "corporation_id")]
        public int? CorporationId { get; set; }

        [JsonProperty(PropertyName = "isk_destroyed")]
        public float IskDestroyed { get; set; }

        [JsonProperty(PropertyName = "ships_killed")]
        public int ShipsKilled { get; set; }
    }
}