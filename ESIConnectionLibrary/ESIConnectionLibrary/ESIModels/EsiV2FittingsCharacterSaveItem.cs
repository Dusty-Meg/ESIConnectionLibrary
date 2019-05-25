using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV2FittingsCharacterSaveItem
    {
        [JsonProperty(PropertyName = "flag")]
        public EsiV2FittingsCharacterSaveItemFlag Flag { get; set; }

        [JsonProperty(PropertyName = "quantity")]
        public int Quantity { get; set; }

        [JsonProperty(PropertyName = "type_id")]
        public int TypeId { get; set; }
    }
}