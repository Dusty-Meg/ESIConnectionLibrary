using System;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1IndustryCorporationExtractions
    {
        [JsonProperty(PropertyName = "chunk_arrival_time")]
        public DateTime ChunkArrivalTime { get; set; }

        [JsonProperty(PropertyName = "extraction_start_time")]
        public DateTime ExtractionStartTime { get; set; }

        [JsonProperty(PropertyName = "moon_id")]
        public int MoonId { get; set; }

        [JsonProperty(PropertyName = "natural_decay_time")]
        public DateTime NaturalDecayTime { get; set; }

        [JsonProperty(PropertyName = "structure_id")]
        public long StructureId { get; set; }
    }
}