using System.Collections.Generic;

namespace ESIConnectionLibrary.PublicModels
{
    public class V1UiSendMail
    {
        public string Body { get; set; }
        public IList<int> Recipients { get; set; }
        public string Subject { get; set; }
        public int? ToCorpOrAllianceId { get; set; }
        public int? ToMailingListId { get; set; }
    }
}