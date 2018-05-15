using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1WarsIndividualWarAllies
    {
        [JsonProperty(PropertyName = "alliance_id")]
        public int? AllianceId { get; set; }

        [JsonProperty(PropertyName = "corporation_id")]
        public int? CorporationId { get; set; }
    }
}