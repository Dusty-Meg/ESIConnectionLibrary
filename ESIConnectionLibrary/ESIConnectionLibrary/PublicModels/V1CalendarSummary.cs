using System;

namespace ESIConnectionLibrary.PublicModels
{
    public class V1CalendarSummary
    {
        public DateTime? EventDate { get; set; }
        public int? EventId { get; set; }
        public V1CalendarSummaryEventResponses? EventResponse { get; set; }
        public int? Importance { get; set; }
        public string Title { get; set; }
    }
}