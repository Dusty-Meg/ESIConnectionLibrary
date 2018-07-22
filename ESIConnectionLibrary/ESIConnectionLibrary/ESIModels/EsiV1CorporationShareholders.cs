using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1CorporationShareholders
    {
        [JsonProperty(PropertyName = "share_count")]
        public long ShareCount { get; set; }

        [JsonProperty(PropertyName = "shareholder_id")]
        public int ShareholderId { get; set; }

        [JsonProperty(PropertyName = "shareholder_type")]
        public EsiV1CorporationShareholdersShareholdersType ShareholderType { get; set; }
    }
}