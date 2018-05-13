using System;

namespace ESIConnectionLibrary.PublicModels
{
    [Flags]
    public enum UiScopes : long
    {
        None = 0L,
        esi_ui_open_window_v1 = 1L << 1,
        esi_ui_write_waypoint_v1 = 1L << 2,
    }
}