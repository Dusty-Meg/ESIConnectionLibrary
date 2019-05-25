using System;
// ReSharper disable InconsistentNaming

namespace ESIConnectionLibrary.PublicModels
{
    [Flags]
    public enum CalendarScopes : long
    {
        None = 0L,
        esi_calendar_read_calendar_events_v1 = 1L << 1,
        esi_calendar_respond_calendar_events_v1 = 1L << 2,
    }
}