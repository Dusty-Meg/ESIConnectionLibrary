using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1DogmaAttribute
    {
        [JsonProperty(PropertyName = "attribute_id")]
        public int AttributeId { get; set; }

        [JsonProperty(PropertyName = "default_value")]
        public float? DefaultValue { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "display_name")]
        public string DisplayName { get; set; }

        [JsonProperty(PropertyName = "high_is_good")]
        public bool? HighIsGood { get; set; }

        [JsonProperty(PropertyName = "icon_id")]
        public int? IconId { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "published")]
        public bool? Published { get; set; }

        [JsonProperty(PropertyName = "stackable")]
        public bool? Stackable { get; set; }

        [JsonProperty(PropertyName = "unit_id")]
        public int? UnitId { get; set; }
    }
}