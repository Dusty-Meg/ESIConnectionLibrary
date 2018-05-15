using System.Collections.Generic;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV3PlanetaryInteractionCharactersPlanetPinsExtractorDetails
    {
        [JsonProperty(PropertyName = "cycle_time")]
        public int? CycleTime { get; set; }

        [JsonProperty(PropertyName = "head_radius")]
        public float? HeadRadius { get; set; }

        [JsonProperty(PropertyName = "heads")]
        public IList<EsiV3PlanetaryInteractionCharactersPlanetPinsExtractorDetailsHeads> Heads { get; set; }

        [JsonProperty(PropertyName = "product_type_id")]
        public int? ProductTypeId { get; set; }

        [JsonProperty(PropertyName = "qty_per_cycle")]
        public int? QtyPerCycle { get; set; }
    }
}