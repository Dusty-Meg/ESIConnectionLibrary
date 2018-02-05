using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV2AllianceIdsToNames
    {
        [JsonProperty(PropertyName = "alliance_id")]
        public int AllianceId { get; set; }

        [JsonProperty(PropertyName = "alliance_name")]
        public string AllianceName { get; set; }
    }
}