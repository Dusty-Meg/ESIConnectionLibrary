using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV3PlanetaryInteractionCharactersPlanetPins
    {
        [JsonProperty(PropertyName = "contents")]
        public IList<EsiV3PlanetaryInteractionCharactersPlanetPinsContent> Contents { get; set; }

        [JsonProperty(PropertyName = "expiry_time")]
        public DateTime ExpiryTime { get; set; }

        [JsonProperty(PropertyName = "extractor_details")]
        public IList<EsiV3PlanetaryInteractionCharactersPlanetPinsExtractorDetails> ExtractorDetails { get; set; }

        [JsonProperty(PropertyName = "factory_details")]
        public IList<EsiV3PlanetaryInteractionCharactersPlanetPinsExtractorDetailsFactoryDetails> FactoryDetails { get; set; }

        [JsonProperty(PropertyName = "install_time")]
        public DateTime? InstallTime { get; set; }

        [JsonProperty(PropertyName = "last_cycle_start")]
        public DateTime? LastCycleStart { get; set; }

        [JsonProperty(PropertyName = "latitude")]
        public float Latitude { get; set; }

        [JsonProperty(PropertyName = "longitude")]
        public float Longitude { get; set; }

        [JsonProperty(PropertyName = "pin_id")]
        public long PinId { get; set; }

        [JsonProperty(PropertyName = "schematic_id")]
        public int? SchematicId { get; set; }

        [JsonProperty(PropertyName = "type_id")]
        public int TypeId { get; set; }
    }
}