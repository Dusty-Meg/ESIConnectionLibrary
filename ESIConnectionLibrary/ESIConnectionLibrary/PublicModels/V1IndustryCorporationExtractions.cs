using System;

namespace ESIConnectionLibrary.PublicModels
{
    public class V1IndustryCorporationExtractions
    {
        public DateTime ChunkArrivalTime { get; set; }
        public DateTime ExtractionStartTime { get; set; }
        public int MoonId { get; set; }
        public DateTime NaturalDecayTime { get; set; }
        public long StructureId { get; set; }
    }
}