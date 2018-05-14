using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV3CharactersClonesHomeLocation
    {
        [JsonProperty(PropertyName = "location_id")]
        public long? LocationId { get; set; }

        [JsonProperty(PropertyName = "location_type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public EsiV3CharactersClonesLocationType LocationType { get; set; }
    }
}