using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1UniverseGraphic
    {
        [JsonProperty(PropertyName = "collision_file")]
        public string CollisionFile { get; set; }

        [JsonProperty(PropertyName = "graphic_file")]
        public string GraphicFile { get; set; }

        [JsonProperty(PropertyName = "graphic_id")]
        public int GraphicId { get; set; }

        [JsonProperty(PropertyName = "icon_folder")]
        public string IconFolder { get; set; }

        [JsonProperty(PropertyName = "sof_dna")]
        public string SofDna { get; set; }

        [JsonProperty(PropertyName = "sof_fation_name")]
        public string SofFationName { get; set; }

        [JsonProperty(PropertyName = "sof_hull_name")]
        public string SofHullName { get; set; }

        [JsonProperty(PropertyName = "sof_race_name")]
        public string SofRaceName { get; set; }
    }
}