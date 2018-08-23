namespace ESIConnectionLibrary.PublicModels
{
    public class V1ContractsPublicItem
    {
        public bool? IsBlueprintCopy { get; set; }
        public bool IsIncluded { get; set; }
        public long? ItemId { get; set; }
        public int? MaterialEfficiency { get; set; }
        public int Quantity { get; set; }
        public long RecordId { get; set; }
        public int? Runs { get; set; }
        public int? TimeEfficiency { get; set; }
        public int TypeId { get; set; }
    }
}