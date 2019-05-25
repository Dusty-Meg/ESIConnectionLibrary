using System;
// ReSharper disable InconsistentNaming

namespace ESIConnectionLibrary.PublicModels
{
    [Flags]
    public enum BookmarkScopes : long
    {
        None = 0L,
        esi_bookmarks_read_character_bookmarks_v1 = 1L << 1,
        esi_bookmarks_read_corporation_bookmarks_v1 = 1L << 2,
    }
}