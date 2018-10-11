using System;

namespace ESIConnectionLibrary.PublicModels
{
    public class V1IndustryCharacterMining
    {
        public DateTime Date { get; set; }
        public long Quantity { get; set; }
        public int SolarSystemId { get; set; }
        public int TypeId { get; set; }
    }
}