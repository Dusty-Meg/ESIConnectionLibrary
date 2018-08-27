using System;

namespace ESIConnectionLibrary.PublicModels
{
    public class V1MarketHistory
    {
        public double Average { get; set; }
        public DateTime Date { get; set; }
        public double Highest { get; set; }
        public double Lowest { get; set; }
        public long OrderCount { get; set; }
        public long Volume { get; set; }
    }
}