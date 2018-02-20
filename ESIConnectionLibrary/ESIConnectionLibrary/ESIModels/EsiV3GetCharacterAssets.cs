using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV3GetCharacterAssets
    {
        [JsonProperty(PropertyName = "type_id")]
        public int TypeId { get; set; }

        [JsonProperty(PropertyName = "quantity")]
        public int Quantity { get; set; }

        [JsonProperty(PropertyName = "location_id")]
        public long LocationId { get; set; }

        [JsonProperty(PropertyName = "location_type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public EsiLocationType LocationType { get; set; }

        [JsonProperty(PropertyName = "item_id")]
        public long ItemId { get; set; }

        [JsonProperty(PropertyName = "location_flag")]
        [JsonConverter(typeof(StringEnumConverter))]
        public EsiLocationFlagCharacter LocationFlag { get; set; }

        [JsonProperty(PropertyName = "is_singleton")]
        public bool IsSingleton { get; set; }
    }
}
