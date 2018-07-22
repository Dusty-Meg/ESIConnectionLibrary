using System;

namespace ESIConnectionLibrary.PublicModels
{
    public class V2BookmarksCharacter
    {
        public int BookmarkId { get; set; }
        public Position Coordinates { get; set; }
        public DateTime Created { get; set; }
        public int CreatorId { get; set; }
        public int? FolderId { get; set; }
        public V2BookmarksCharacterItem Item { get; set; }
        public string Label { get; set; }
        public int LocationId { get; set; }
        public string Notes { get; set; }
    }
}