using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1UniverseAncestries
    {
        [JsonProperty(PropertyName = "bloodline_id")]
        public int BloodlineId { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "icon_id")]
        public int? IconId { get; set; }

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "short_description")]
        public string ShortDescription { get; set; }
    }
}
