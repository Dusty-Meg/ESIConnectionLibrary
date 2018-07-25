namespace ESIConnectionLibrary.PublicModels
{
    public class V1ContractsCorporationItems
    {
        public bool IsIncluded { get; set; }
        public bool IsSingleton { get; set; }
        public int Quantity { get; set; }
        public int? RawQuantity { get; set; }
        public long RecordId { get; set; }
        public int TypeId { get; set; }
    }
}