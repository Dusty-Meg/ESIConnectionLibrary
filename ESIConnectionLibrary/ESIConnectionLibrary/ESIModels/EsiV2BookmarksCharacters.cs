using System;
using Newtonsoft.Json;

namespace ESIConnectionLibrary.ESIModels
{
    internal class EsiV2BookmarksCharacter
    {
        [JsonProperty(PropertyName = "bookmark_id")]
        public int BookmarkId { get; set; }

        [JsonProperty(PropertyName = "coordinates")]
        public EsiPosition Coordinates { get; set; }

        [JsonProperty(PropertyName = "created")]
        public DateTime Created { get; set; }

        [JsonProperty(PropertyName = "creator_id")]
        public int CreatorId { get; set; }

        [JsonProperty(PropertyName = "folder_id")]
        public int? FolderId { get; set; }

        [JsonProperty(PropertyName = "item")]
        public EsiV2BookmarksCharacterItem Item { get; set; }

        [JsonProperty(PropertyName = "label")]
        public string Label { get; set; }

        [JsonProperty(PropertyName = "location_id")]
        public int LocationId { get; set; }

        [JsonProperty(PropertyName = "notes")]
        public string Notes { get; set; }
    }
}
