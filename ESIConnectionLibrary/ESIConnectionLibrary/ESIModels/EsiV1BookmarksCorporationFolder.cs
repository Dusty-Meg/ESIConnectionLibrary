using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV1BookmarksCorporationFolder
    {
        [JsonProperty(PropertyName = "creator_id")]
        public int? CreatorId { get; set; }

        [JsonProperty(PropertyName = "folder_id")]
        public int FolderId { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}