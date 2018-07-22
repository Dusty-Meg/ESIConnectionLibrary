using System;

namespace ESIConnectionLibrary.PublicModels
{
    public class V3CalendarEvent
    {
        public DateTime Date { get; set; }
        public int Duration { get; set; }
        public int EventId { get; set; }
        public int Importance { get; set; }
        public int OwnerId { get; set; }
        public string OwnerName { get; set; }
        public V3CalendarEventOwnerType OwnerType { get; set; }
        public string Response { get; set; }
        public string Text { get; set; }
        public string Title { get; set; }
    }
}