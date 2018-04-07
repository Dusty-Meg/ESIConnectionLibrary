using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV2CharactersBlueprints
    {
        [JsonProperty(PropertyName = "item_id")]
        public long ItemId { get; set; }

        [JsonProperty(PropertyName = "type_id")]
        public int TypeId { get; set; }

        [JsonProperty(PropertyName = "location_id")]
        public long LocationId { get; set; }

        [JsonProperty(PropertyName = "location_flag")]
        public EsiLocationFlagCharacter LocationFlag { get; set; }

        [JsonProperty(PropertyName = "quantity")]
        public int Quantity { get; set; }

        [JsonProperty(PropertyName = "time_efficiency")]
        public int TimeEfficiency { get; set; }

        [JsonProperty(PropertyName = "material_efficiency")]
        public int MaterialEfficiency { get; set; }

        [JsonProperty(PropertyName = "runs")]
        public int Runs { get; set; }
    }
}
