using System.Collections.Generic;

namespace ESIConnectionLibrary.PublicModels
{
    public class V1MailSend
    {
        public long? ApprovedCost { get; set; }
        public string Body { get; set; }
        public IList<MailRecipients> Recipients { get; set; }
        public string Subject { get; set; }
    }
}