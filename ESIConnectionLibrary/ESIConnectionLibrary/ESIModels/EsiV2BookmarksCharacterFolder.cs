using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV2BookmarksCharacterFolder
    {
        [JsonProperty(PropertyName = "folder_id")]
        public int FolderId { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}