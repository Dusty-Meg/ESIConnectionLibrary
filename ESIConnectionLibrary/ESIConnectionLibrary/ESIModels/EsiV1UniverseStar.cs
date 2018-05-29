using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1UniverseStar
    {
        [JsonProperty(PropertyName = "age")]
        public long Age { get; set; }

        [JsonProperty(PropertyName = "luminosity")]
        public float Luminosity { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "radius")]
        public long Radius { get; set; }

        [JsonProperty(PropertyName = "solar_system_id")]
        public int SolarSystemId { get; set; }

        [JsonProperty(PropertyName = "spectral_class")]
        public EsiV1UniverseStarSpectralClass SpectralClass { get;set; }

        [JsonProperty(PropertyName = "temperature")]
        public int Temperature { get; set; }

        [JsonProperty(PropertyName = "type_id")]
        public int TypeId { get; set; }
    }
}