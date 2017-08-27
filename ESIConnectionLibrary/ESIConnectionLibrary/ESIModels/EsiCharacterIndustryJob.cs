using System;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiCharacterIndustryJob
    {
        public int activity_id { get; set; }
        public long blueprint_id { get; set; }
        public int blueprint_location_id { get; set; }
        public int blueprint_type_id { get; set; }
        public int? completed_character_id { get; set; }
        public int? completed_date { get; set; } 
        public int? cost { get; set; }
        public int duration { get; set; }
        public DateTime end_date { get; set; }
        public int facility_id { get; set; }
        public int installer_id { get; set; }
        public int job_id { get; set; }
        public int? licensed_runs { get; set; }
        public int output_location_id { get; set; }
        public DateTime? pause_date { get; set; }
        public double? probability { get; set; }
        public int? product_type_id { get; set; }
        public int runs { get; set; }
        public DateTime start_date { get; set; }
        public int station_id { get; set; }
        public string status { get; set; }
        public int? successful_runs { get; set; }
    }


}
