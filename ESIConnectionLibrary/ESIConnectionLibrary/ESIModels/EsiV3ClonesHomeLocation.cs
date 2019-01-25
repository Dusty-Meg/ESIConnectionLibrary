using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV3ClonesHomeLocation
    {
        [JsonProperty(PropertyName = "location_id")]
        public long? LocationId { get; set; }

        [JsonProperty(PropertyName = "location_type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public EsiV3ClonesLocationType LocationType { get; set; }
    }
}