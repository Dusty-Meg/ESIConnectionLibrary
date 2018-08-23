using System;

namespace ESIConnectionLibrary.PublicModels
{
    public class V1ContractsPublic
    {
        public double? buyout { get; set; }
        public double? collateral { get; set; }
        public int contract_id { get; set; }
        public DateTime date_expired { get; set; }
        public DateTime date_issued { get; set; }
        public int? days_to_complete { get; set; }
        public long? end_location_id { get; set; }
        public bool? for_corporation { get; set; }
        public int issuer_corporation_id { get; set; }
        public int issuer_id { get; set; }
        public double? price { get; set; }
        public double? reward { get; set; }
        public long? start_location_id { get; set; }
        public string title { get; set; }
        public V1ContractsPublicType type { get; set; }
        public double? volume { get; set; }
    }
}