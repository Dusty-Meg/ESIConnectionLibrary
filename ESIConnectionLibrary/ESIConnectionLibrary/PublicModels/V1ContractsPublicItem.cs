namespace ESIConnectionLibrary.PublicModels
{
    public class V1ContractsPublicItem
    {
        public bool? is_blueprint_copy { get; set; }
        public bool is_included { get; set; }
        public long? item_id { get; set; }
        public int? material_efficiency { get; set; }
        public int quantity { get; set; }
        public long record_id { get; set; }
        public int? runs { get; set; }
        public int? time_efficiency { get; set; }
        public int type_id { get; set; }
    }
}