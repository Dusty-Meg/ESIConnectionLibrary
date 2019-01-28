using System.Collections.Generic;

namespace ESIConnectionLibrary.PublicModels
{
    public class V3MailLabelsAndUnreadCount
    {
        public IList<V3MailLabelsAndUnreadCountLabels> Labels { get; set; }
        public int? TotalUnreadCount { get; set; }
    }
}