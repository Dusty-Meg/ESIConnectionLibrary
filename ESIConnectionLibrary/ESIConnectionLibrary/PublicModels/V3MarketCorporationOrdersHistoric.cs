using System;

namespace ESIConnectionLibrary.PublicModels
{
    public class V3MarketCorporationOrdersHistoric
    {
        public int Duration { get; set; }
        public double? Escrow { get; set; }
        public bool? IsBuyOrder { get; set; }
        public DateTime Issued { get; set; }
        public int IssuedBy { get; set; }
        public long LocationId { get; set; }
        public int? MinVolume { get; set; }
        public long OrderId { get; set; }
        public double Price { get; set; }
        public MarketRange Range { get; set; }
        public int RegionId { get; set; }
        public MarketState State { get; set; }
        public int TypeId { get; set; }
        public int VolumeRemain { get; set; }
        public int VolumeTotal { get; set; }
        public int WalletDivision { get; set; }
    }
}