using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV2FittingsCharacterItem
    {
        [JsonProperty(PropertyName = "flag")]
        public EsiV2FittingsCharacterItemFlag Flag { get; set; }

        [JsonProperty(PropertyName = "quantity")]
        public int Quantity { get; set; }

        [JsonProperty(PropertyName = "type_id")]
        public int TypeId { get; set; }
    }
}